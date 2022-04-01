﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace graphlib
{
    public class graph
    {

      //  private List<node> nodes;
        public Dictionary<int, node> node_lookup { get; }
        

        public graph()
        {
            //nodes = new List<node>();
            node_lookup = new Dictionary<int, node>();
        }

        public graph(graph _g)
        {
            node_lookup = _g.node_lookup;
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
                        add_node(to);
                        add_node(from);
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
            
           


            bool import_ok = true;
            int nc = node_count();
            int ec = edge_count();
            int nc_check = int.Parse(lines[0]);
            if (nc_check != nc)
            {
             //   import_ok = false;
             //   throw new AggregateException("node create failed");
                
            }

            if (imported_lines != ec)
            {
               // import_ok = false;
              //  throw new AggregateException("edge creation failed");
                
            }


            return import_ok;
        }

        public node? get_node_with_id(int _id)
        {
            return node_lookup[_id];
        }


        public node? get_random_node()
        {
            if(node_lookup.Count <= 0)
            {
                return null;
            }

            return node_lookup.ElementAt(new Random().Next(0, node_lookup.Count)).Value;
        }
        public bool add_edge(edge _e)
        {
           

            if (!contains_node(_e.To))
            {
                throw new IndexOutOfRangeException("_e.To node did not exists:" +  _e.ToString());
            }
            if (!contains_node(_e.From))
            {
                throw new IndexOutOfRangeException("_e.From node did not exists:" + _e.ToString());
            }


             
            //ADD NODE
            if(node_lookup[_e.From.Id] != null)
            {
                node_lookup[_e.From.Id].add_edge(_e);
                return true;
            }

            return false;
        }

        public bool add_node(node _n)
        {
            if(contains_node(_n))
            {
                return false;
            }
            node_lookup.Add(_n.Id, _n);
            return true;
        }

        public bool remove_node(node _n)
        {
            return node_lookup.Remove(_n.Id);
        }

        public bool contains_node(node _n)
        {
            return node_lookup.ContainsKey(_n.Id);
        }

        public bool contains_node_id(int _node_id)
        {
            return node_lookup.ContainsKey(_node_id);
        }


        public int node_count()
        {
            return node_lookup.Count;
        }

        public int edge_count()
        {
            return get_all_edges().Count;
        }

        public List<edge> get_edge_from_node(node _from, node? _to)
        {
          
            if (!contains_node(_from))
            {
                throw new KeyNotFoundException(_from.ToString() + " not found");
            }


            if(_to == null)
            {
                return node_lookup[_from.Id].get_edges();
            }
            else
            {
                return node_lookup[_from.Id].get_edges_to(_to);
            }
        }


        public List<edge> get_all_edges()
        {
            List<edge> result = new List<edge>();

        
            foreach (KeyValuePair<int, node> kv in node_lookup){
                result.AddRange(kv.Value.get_edges());
            }
           
            return result;
        }


        public override String ToString()
        {
            string tmp = "";
            foreach (KeyValuePair<int, node> kv in node_lookup)
            {
                tmp += kv.Value.ToString() + "\n";
            }

            return tmp; 
        }


        public void set_all_visited()
        {
            foreach (KeyValuePair<int, node> kv in node_lookup)
            {
                node_lookup[kv.Key].Visited = true;
            }
        }

        public void set_all_unvisited()
        {
            foreach (KeyValuePair<int, node> kv in node_lookup)
            {
                node_lookup[kv.Key].Visited = false;
            }
        }

        public void ungroup_all()
        {
            foreach (KeyValuePair<int, node> kv in node_lookup)
            {
                node_lookup[kv.Key].ungroup_node();
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
            foreach (KeyValuePair<int, node> kv in node_lookup)
            {
                if (!kv.Value.Visited)
                {
                    result.Add(kv.Value);
                }
            }
            return result;
        }

        public List<node> get_visited()
        {
            List<node> result = new List<node>();
            foreach (KeyValuePair<int, node> kv in node_lookup)
            {
                if (kv.Value.Visited)
                {
                    result.Add(kv.Value);
                }
            }
            return result;
        }


        public int get_group_count()
        {
            return get_group_ids().Count;
        }

        
        public List<KeyValuePair<int, int>> get_group_ids()
        {
            Dictionary<int, int> id_list = new Dictionary<int, int>();
           

            //ADD UP
            foreach (KeyValuePair<int, node> kv in node_lookup)
            {
                if (!id_list.ContainsKey(kv.Value.Group_id)){
                    id_list.Add(kv.Value.Group_id, 1);
                }
                else
                {
                    id_list[kv.Value.Group_id]++;
                }
                
            }


            return id_list.ToList();
        }

         

    }
}
