using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace graphlib
{
    public class algorithms
    {



        static public graph Kruskal(graph _g)
        {
            PriorityQueue<edge, float> q = new PriorityQueue<edge, float>();
            bool[] visited = new bool[_g.node_lookup.Count];
            List<edge> edges = new List<edge>();
            graph gres = new graph();

            Dictionary<int,List<node>> component_lookup = new Dictionary<int, List<node>>();
            float costs = 0.0f;

            int component_id = 0;
            //ADD ALL EDGES
            foreach(edge e in _g.get_all_edges())
            {
                q.Enqueue(e,e.Weigth);
            }

            while(q.Count > 0)
            {
                edge e = q.Dequeue();
                node source = e.From;
                node target = e.To;
                //CHECK FOR VISIS
                bool source_visited = visited[source.Id];
                bool target_visited = visited[target.Id];

                if(!source_visited && !target_visited)
                {
                    visited[source.Id] = true;
                    visited[target.Id] = true;

                    costs += e.Weigth;

                    edges.Add(e);
                    component_lookup.Add(component_id, new List<node>());

                    component_lookup[component_id].Add(source);
                    component_lookup[component_id].Add(target);
                    component_id++;

                 //ONLY ONE VISITED
                }else if(source_visited != target_visited)
                {

                }
            }

            return gres;
        }
        static public graph Prim(graph _g, node _start) {


            PriorityQueue<edge, float> q = new PriorityQueue<edge, float>();
            List<edge> edges = new List<edge>();
            bool[] visited = new bool[_g.node_lookup.Count];
           
            graph gres = new graph();
            visited[_start.Id] = true;

            float total_costs = 0.0f;
            foreach(edge e in _start.get_edges()){
                q.Enqueue(e, e.Weigth);
            }

            while (q.Count > 0)
            {
                //GET WEIGTH LEIGHTES EDGE
                edge e = q.Dequeue();
                node source = e.From;
                node target = e.To;
                //CHECK FOR VISIS
                bool source_visited = visited[source.Id];
                bool target_visited = visited[target.Id];
                //BOTH VISITED
                if(source_visited && target_visited)
                {
                    continue;
                }

                node node_to_process = source;
                if (source_visited)
                {
                    node_to_process = target;
                }
                //MARK NODE ASS PROCESSED
                visited[node_to_process.Id] = true;

                foreach (edge ea in node_to_process.get_edges()){   
                       q.Enqueue(ea, ea.Weigth);     
                 }

                //ADD WIGTH
                total_costs += e.Weigth;
                //ADD EDGES TO LIST FOR GRAPH RECONSTRUCTION
                edges.Add(e);
               

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

        public static double calculateWeigth(graph g)
        {
            double costs = 0.0;
            foreach (edge e in g.get_all_edges())
            {
                    costs +=  e.Weigth;        
            }
            return costs;
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

                    if(group_found < 0)
                    {
                        group_id++; //NEUE GROUP ID
                        group_found = group_id;
                    }

                    if(group_count < group_found)
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
