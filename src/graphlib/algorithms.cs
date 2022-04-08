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

                List<node> found_nodes = getDepthFirstSearchTrees(ref _g, _g.get_unvisited().ElementAt(0), false, false);
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
            tmp_g.set_directed(false); // !!!
            tmp_g.set_all_unvisited();

            int result = 0;

            //AVOID WHILE
            foreach (int n in tmp_g.get_node_ids())
            {
                List<node> vs = getDepthFirstSearchTrees(ref tmp_g, tmp_g.node_lookup[n], false, false);
                if (vs.Count > 0)
                {
                    result++;
                }
            }
            

            return result;
        }




        


        public static List<node> getDepthFirstSearchTrees(ref graph _g, node _start, bool _copy, bool _startover)
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
            


            Stack<int> stack = new Stack<int>();
            stack.Push(tmp_start.Id);

            bool finished = false;

            while (stack.Count > 0 && !finished)
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
                    _g.node_lookup[sid].Visited = true;

                    //FOR EACH EGDE IN GRPAH
                    List<edge> ed = _g.node_lookup[sid].get_edges();
                    if (!tmp_g.Directed)
                    {
                        ed = tmp_g.get_all_edges();
                    }
                    
                    
                    foreach (edge e in ed)
                    {
                        //IS MY EDGE AND DIRECTEC => ADD ONLY ONE
                        if (e.Directed && s.Id == e.From.Id && !e.To.Visited)
                        {

                            stack.Push(e.To.Id);
                        }
                        //IS MY EDGE AND DIRECTEC => ADD BOTH WAYS
                        else
                        {

                            if (s.Id == e.To.Id && !e.From.Visited)
                            {
                                stack.Push(e.From.Id);
                            }

                            if (s.Id == e.From.Id && !e.To.Visited)
                            {
                                stack.Push(e.To.Id);
                            }
                        }
                    }

                }



            }

            
            return depthFirstSearchTrees;
        }

    


        /*
        public static List<node> getDepthFirstSearchTreesSimple(ref graph _g, node _start, node? _goal)
        {
            List<node> res = new List<node>();
            Queue<node> queue = new Queue<node>();
            _g.set_all_unvisited();
            queue.Enqueue(_start);

            _g.get_node_with_id(_start.Id).Visited = true;

            predesessor pre = new predesessor(_g, _start);

            while (queue.Count > 0)
            {
                node actual = queue.Dequeue();
                //ZIELKNOTEN ERREICHT
                if (_goal != null && actual.Equals(_goal))
                {
                    break;
                }

                foreach (edge e in actual.get_edges())
                {


                   


                    node target = e.To;
                    if (!e.To.Visited)
                    {
                       // queue.Enqueue(target);
                        e.To.Visited = true;
                        res.Add(target);


                        //IS MY EDGE AND DIRECTEC => ADD ONLY ONE
                        if (e.Directed && actual.Id == e.From.Id)
                        {
                            queue.Enqueue(e.To);
                        }
                        //IS MY EDGE AND DIRECTEC => ADD BOTH WAYS
                        else
                        {
                            if (actual.Id != e.To.Id && actual.Id == e.From.Id)
                            {
                                queue.Enqueue(e.To);
                            }
                            else if (actual.Id != e.From.Id && actual.Id == e.To.Id)
                            {
                                queue.Enqueue(e.From);
                            }
                        }


                    }
                }
            }
            return res;
        }
        */
    }
}
