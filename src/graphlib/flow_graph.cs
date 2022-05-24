using System;
using System.Collections.Generic;
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
