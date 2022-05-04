﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphlib
{
    public class route
    {

        private double route_costs = 0.0;
        private List<edge> edges = new List<edge>();

        public route(route _r)
        {
            foreach(edge e in _r.edges)
            {
                edges.Add(e);
                route_costs += e.Weigth;
            }
        }

        public route()
        {

        }

        public void add_edge(edge _e)
        {
            edges.Add(_e);
            route_costs -= _e.Weigth;
        }

        public int count_edges()
        {
            return edges.Count;
        }

        public node get_first_node()
        {
            if(edges.Count == 0) { throw new ArgumentOutOfRangeException("edges.Count == 0"); }
            return edges[0].From;
        }
        public node get_last_node()
        {
            if (edges.Count == 0) { throw new ArgumentOutOfRangeException("edges.Count == 0"); }
            return edges[edges.Count - 1].To;
        }

        public override string ToString()
        {
            return edges.ToString();
        }

        public double get_total_route_costs()
        {
            return route_costs;
        }

    }
}
