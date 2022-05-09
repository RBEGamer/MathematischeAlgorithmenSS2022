using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphlib
{
    public class previous_structure
    {

        public enum PREV_STATE
        {
            IS_TREE = 0,
            IS_NEGATIVE_CYCLE = 0
        }

        private double[] dist;
        private double min_negative_cycle_capacity = double.MaxValue;
        private List<edge> negative_cycle = new List<edge>();
        private node[] prev_nodes;
        private PREV_STATE status = PREV_STATE.IS_TREE;
        private double total_negative_cycle_costs = 0.0;


        public double getMinNegativCylcleCapacity
        {
            get => min_negative_cycle_capacity;
        }

        public List<edge> getNegativeCycle{ get => negative_cycle; }


        public previous_structure(int _node_count, node _start_node)
        {
            dist = new double[_node_count];
            for (int i = 0; i < _node_count; i++)
            {
                dist[i] = double.PositiveInfinity;
            }

            prev_nodes = new node[_node_count];
            set_distance(_start_node, 0.0);
            set_previous(_start_node, _start_node);
        }


        public void construct_negative_cycle(node _current_node, graph _graph)
        {
            for (int i = 0; i < _graph.node_count(); i++)
            {
                _current_node = prev_nodes[_current_node.Id];
            }

            negative_cycle = new List<edge>();

            if (is_negative_cycle())
            {
                node start_node = _current_node;
                while(get_previous_node(_current_node).Id != start_node.Id)
                {
                    add_edge_to_cycle(_graph, get_previous_node(_current_node), _current_node);
                    _current_node = get_previous_node(_current_node);
                }
                add_edge_to_cycle(_graph, get_previous_node(_current_node), _current_node);
            }
        }

        public List<node> get_path(node _start, node _to)
        {
            List<node> path = new List<node> ();
            node curr = _to;


            path.Add(_start);
            while(curr.Id != _start.Id)
            {
                path.Add(curr);
                curr = prev_nodes [curr.Id];
            }

            path.Reverse();
            return path;
        }


        ^public double get_distance(node _node)
        {
            return dist[_node.Id];
        }


    
        public void set_distance(node _node, double _costs_node)
        {
            dist[_node.Id] = _costs_node;
        }

        public void set_previous(node _node, node _prev_node)
        {
            prev_nodes[_node.Id] = _prev_node;
        }


        public bool is_negative_cycle()
        {

            if(status == PREV_STATE.IS_NEGATIVE_CYCLE)
            {
                return true;
            }
            return false;
        }


        public node get_previous_node(node _node)
        {
            return prev_nodes[_node.Id];
        }

        public void add_edge_to_cycle(graph _g, node _from, node _to)
        {
            try
            {
                List<edge> el =  _g.get_edge_from_node(_from, _to);
                if(el.Count == 0) { throw new Exception("no edge from " + _from.ToString() + " " + _to.ToString()); }
                edge e = el[0];
                negative_cycle.Add(e);
                min_negative_cycle_capacity = Math.Min(min_negative_cycle_capacity, e.Capacity);
            }catch(Exception e)
            {

            }
        }


        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < dist.Length; i++)
            {
                if (prev_nodes[i] != null)
                {
                    str.Append(prev_nodes[i].Id + " -> " + i + ": " + dist[i] + "\n");
                }
            }
            return str.ToString();
        }

    }
}
