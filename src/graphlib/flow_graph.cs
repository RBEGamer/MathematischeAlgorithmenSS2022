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
                    edge rev = new edge(e.To, e.From, -e.Costs);
                    rev.Capacity = 0;
                    rev.IsResidualEdge = true;
                    e.To.add_edge(rev);
                }

            }
        }

        public bool load_flow_graph_from_file(string _file)
        {
            if (!File.Exists(_file))
            {
                throw new FileNotFoundException(_file + " not found");
            }

            this.Directed = true;

            var lines = File.ReadAllLines(_file);

            int imported_lines = 0;
      
            if (lines.Length >= 1)
            {
                int node_count = int.Parse(lines[0]);

                for(int i = 1; i < node_count+1; i++)
                {
                    node n = new node(i-1);
                   // System.Console.WriteLine(n);
                    n.Balance = double.Parse(lines[i], CultureInfo.InvariantCulture) * 1.0;
                    add_node(n);
                }
                    //ADD NODES
                   
 
                for (int i = node_count+1; i < lines.Length; i++)
                {

                 

                    var sp = lines[i].Split('\t');
                    //NORMAL EDGE
                    if (sp.Length >= 2)
                    {
                        int from = int.Parse(sp[0]);
                        int to = int.Parse(sp[1]);


                        edge edge_forward = new edge(get_node_with_id(from), get_node_with_id(to));


                        //ADD WEIGHT
                        if (sp.Length >= 3)
                        {
                            double w = double.Parse(sp[2], CultureInfo.InvariantCulture) * 1.0;
                            edge_forward.Costs = w;
                            
                        }

                        if (sp.Length >= 4)
                        {
                            double c = double.Parse(sp[3], CultureInfo.InvariantCulture) * 1.0;
                            edge_forward.Capacity = c;
                        }

                        


                        //ADD DIRECTED
                        add_edge(edge_forward);
   
                        imported_lines++;
                    }
                }
            }
            return true;
        }

            public void convert_costs_to_capacity()
        {
            foreach (edge e in get_all_edges())
            {
                e.Capacity = e.Costs;
            }
        }


        public flow_graph() : base()
        {
            Directed = true;
        }



    }
}
