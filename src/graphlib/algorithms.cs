using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace graphlib
{
    public class algorithms
    {


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
