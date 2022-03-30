using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace graphlib
{
    public class algorithms
    {


        static public void CreateCorrelationComponentGroups(ref graph _g)
        {
            System.Console.WriteLine("--------------------------------");
            System.Console.WriteLine("CreateCorrelationComponentGroups");
            System.Console.WriteLine("--------------------------------");

           
            _g.set_all_unvisited();
            _g.ungroup_all();
            node start_node = _g.get_unvisited().ElementAt(0);
            //START NODE = GROUP ID

            int group_id = 0;

            //AVOID WHILE
            for (int i = 0; i < _g.get_unvisited().Count; i++)
            {
                //PERFORM DEPTH SEARCH REPEAT FOR NEXT UNVISITED

                List<node> found_nodes = getDepthFirstSearchTrees(_g, _g.get_unvisited().ElementAt(0), false, false);
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

                    //ALLE NODES DER NEUEN GRUPPE ZUWEISEN
                    foreach (node nc in found_nodes)
                    {
                        nc.set_group((uint)group_found);
                    }

                }
            }

           
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
            for (int i = 0; i < tmp_g.get_unvisited().Count; i++)
            {
                //PERFORM DEPTH SEARCH REPEAT FOR NEXT UNVISITED
                if(getDepthFirstSearchTrees(tmp_g, tmp_g.get_unvisited().ElementAt(0), false, false).Count > 0)
                {
                    result++;
                }
            }

            return result;
        }


        public static List<node> getDepthFirstSearchTrees(graph _g, node _start, bool _copy, bool _startover)
        {
            System.Console.WriteLine("------------------------");
            System.Console.WriteLine("getDepthFirstSearchTrees");
            System.Console.WriteLine("------------------------");

            List<node> depthFirstSearchTrees = new List<node>();

            //COPY GRAPTH
            graph tmp_g = _g;
            node tmp_start = _start;
            if (_copy)
            {
                tmp_g = new graph(_g);
                tmp_start = new node(_start);
            }


            if (_startover)
            {
                tmp_g.set_all_unvisited();
            }
            


            Stack<node> stack = new Stack<node>();
            stack.Push(tmp_start);

            bool finished = false;

            while (stack.Count > 0 && !finished)
            {
                finished = getDepthFirstSearchTreesStep(ref tmp_g, ref stack, ref depthFirstSearchTrees);
            }

            
            return depthFirstSearchTrees;
        }

        public static bool getDepthFirstSearchTreesStep(ref graph _g, ref Stack<node> _stack, ref List<node> _tree)
        {

            if(_stack.Count <= 0)
            {
                return true;
            }

            node s = _stack.Pop();
            System.Console.WriteLine(s.ToString());
            if (!s.Visited)
            {
                _tree.Add(s);
                s.Visited = true;


                foreach(edge e in _g.get_all_edges())
                {
                    //DIRECTED

                    if (e.Directed && e.From.Equals(s)) 
                    {
                        _stack.Push(e.To);
                    }
                    else if(!e.Directed)
                    {
                        //ADD OTHER SIDE TO STACK
                        //THIS ALLOWS LOOP EDGE ALSO
                        if (e.From.Equals(s))
                        {
                            _stack.Push(e.To);
                        }

                        if (e.To.Equals(s))
                        {
                            _stack.Push(e.From);
                        }
                        
                    }
                    
                   
              
                }
                
            }
            
            Console.WriteLine("----- STACK ------");
            foreach(node e in _stack.ToArray())
            {
                Console.WriteLine(e.Id.ToString());
            }
            Console.WriteLine("----- END-STACK ------");
            return false;
        }
    }
}
