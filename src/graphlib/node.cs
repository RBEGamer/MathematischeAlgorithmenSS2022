using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Collections;

namespace graphlib
{
    public class node: IComparable
    {

        List<edge> edges;
        private int id;
        private bool visited;
        private string label;
        private int group_id = -1; //-1 = NOGROUP
        public int Id { get => id; }
        public bool Visited { get => visited; set => visited = value; }
        public string Label { get => label; set => label = value; }
        public int Group_id { get => group_id; }

        
        public node(int _id)
        {
            edges = new List<edge>();
            id = _id; 
            visited = false;
            label = id.ToString();
            group_id = -1; //NO GROUP
        }



        public void ungroup_node()
        {
            group_id = -1;
        }

        public bool is_in_group()
        {
            if(group_id >= 0)
            {
                return true;
            }

            return false;
        }
        public void set_group(uint _id)
        {
            group_id = (int)_id;
        }

        public int Compare(node x, node y)
        {
            int compareDate = x.id.CompareTo(y.id);
            return compareDate;
        }

        public node(node _g)
        {
            edges = _g.edges;
            id = _g.id;
            visited = _g.visited;
            label = _g.label;
        }

        public List<edge> get_edges()
        {
            return edges;
        }


        public List<node> get_directed_neighbours()
        {
            List<node> nodes = new List<node>();

            foreach (edge e in edges)
            {
                nodes.Add(e.To);
            }

            return nodes;
        }

        public List<edge> get_edges_to(node _node)
        {
            List<edge> edges_to = new List<edge>();
            
            foreach(edge e in edges)
            {
                if (e.To.Equals(_node))
                {
                    edges_to.Add(e);
                }
            }

            return edges_to;
        }


        public bool add_edge(edge _e)
        {
            edges.Add(_e);
            return true;
        }


        public override string ToString()
        {
            return Id.ToString();
        }

        public string ToStringFull()
        {
            string tmp = "";

            tmp += "=> NODE " + Id.ToString();
            tmp += "\n";

            foreach (edge e in edges)
            {
                if (!e.To.Equals(this))
                {
                    tmp += "" + e.ToStringStatisticsEdgeOnly() + "\n";
                }
            }
            tmp += "\n";
            return tmp;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            node e = (node)obj;

            if(this.Id == e.Id) { return true; }

            return base.Equals(obj);
        }

        public int CompareTo(object obj)
        {
            node tmp = (node)obj;
            return Compare(this, tmp);
        }

    

}

}
