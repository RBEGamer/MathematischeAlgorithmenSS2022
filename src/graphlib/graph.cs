using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace graphlib
{
    public class graph
    {

        private List<node> nodes;

        public List<node> Nodes { get => nodes; }

        public graph()
        {
            nodes = new List<node>();
        }

        public graph(graph _g)
        {
            nodes = _g.nodes;
        }

        public void sort_nodes_by_id()
        {
            nodes.Sort();
        }


        public void remove_duplicate_nodes()
        {
            nodes.Distinct().ToList().ForEach(node => nodes.Remove(node));
        }
        public bool load_from_file(string _file)
        {
            if (!File.Exists(_file))
            {
                throw new FileNotFoundException(_file + " not found");
                return false;
            }

            var lines = File.ReadAllLines(_file);

            int imported_lines = 0;
            if(lines.Length > 1)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    var sp = lines[i].Split('\t');
                    //NORMAL EDGE
                    if(sp.Length >=2)
                    {
                        node from = new node(int.Parse(sp[0])); //FROM
                        node to = new node(int.Parse(sp[1])); //TO

                        edge ed = new edge(from, to, false);
                        
                        //ADD WEIGHT
                        if (sp.Length >= 3){
                            ed.Weigth = float.Parse(sp[2]);
                        }

                        //ADD STUFF
                        add_node(to, true);
                        add_node(from, true);
                        add_edge(ed);

                        //     Console.WriteLine(ed.ToString());
                        //WEIGHTED EDGE
                        imported_lines++;
                    }
                   
                    else
                    {

                    }
                }
            }
            
            sort_nodes_by_id();


            bool import_ok = true;
            if(int.Parse(lines[0]) != node_count())
            {
                import_ok = false;
            }

            if (imported_lines != edge_count())
            {
                import_ok = false;
            }


            return import_ok;
        }


        public bool add_edge(edge _e)
        {
           

            if (!nodes.Contains(_e.To))
            {
                throw new IndexOutOfRangeException("_e.To node did not exists:" +  _e.ToString());
                return false;
            }
            if (!nodes.Contains(_e.From))
            {
                throw new IndexOutOfRangeException("_e.From node did not exists:" + _e.ToString());
                return false;
            }


            node? nd = null;
            foreach(var node in nodes)
            {
                if (node.Equals(_e.From)){
                    nd = node;
                    break;
                }
            }

            if(nd != null)
            {
                nd.add_edge(_e);
            }

            
            return true;
        }

        public bool add_node(node _n, bool check_exists = true)
        {


            if(check_exists && nodes.Contains(_n))
            {
                return false;
            }
            nodes.Add(_n);

            return true;
        }

        public bool remove_node(node _n)
        {
            return nodes.Remove(_n);
        }

        public bool contains_node(node _n)
        {
            return nodes.Contains(_n);
        }

        public bool contains_node_id(int _node_id)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Id == _node_id) { return true; }       
            }
            return false;
        }


        public int node_count()
        {
            return nodes.Count;
        }

        public int edge_count()
        {
            return get_all_edges().Count;
        }

        public List<edge> get_edge_from_node(node _from, node? _to)
        {
            List<edge> result = new List<edge>();
            //FIND NODE
    
            foreach (node n in nodes)
            {
                if (n.Equals(_from))
                {
                    //ADD ALL EDGES
                    if(_to == null)
                    {
                        result.AddRange(n.get_edges());
                    }
                    else
                    {
                        result.AddRange(n.get_edges_to(_to));
                    }
                    

                }
            }

        
            if(result.Count == 0)
            {
                throw new Exception("get_edge_from_node: FROM NODE NOT FOUND");
            }
            return result;

        }

        public List<edge> get_all_edges()
        {
            List<edge> result = new List<edge>();

            foreach (node n in nodes)
            {
                result.AddRange(n.get_edges());
            }

            
            
            return result;
        }


        public override String ToString()
        {
            string tmp = "";
            foreach (node n in nodes)
            {
                
                tmp += n.ToString() + "\n";
            }

            return tmp; 
        }


        public void set_all_visited()
        {
            foreach(node n in nodes)
            {
                n.Visited = true;
            }
        }

        public void set_all_unvisited()
        {
            foreach (node n in nodes)
            {
                n.Visited = false;
            }
        }

        
        public int count_visited()
        {
           return get_visited().Count();
        }

        public int count_unvisited()
        {
            return get_unvisited().Count();
        }

        public List<node> get_unvisited()
        {
            List<node> result = new List<node>();
            foreach (node n in nodes)
            {
                if (!n.Visited)
                {
                    result.Add(n);
                }
            }
            return result;
        }

        public List<node> get_visited()
        {
            List<node> result = new List<node>();
            foreach (node n in nodes)
            {
                if (n.Visited)
                {
                    result.Add(n);
                }
            }
            return result;
        }


    }
}
