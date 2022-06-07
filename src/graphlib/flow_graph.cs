using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphlib
{
    public class flow_graph : graph
    {
        private double max_flow = 0;
        private double total_min_max_flow_costs = 0.0;

        public double MaxFlow { get => max_flow; set => max_flow = value; }

        public void create_redisual_graph()
        {
            foreach (edge e in get_all_edges())
            {

                //NO RESIDUAL EDGE
                if (get_edge_from_node(e.To, e.From).Count <= 0)
                {
                    edge rev = new edge(e.To, e.From, -e.Weigth);
                    rev.Capacity = 0;
                    rev.IsResidualEdge = true;
                    e.To.add_edge(rev);
                }

            }
        }

        public bool load_from_file(string _file)
        {
            if (!File.Exists(_file))
            {
                throw new FileNotFoundException(_file + " not found");
            }

            this.Directed = true;

            var lines = File.ReadAllLines(_file);

            int imported_lines = 0;
            int empty_lines = 0;
            if (lines.Length >= 1)
            {
                for (int i = 0; i < lines.Length; i++)
                {

                    if (lines[i] == "")
                    {
                        empty_lines++;
                        continue;
                    }



                    //x=LINE 1
                    //i =X






                    var sp = lines[i].Split('\t');
                    //NORMAL EDGE
                    if (sp.Length >= 2)
                    {
                        node from = new node(int.Parse(sp[0])); //FROM
                        node to = new node(int.Parse(sp[1])); //TO

                        edge edge_forward = new edge(from, to);


                        //ADD WEIGHT
                        if (sp.Length >= 3)
                        {
                            double w = double.Parse(sp[2], CultureInfo.InvariantCulture) * 1.0;
                            edge_forward.Weigth = w;
                        }

                        if (sp.Length >= 4)
                        {
                            double c = double.Parse(sp[3], CultureInfo.InvariantCulture) * 1.0;
                            edge_forward.Capacity = c;
                        }

                        //ADD NODES
                        add_node(to);
                        add_node(from);


                        //ADD DIRECTED
                        add_edge(edge_forward);
   
                        imported_lines++;
                    }
                }
            }
        }

            public void convert_costs_to_capacity()
        {
            foreach (edge e in get_all_edges())
            {
                e.Capacity = e.Weigth;
            }
        }


        public flow_graph() : base()
        {
            Directed = true;
        }



    }
}
