using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace graphlib
{
    public class algorithms
    {


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
