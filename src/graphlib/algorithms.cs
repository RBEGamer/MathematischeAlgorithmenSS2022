using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace graphlib
{
    public class algorithms
    {

        public struct SSP_RESULT
        {
            public bool is_costs_minimal;
            public double minimal_flow_value;

            public override string ToString()
            {
                if (is_costs_minimal)
                {
                    return "Minimal Flow: " + minimal_flow_value.ToString();
                }
                else
                {
                    return "NoCostMinimalFlow";
                }

            }
        }

        private static double calculate_min_max_costs(flow_graph _fg)
        {
            double costs = 0.0;
            foreach (edge e in _fg.get_all_edges())
            {
                if (!e.IsResidualEdge)
                {
                    costs += (e.Flow * e.Costs);
                }
            }
            return costs;
        }

        private static node getTNode(flow_graph _fg, node _s)
        {
            if (_s == null)
            {
                return null;
            }

            visited_handler v = new visited_handler(_fg.node_count());
            breadth_first_search(_fg, _s, null, v, true);
            for (int i = 0; i < v.get_array().Length; i++)
            {
                node n = _fg.node_lookup[i];
                if (v.is_visited(n) && (n.Balance - n.IsBalance) < 0)
                {
                    return n;
                }
            }

            return null;
        }

        private static node getSNode(flow_graph _fg)
        {
            node s = null;
            foreach (node n in _fg.get_all_nodes())
            {
                if ((n.Balance - n.IsBalance) > 0)
                {
                    s = n;
                    break;

                }
            }
            return s;
        }

        private static bool is_cost_minimal(flow_graph _fg)
        {
            foreach (node n in _fg.get_all_nodes())
            {
                if (n.Balance != n.IsBalance)
                {
                    return false;
                }
            }
            return true;
        }




        public static SSP_RESULT cycle_canceling(flow_graph _fg)
        {
            SSP_RESULT res = new SSP_RESULT();

            List<node> sources = _fg.get_sources();
            List<node> targets = _fg.get_targets();

            //Schritt 1
            node superS = _fg.add_empty_node();
            foreach (node source in sources)
            {
                edge e = new edge(superS, source, 0.0, source.Balance);
                superS.add_edge(e);
                superS.Balance = (superS.Balance + source.Balance);
                source.Balance = 0.0;

            }

            node superT = _fg.add_empty_node();
            foreach (node target in targets)
            {
                double cap = target.Balance;
                if (cap < 0)
                {
                    cap = cap * (-1.0);
                }
                edge e = new edge(target, superT, 0.0, cap);
                target.add_edge(e);

                superT.Balance = superT.Balance + target.Balance;
                target.Balance = 0.0;

            }

            // Schritt 1
            flow_graph fg2 = edmonds_karp(_fg, superS, superT);

            if (fg2.MaxFlow == superS.Balance && -fg2.MaxFlow == superT.Balance)
            {
                bool ready = false;
                visited_handler v = new visited_handler(fg2.node_count());
                while (!ready)
                {
                    foreach (node n in fg2.get_all_nodes())
                    {
                        v.set_visited(n);
                        // Schritt 3
                        previous_structure prev = bellman_ford(fg2, n);

                        List<edge> negativeCycle = prev.getNegativeCycle;

                        if (v.is_all_visited())
                        {
                            ready = true;
                            break;
                        }

                        // Schritt 4
                        double minCapacity = prev.getMinNegativCylcleCapacity;
                        foreach (edge e in negativeCycle)
                        {
                            e.Capacity -= minCapacity;
                            e.Flow += minCapacity;

                            List<edge> rev_ls = fg2.get_edge_from_node(e.To, e.From);
                            if (rev_ls.Count > 0)
                            {
                                edge rev = rev_ls[0];
                                rev.Capacity += minCapacity;
                                rev.Flow -= minCapacity;
                            }
                            else
                            {
                                res.is_costs_minimal = false;
                                return res;
                            }

                        }
                    }
                }

                res.is_costs_minimal = true;
                res.minimal_flow_value = calculate_min_max_costs(fg2);
                return res;
            }
            else
            {
                res.is_costs_minimal = false;
                return res;
            }

        }





        public static SSP_RESULT success_shortest_path(flow_graph _fg)
        {
            SSP_RESULT res;
            res.is_costs_minimal = true;
            res.minimal_flow_value = 0.0;

            _fg.create_redisual_graph();

            foreach (edge e in _fg.get_all_edges())
            {
                if (!e.IsResidualEdge && e.Costs < 0)
                {
                    e.Flow = e.Capacity;
                    e.Capacity = 0.0f;

                    //GET REVERSE EDGE
                    List<edge> rev_list = _fg.get_edge_from_node(e.To, e.From);
                    if (rev_list.Count > 0)
                    {
                        edge rev = rev_list[0];
                        rev.Capacity = e.Flow;
                    }
                }

                e.From.IsBalance += e.Flow;
                e.To.IsBalance -= e.Flow;
            }


            int iteration = 0;

            while (true)
            {
                node s = getSNode(_fg);
                node t = getTNode(_fg, s);
                if (s == null || t == null)
                {
                    if (is_cost_minimal(_fg))
                    {
                        res.is_costs_minimal = true;
                        res.minimal_flow_value = calculate_min_max_costs(_fg);
                        return res;
                    }
                    else
                    {
                        res.is_costs_minimal = false;
                        return res;
                    }
                }

                previous_structure prev = bellman_ford(_fg, s);
                //previous_structure prev = djikstra(_fg, s);
                List<node> p = prev.get_path(s, t, false);

                double gamma = Math.Min(s.Balance - s.IsBalance, t.IsBalance - t.Balance);
                for (int i = 0; i < p.Count - 1; i++)
                {
                    node a = p.ElementAt(i);
                    node b = p.ElementAt(i + 1);


                    List<edge> e_list = _fg.get_edge_from_node(a, b);
                    if (e_list.Count > 0)
                    {
                        edge e = e_list[0];
                        gamma = Math.Min(gamma, e.Capacity);
                        int wer = 0;
                    }
                }

                for (int i = 0; i < p.Count - 1; i++)
                {
                    node a = p.ElementAt(i);
                    node b = p.ElementAt(i + 1);


                    List<edge> es = _fg.get_edge_from_node(a, b);
                    List<edge> rev_es = _fg.get_edge_from_node(b, a);

                    if (es.Count <= 0 || rev_es.Count <= 0)
                    {
                        res.is_costs_minimal = false;
                        return res;
                    }

                    edge e = es[0];
                    edge rev = rev_es[0];

                    e.increase_flow(gamma);
                    e.decrease_capacity(gamma);

                    rev.decrease_flow(gamma);
                    rev.increase_capacity(gamma);
                    int wt = 0;
                }
                s.IsBalance += gamma;
                t.IsBalance -= gamma;
                iteration++;
            }

        }

        public static flow_graph edmonds_karp(flow_graph _fg, node _start, node _target)
        {
            _fg.create_redisual_graph();
            List<node> ds = breadth_first_search(_fg, _start, _target, null, true);

            while (ds.Count > 0)
            {
                double max_path_flow = Double.PositiveInfinity;
                for (int i = 0; i < ds.Count - 1; i++)
                {
                    node from = ds[i];
                    node to = ds[i + 1];

                    List<edge> es = _fg.get_edge_from_node(from, to);
                    if (es.Count > 0)
                    {
                        edge e = es[0];
                        max_path_flow = Math.Min(e.Capacity, max_path_flow);
                    }
                }





                for (int i = 0; i < ds.Count - 1; i++)
                {
                    node from = ds[i];
                    node to = ds[i + 1];


                    List<edge> es = _fg.get_edge_from_node(from, to);
                    if (es.Count > 0)
                    {
                        edge e = es[0];
                        e.Flow += max_path_flow;
                        e.Capacity = e.Capacity - max_path_flow;


                        List<edge> es_rev = _fg.get_edge_from_node(to, from);
                        if (es_rev.Count > 0)
                        {
                            edge e_rev = es_rev[0];
                            e_rev.Flow -= max_path_flow;
                            if (e_rev.Flow < 0.0)
                            {
                                e_rev.Flow = 0.0;
                            }

                            e_rev.Capacity = e_rev.Capacity + max_path_flow;
                        }

                    }



                }
                //SET NEW TOTAL FLOW FOR GRAPH
                _fg.MaxFlow = _fg.MaxFlow + max_path_flow;
                //GET NEW PATH FOR NEXT INTERATION
                ds = breadth_first_search(_fg, _start, _target, null, true);
            }
            return _fg;
        }

        public static previous_structure bellman_ford(graph _g, node _s)
        {



            previous_structure tree = new previous_structure(_g.node_count(), _s);

            List<edge> edges = _g.get_all_edges();
            //FOR EACH EDGE SET PREVIOUS
            for (int i = 1; i < _g.node_count(); i++)
            {
                foreach (edge e in edges)
                {
                    if (e.Capacity > 0.0)
                    {
                        node from = e.From;
                        node to = e.To;
                        double costs_edge = e.Costs;

                        double current_distance = tree.get_distance(to);
                        double new_distance = tree.get_distance(from) + costs_edge;
                        //RELAX
                        if (new_distance < current_distance)
                        {
                            tree.set_previous(to, from, new_distance);
                        }
                    }
                }
            }

            //FOR EACH EDGE CHECK NEGATIVE CYCLE
            foreach (edge e in edges)
            {
                if (e.Capacity > 0.0)
                {
                    double weigth_from = tree.get_distance(e.From);
                    double weigth = e.Costs;
                    double weigth_to = tree.get_distance(e.To);
                    //CHECK THE TRIANGLE
                    if ((weigth_from + weigth) < weigth_to)
                    {
                        tree.set_to_negative_cycle();
                        tree.construct_negative_cycle(e.From, _g);
                        return tree;
                    }
                }
            }

            return tree;
        }

        public static previous_structure djikstra(graph _g, node _startnode)
        {
            previous_structure tree = new previous_structure(_g.node_count(), _startnode);
            bool[] visited = new bool[_g.node_lookup.Count];
            PriorityQueue<node, double> queue = new PriorityQueue<node, double>();

            //STARTNODE TO THEMSELF = DISTANCE 0
            //
            queue.Enqueue(_startnode, 0.0);
            while (queue.Count > 0)
            {
                node min = queue.Dequeue();
                if (visited[min.Id]) { continue; }
                visited[min.Id] = true;
                foreach (edge e in _g.get_edge_from_node(min, null))
                {
                    node target = e.getTarget(min);
                    if (!visited[target.Id])
                    {
                        double costs = (e.Costs + tree.get_distance(min));
                        if (tree.get_distance(target) > costs)
                        {
                            tree.set_previous(target, min, costs);
                            queue.Enqueue(target, tree.get_distance(target));
                        }


                    }
                }
            }
            System.Console.WriteLine(tree.ToString());
            return tree;
        }

        static public graph kruskal(graph _g)
        {
            graph gres = new graph();
            group_handler goups = new group_handler(_g.get_all_nodes());
            PriorityQueue<edge, double> pq = new PriorityQueue<edge, double>();
            double costs = 0.0;
            //FÜGE ALLE KANTEN IN DIE PRIO QUEUE HINZU
            foreach (edge e in _g.get_all_edges())
            {
                pq.Enqueue(e, e.Costs);
            }
            //SOLANGE NOCH UNBESUCHTE KANTEN
            while (pq.Count > 0)
            {
                edge e = pq.Dequeue();
                node from = e.From;
                node to = e.To;
                //SCHAUE OB KANTEN IN VERSCHIEDENEN GRUPPEN
                int group_1 = goups.getGroupId(from);
                int group_2 = goups.getGroupId(to);
                if (group_1 != group_2)
                {
                    //WENN VERSCHIEDEN
                    //VEREINIGE DIE GRUPPEN
                    goups.unionGroups(from, to);
                    gres.add_edge(e);
                    costs += e.Costs;
                }
            }
            return gres;
        }

        static public graph prim(graph _g, node _start)
        {
            PriorityQueue<edge, double> q = new PriorityQueue<edge, double>();
            List<edge> edges = new List<edge>();
            bool[] visited = new bool[_g.node_lookup.Count];
            double total_costs = 0.0f;
            //MST GRAPH
            graph gres = new graph();
            //ADDE ALLE KANTEN DES STARTKNOTEN
            visited[_start.Id] = true;
            foreach (edge e in _start.get_edges())
            {
                q.Enqueue(e, e.Costs);
            }
            //SOLANGE LISTE NICHT LEER
            while (q.Count > 0)
            {
                //HOLE KANTE MIT DEM KLEINSTEN GEWICHT
                edge e = q.Dequeue();
                //CHECK FOR VISIS
                bool target_visited = visited[e.To.Id];
                //CHECK ONE UNVISITED VISITED
                if (!target_visited)
                {
                    //FÜR ALLE KANTEN DES ZIELKNOTENS
                    foreach (edge ea in _g.get_edge_from_node(e.To, null))
                    {
                        //PRÜFE OB ZIEL BEREITS BESUCHT
                        bool new_target_visited = visited[ea.To.Id];
                        //SONST FÜGE KANTE HINZU
                        if (!new_target_visited)
                        {
                            q.Enqueue(ea, ea.Costs);
                        }
                    }
                    //MARKIERE ZIEL ALS BESUCHT
                    visited[e.To.Id] = true;
                    //ADD WIGTH
                    total_costs += e.Costs;
                    //ADD EDGES TO LIST FOR GRAPH RECONSTRUCTION
                    gres.add_edge(e.From.Id, e.To.Id, e.Costs);
                }
            }
            return gres;
        }

        public static route branch_and_bound(graph _g)
        {
            //CALL BRUTEFORCE WITH B&B CHECK SET TO TRUE
            return bruteForceRoute(_g, true);
        }

        public static route bruteForceRoute(graph _g, bool _check_branch_and_bound)
        {
            route cheapest = new route();
            List<node> unvisited = _g.get_all_nodes();
            node s = unvisited.First(); // Startknoten
            unvisited.RemoveAt(0);
            //same as 128
            for (int i = 0; i < unvisited.Count(); i++)
            {
                node n = unvisited.First();
                unvisited.RemoveAt(0);

                route r = route.addEdgeToRoute(new route(), s, n, _g, false);
                //CHECK IF NEW GENERATED ROUTE IS CHEAPTER THAN THE LAST ONE
                //STORE THIS AS THE NEW CHEAPEST
                if (!_check_branch_and_bound || route.checkCheapestRoute(r, cheapest))
                {
                    cheapest = permutationBrusteForce(_g, r, unvisited, cheapest, _check_branch_and_bound);
                }
                unvisited.Add(n);
            }
            return cheapest;
        }

        private static route permutationBrusteForce(graph _g, route _r, List<node> _unvisited, route cheapest, bool _check_branch_and_bound)
        {
            //END OF THE RECURSION
            //IF NO NODE IS AVAILABLE RETURN AND CONNECT START TO END
            //ALSO CHECK IF THIS ROUTE IS THE CHEAPEST
            if (_unvisited.Count() <= 0)
            {
                _r.connect_start_end(_g);
                if (route.checkCheapestRoute(_r, cheapest))
                {
                    return _r;//neue route komplett anlegen
                }
                else
                {
                    return cheapest;
                }
            }
            else
            {
                //FOR EACH NEXT POSSIBILITY
                //CALL THE RECOURSIVE FUNCTION AGAIN
                //
                for (int i = 0; i < _unvisited.Count(); i++)
                {
                    node n = _unvisited.First();
                    _unvisited.RemoveAt(0);
                    //nur eine route
                    //remove kante route
                    //anstatt 
                    route newRoute = new route(_r);
                    newRoute.addEdgeToRoute(_r.get_last_node(), n, _g, false);

                    //CHECK COSTS
                    //
                    if (!_check_branch_and_bound || route.checkCheapestRoute(newRoute, cheapest))
                    {
                        cheapest = permutationBrusteForce(_g, newRoute, _unvisited, cheapest, _check_branch_and_bound);
                    }
                    _unvisited.Add(n);
                }
                return cheapest;
            }
        }

        public static route double_tree(graph _g, node _s)
        {
            route rres = new route();
            graph mst = prim(_g, _s);

            List<List<node>> all_dfs = getDepthFirstSearchTreesNode(mst);
            //CHECK FOR AT LEAST ONE RELATION COMPONENT
            if (all_dfs.Count <= 0)
            {
                throw new Exception("no relation compontens present");
            }
            List<node> dfs = all_dfs[0];
            bool[] visited = new bool[mst.node_count()];
            node last_visited = null;




            for (int i = 0; i < dfs.Count - 1; i++)
            {
                node from = dfs[i];
                node to = dfs[i + 1];

                if (!visited[from.Id] && !visited[to.Id])
                {
                    rres.addEdgeToRoute(from, to, _g, true);
                    last_visited = to;
                    ///nie vorkommt => STARTCASE
                }
                else if (!visited[from.Id])
                {
                    rres.addEdgeToRoute(last_visited, from, _g, true);
                    last_visited = from;

                }
                else if (!visited[to.Id])
                {
                    rres.addEdgeToRoute(last_visited, to, _g, true);
                    last_visited = to;
                }

                visited[from.Id] = true;
                visited[to.Id] = true;
            }



            //TO CREATE A COMPLETE CIRCLE
            //CONNECT START AND END

            rres.connect_start_end(_g);
            rres.ToString();
            return rres;
        }

        public static route nearest_neighbour(graph _g, node _start_node)
        {

            PriorityQueue<edge, double> pq = new PriorityQueue<edge, double>();
            route rres = new route();
            bool[] visited = new bool[_g.node_count()];

            visited[_start_node.Id] = true;
            node actual = _start_node;
            while (rres.count_edges() < _g.node_count() - 1)
            {
                //CLEAR PQ AND BUILD NEW PW WITH EDGES FROM NEW NODE
                pq.Clear();
                foreach (edge pqe in _g.get_edge_from_node(actual, null))
                {
                    pq.Enqueue(pqe, pqe.Costs);
                }
                //FIND THE NEXT UNVISITED NODE IN PQ LIST
                // IN PQ THE CHEAPEST IS THE BEST

                ///nur cheapest holen und damit checken auf visted
                ///direkt die kante
                ///route auf kante
                edge e = null;
                node target_node = null;
                do
                {
                    if (pq.Count == 0) { break; }
                    e = pq.Dequeue();

                    target_node = e.To;
                } while (visited[target_node.Id]);


                visited[target_node.Id] = true;
                //ADD THE NEW TARGET NODE THE ROUTE
                rres.addEdgeToRoute(actual, target_node, _g, false);
                actual = target_node;
            }
            //ADD STARTNODE AT THE END
            rres.addEdgeToRoute(actual, _start_node, _g, false);

            return rres;
        }

        public static int getRelatedComponents(graph _g)
        {
            return getDepthFirstSearchTreesNode(_g).Count;

        }

        public static int corelaationComponentCount(graph _g)
        {
            if (_g.Directed)
            {
                return getDepthFirstSearchTreesNode(_g).Count() / 2;
            }
            else
            {
                return getDepthFirstSearchTreesNode(_g).Count();
            }

        }

        public static List<List<node>> getDepthFirstSearchTreesNode(graph _g)
        {

            List<List<node>> trees = new List<List<node>>();
            bool[] visited = new bool[_g.node_count()];
            List<node> known_nodes = _g.get_all_nodes();

            foreach (node node in known_nodes)
            {
                if (!visited[node.Id])
                {

                    Stack<node> stack = new Stack<node>();
                    List<node> edges = new List<node>();

                    stack.Push(node);
                    visited[node.Id] = true;

                    while (stack.Count > 0)
                    {
                        node n = stack.Pop();
                        //  System.Console.Out.WriteLine("pop:" + n.Id);
                        edges.Add(n);
                        visited[n.Id] = true;

                        List<edge> edges2 = _g.get_edge_from_node(n, null);
                        foreach (edge e in edges2)
                        {
                            node? target = e.getTarget(n);
                            if (target == null) { continue; }

                            if (!visited[target.Id])
                            {
                                stack.Push(target);
                                visited[target.Id] = true;
                            }
                        }
                    }

                    trees.Add(edges);
                }
            }
            return trees;
        }

        public static List<node> breadth_first_search(graph _g, node _start, node _target, visited_handler _visited, bool _allow_only_positive_capacity = false)
        {
            List<node> res = new List<node>();
            Queue<node> queue = new Queue<node>();

            if (_visited == null)
            {
                _visited = new visited_handler(_g.node_count());
            }

            queue.Enqueue(_start);
            _visited.set_visited(_start);
            predesessor pre = new predesessor(_g, _start);

            while (queue.Count > 0)
            {
                node actual = queue.Dequeue();
                foreach (edge e in _g.get_edge_from_node(actual, null))
                {
                    node target = e.getTarget(actual);
                    if (_visited.is_not_visited(target) && (e.Capacity > 0.0 || !_allow_only_positive_capacity))
                    {
                        _visited.set_visited(target);
                        queue.Enqueue(target);
                        pre.setPrevNode(target, actual);
                        if (_target != null && target.Id == _target.Id)
                        {
                            node tmp = target;
                            while (!tmp.Id.Equals(_start.Id))
                            {
                                res.Insert(0, tmp);
                                tmp = pre.getPrevNode(tmp);
                            }
                            res.Insert(0, tmp);
                            return res;
                        }
                    }
                }
            }

            return res;
        }
    }
}
