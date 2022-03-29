using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace graphlib
{
    public class algorithms
    {

        public static List<node> getDepthFirstSearchTrees(graph _g, node _start)
        {
            System.Console.WriteLine("------------------------");
            System.Console.WriteLine("getDepthFirstSearchTrees");
            System.Console.WriteLine("------------------------");

            List<node> depthFirstSearchTrees = new List<node>();

            //COPY GRAPTH
            graph tmp_g = new graph(_g);
            node tmp_start = new node(_start);  

            tmp_g.set_all_unvisited();


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
