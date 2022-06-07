using System;
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
                route_costs += e.Costs;
            }
        }

        public route()
        {

        }

        public void add_edge(edge _e)
        {
            edges.Add(_e);
            route_costs += _e.Costs;
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
            string tmp = "ROUTE COSTS "+ Math.Round(route_costs, 2).ToString()+":";
            foreach (edge e in edges)
            {
                tmp += e.ToStringStatisticsEdgeOnly();
            }

            return tmp + '\n';
        }

        public double get_total_route_costs()
        {
            return route_costs;
        }


        public void addEdgeToRoute(node _from, node _to, graph _g, bool _add_only_unique_nodes)
        {
          route.addEdgeToRoute(this, _from, _to, _g, _add_only_unique_nodes);
        }


        public void connect_start_end(graph _g)
        {
            addEdgeToRoute(get_last_node(), get_first_node(), _g, false);
        }


        public static route addEdgeToRoute(route _r ,node _from, node _to, graph _g, bool _add_only_unique_nodes)
        {
            try
            {
                List<edge> pn = _g.get_edge_from_node(_from, _to);
                if(pn.Count <= 0) { throw new ArgumentOutOfRangeException("_g.get_edge_from_node(_from, _to).Count <= 0"); }
                _r.add_edge(pn[0]);
            }
            catch (ArgumentOutOfRangeException e)
            {

            }
            return _r;
        }


        public static bool checkCheapestRoute(route _r, route _current_cheapest)
        {
            if (_current_cheapest.count_edges() <= 0)
            {
                return true;
            }
            return _r.get_total_route_costs() < _current_cheapest.get_total_route_costs();
        }

        
    }
}

