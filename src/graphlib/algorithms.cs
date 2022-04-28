using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace graphlib
{
    public class algorithms
    {

        private static double calculateMinMaxCosts(ref graph g)
        {
            double costs = 0.0;
            foreach (edge e in g.get_all_edges())
            {
                    costs += (e.Weigth);    
            }
            return costs;
        }

        static public graph Kruskal(ref graph _g)
        {
            graph gres = new graph();
            GroupHandler goups = new GroupHandler(_g.get_all_nodes());
            PriorityQueue<edge, double> pq = new PriorityQueue<edge, double>();
            List<edge> edges = new List<edge>();
            double costs = 0.0;

          foreach(edge e in _g.get_all_edges())
            {
                pq.Enqueue(e, e.Weigth);
            }

            while(pq.Count > 0)
            {
                edge e = pq.Dequeue();
                node from = e.From;
                node to = e.To;

                int group_1 = goups.getGroupId(from);
                int group_2 = goups.getGroupId(to);
                if(group_1 != group_2)
                {
                    goups.unionGroups(from, to);
                    gres.add_edge(e);
                    edges.Add(e);
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

            graph gres = new graph();
            visited[_start.Id] = true;

            float total_costs = 0.0f;
            //ADDE ALLE KANTEN DES STARTKNOTEN
            foreach (edge e in _start.get_edges())
            {
                q.Enqueue(e, e.Weigth);
            }
            //SOLANGE LISTE NICHT LEER
            while (q.Count > 0)
            {


                //HOLE KANTE MIT DEM KLEINSTEN GEWICHT
                edge e = q.Dequeue();

               // node target = e.To;
                //CHECK FOR VISIS
                bool target_visited = visited[e.To.Id];
                //CHECK ONE UNVISITED VISITED
                if (!target_visited)
                {

                    //System.Console.WriteLine(e);
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
                    edges.Add(e);

                }
            }
            //BUILD GRAPH
            foreach (edge e in edges)
            {
                gres.add_node(e.To);
                gres.add_node(e.From);
                gres.add_edge(e);
            }

            return gres;
        }

        static public int CreateCorrelationComponentGroups(ref graph _g)
        {
            System.Console.WriteLine("--------------------------------");
            System.Console.WriteLine("CreateCorrelationComponentGroups");
            System.Console.WriteLine("--------------------------------");
            int group_count = 0;

            _g.set_all_unvisited();
            _g.ungroup_all();
            node start_node = _g.get_unvisited().ElementAt(0);
            //START NODE = GROUP ID

            int group_id = 0;

            //AVOID WHILE
            for (int i = 0; i < _g.get_unvisited().Count; i++)
            {
                //PERFORM DEPTH SEARCH REPEAT FOR NEXT UNVISITED

                List<node> found_nodes = getDepthFirstSearchTrees(ref _g, _g.get_unvisited().ElementAt(0));
                if (found_nodes.Count > 0)
                {

                    //prüfe ob eine node bereits in einer node gruppe ist
                    int group_found = 0;

                    foreach (node nc in found_nodes)
                    {
                        if (!nc.is_in_group())
                        {
                            group_found = nc.Group_id; //SET ID
                            break;
                        }
                    }

                    if (group_found < 0)
                    {
                        group_id++; //NEUE GROUP ID
                        group_found = group_id;
                    }

                    if (group_count < group_found)
                    {
                        group_count = group_found;
                    }
                    //ALLE NODES DER NEUEN GRUPPE ZUWEISEN
                    foreach (node nc in found_nodes)
                    {
                        nc.set_group((uint)group_found);
                    }

                }
            }

            return group_count;
        }

        static public int getCorrelationComponents(graph _g)
        {
            System.Console.WriteLine("------------------------");
            System.Console.WriteLine("getCorrelationComponents");
            System.Console.WriteLine("------------------------");

            graph tmp_g = new graph(_g);


            tmp_g.set_all_unvisited();

            int result = 0;

            //AVOID WHILE
            foreach (node n in _g.get_unvisited())
            {
                List<node> vs = getDepthFirstSearchTrees(ref tmp_g, n);
                if (vs.Count > 0)
                {
                    result++;
                }
            }


            return result;
        }







        public static List<node> getDepthFirstSearchTrees(ref graph _g, node _start)
        {

            List<node> depthFirstSearchTrees = new List<node>();

            if (_start.Visited)
            {
                return depthFirstSearchTrees;
            }


            Stack<int> stack = new Stack<int>();
            stack.Push(_start.Id);



            while (stack.Count > 0)
            {


                int sid = stack.Pop();
                node s = _g.node_lookup[sid];
                if (s == null)
                {
                    break;
                }

                if (!s.Visited)
                {
                    depthFirstSearchTrees.Add(s);
                    s.Visited = true;


                    //GET NEIGHBOURS
                    foreach (node e in s.get_directed_neighbours())
                    {
                        //IS MY EDGE AND DIRECTEC => ADD ONLY ONE
                        if (!e.Visited)
                        {
                            stack.Push(e.Id);
                        }
                    }
                }
            }
            return depthFirstSearchTrees;
        }


    }
}
