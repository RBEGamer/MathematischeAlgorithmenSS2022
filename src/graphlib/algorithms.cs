using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace graphlib
{
    public class algorithms
    {




        static public graph kruskal(ref graph _g)
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



        static public graph prim(ref graph _g, node _start)
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
                    gres.add_edge(e);
                }
            }
           return gres;
        }

      

        public static route double_tree(graph _g, node _s)
        {
            route rres = new route();



            return rres;
                ;
        }
        public static route nearest_neighbour(graph _g, node _start_node) {
        
            PriorityQueue<edge, double> pq = new PriorityQueue<edge, double>();
            route rres = new route();
            bool[] visited  = new bool[_g.node_count()];

            visited[_start_node.Id] = true;
            node actual = _start_node;
            while(rres.count_edges() < _g.node_count() - 1)
            {
                pq.Clear();
                foreach(edge pqe in _g.get_edge_from_node(actual, null))
                {
                    pq.Enqueue(pqe, pqe.Weigth);
                }

                edge e = null;
                node target_node = null;
                do
                {
                    e = pq.Dequeue();
                    target_node = e.To;
                } while(visited[target_node.Id]);

                visited[target_node.Id] = true;
                rres.addEdgeToRoute(actual, target_node, _g);
                actual = target_node;
            }
            //ADD STARTNODE AT THE END
            rres.addEdgeToRoute(actual,_start_node, _g);
            



            return rres;
        }


        public static int getRelatedComponents(graph _g)
        {
            return getDepthFirstSearchTrees(_g).Count;

        }


        public static List<node> go_breadth_first_search(graph _g, node _start_node, node _target,visited_handler _vh)
        {
            List<node> gres = new List<node>();
            Queue<node> q = new Queue<node>();

            if(_vh == null)
            {
                _vh = new visited_handler(_g.node_count());
            }
            q.Enqueue(_start_node);
            _vh.set_visited(_start_node);
            predesessor pre = new predesessor(_g, _start_node);


            while(q.Count > 0)
            {
                node actual = q.Dequeue();

                foreach(edge e in _g.get_edge_from_node(actual, null)){
                    node target = e.To;

                    if (_vh.is_not_visited(target))
                    {
                        _vh.set_visited(target);
                        q.Enqueue(target);
                        pre.setPrevNode(target, actual);
                        if (target.Equals(_target))
                        {
                            node tmp = target;
                            while (!tmp.Equals(_start_node))
                            {
                                gres.Insert(0, tmp);
                                tmp = pre.getPrevNode(tmp);
                            }
                            gres.Insert(0, _start_node);
                            return gres;
                        }
                    }
                }
            }

            return gres;
        }



        public static List<List<edge>> getDepthFirstSearchTrees(graph _g)
        {

            List<List<edge>> trees = new List<List<edge>>();
            bool[] visited = new bool[_g.node_count()];
            List<node> known_nodes = _g.get_all_nodes();

            foreach (node node in known_nodes)
            {
                if (visited[node.Id]) { continue; }
                visited[node.Id] = true;
                Stack<node> stack = new Stack<node>();
                List<edge> edges = new List<edge>();
                
                stack.Push(node);

                while(stack.Count > 0)
                {
                    node n = stack.Pop();
                    visited[n.Id] = true;
                    List<edge> edges2 = _g.get_edge_from_node(n, null);

                    foreach(edge e in edges2)
                    {
                        if (visited[e.To.Id]) { continue;}
                        edges.Add(e);
                        stack.Push(e.To);
                        visited[e.To.Id] = false;
                    }
                }
                trees.Add(edges);
                
            }

            return trees;
        }


    }
}
