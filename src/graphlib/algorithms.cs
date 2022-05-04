using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace graphlib
{
    public class algorithms
    {




        static public graph Kruskal(ref graph _g)
        {
            graph gres = new graph();
            GroupHandler goups = new GroupHandler(_g.get_all_nodes());
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



        static public graph Prim(ref graph _g, node _start)
        {
            PriorityQueue<edge, float> q = new PriorityQueue<edge, float>();
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

      





        public static int getRelatedComponents(graph _g)
        {
            return getDepthFirstSearchTrees(_g).Count;

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
