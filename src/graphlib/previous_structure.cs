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
            IS_NEGATIVE_CYCLE = 1
        }

        private double[] dist;
        private double min_negative_cycle_capacity = double.PositiveInfinity;
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
            set_to_tree_cycle();
            prev_nodes = new node[_node_count];
            set_distance(_start_node, 0.0);
            set_previous(_start_node, _start_node);
        }



        public List<node> get_path(node _start, node _to)
        {
            List<node> path = new List<node> ();
            node curr = _to;


            path.Add(new node(_start));
            while(curr.Id != _start.Id)
            {
                path.Add(new node(curr));
                curr = prev_nodes[curr.Id];
            }

            
            path.Reverse();
            return path;
        }


        public double get_distance(node _node)
        {
            return dist[_node.Id];
        }


    
        public void set_distance(node _node, double _costs_node)
        {
            dist[_node.Id] = _costs_node;
        }

        public void set_previous(node _node, node _prev_node)
        {
            prev_nodes[_node.Id] = new node(_prev_node);
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

        public void set_to_negative_cycle() {
            this.status = PREV_STATE.IS_NEGATIVE_CYCLE;
        }
        public void set_to_tree_cycle()
        {
            this.status = PREV_STATE.IS_TREE;
        }



        public node get_min_dist(List<node> _unvisited)
        {
            if(_unvisited.Count == 0)
            {
                throw new Exception("empty list");
            }

            int pos = 0;
            node min = _unvisited[pos];

            for(int i = 0; i < _unvisited.Count; i++)
            {
                node n = _unvisited[i];
                if(get_distance(min) > get_distance(n))
                {
                    min = n;
                    pos = i;
                }
            }
            _unvisited.RemoveAt(pos);
            return min;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("\n node:      ");
            

            for (int i = 0; i < dist.Length; i++)
            {
                    str.Append(i + "|");
                
            }
            
            str.Append("\n prev_node: ");

            for (int i = 0; i < dist.Length; i++)
            {
                if (prev_nodes[i] != null)
                {
                    str.Append(prev_nodes[i].Id + "|");
                }
                else
                {
                    str.Append(" | ");
                }
            }

            str.Append("\n dist:      ");

            for (int i = 0; i < dist.Length; i++)
            {
                if (prev_nodes[i] != null)
                {
                    str.Append(dist[i] + "|");
                }
                else
                {
                    str.Append(" | ");
                }
            }

            str.Append("\n");


            return str.ToString();
        }

    }
}
