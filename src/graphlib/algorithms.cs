using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace graphlib
{
    public class algorithms
    {



        public static previous_structure bellman_ford(graph _g, node _s)
        {
            previous_structure tree = new previous_structure(_g.node_count(), _s);

            List<edge> edges = _g.get_all_edges();
            for (int i = 1; i < _g.node_count(); i++)
            {
                foreach (edge e in edges)
                {
                    
                        node v = e.From;
                        node w = e.To;
                        double ce = e.Weigth;
                        double cw = tree.get_distance(w);
                        double tmpc = tree.get_distance(v) + ce;

                        if (tmpc < cw)
                        {
                            tree.set_distance(w, tmpc);
                            tree.set_previous(w, v);
                        }
                    
                }
            }

            foreach (edge e in edges)
            {
                
                    double cv = tree.get_distance(e.From);
                    double ce = e.Weigth;
                    double cw = tree.get_distance(e.To);
                    if ((cv + ce) < cw)
                    {
                        tree.set_to_negative_cycle();
                       // tree.construct_negative_cycle(e.From, _g);
                        return tree;
                    }
                
            }

            double dd = tree.get_distance(_g.get_node_with_id(2));
            return tree;
        }


        public static previous_structure djikstra(graph _g, node _startnode)
        {
            previous_structure tree = new previous_structure(_g.node_count(), _startnode);
            bool[] visited = new bool[_g.node_lookup.Count];
            PriorityQueue<node, double> queue = new PriorityQueue<node, double>();

            //STARTNODE TO THEMSELF = DISTANCE 0
            queue.Enqueue(_startnode, 0.0);
            while (queue.Count > 0)
            {
               
                node min = queue.Dequeue();
                visited[min.Id] = true;
                foreach (edge e in _g.get_edge_from_node(min, null))
                {
                    node target = e.getTarget(min);
                    if (!visited[target.Id])
                    {
                        double costs = (e.Weigth + tree.get_distance(min));
                        if (tree.get_distance(target) > costs)
                        {
                            tree.set_previous(target, min);
                            tree.set_distance(target, costs);
                        }

                        queue.Enqueue(target, tree.get_distance(target));
                    }
                }
            }
            double c = tree.get_distance(_g.get_node_with_id(0));
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
                pq.Enqueue(e, e.Weigth);
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
                    costs += e.Weigth;
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
                q.Enqueue(e, e.Weigth);
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
                            q.Enqueue(ea, ea.Weigth);
                        }
                    }
                    //MARKIERE ZIEL ALS BESUCHT
                    visited[e.To.Id] = true;
                    //ADD WIGTH
                    total_costs += e.Weigth;
                    //ADD EDGES TO LIST FOR GRAPH RECONSTRUCTION
                    gres.add_edge(e.From.Id, e.To.Id, e.Weigth);
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

        //PERMUTATION
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
                    pq.Enqueue(pqe, pqe.Weigth);
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
                        System.Console.Out.WriteLine("pop:" + n.Id);
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

    }
}
