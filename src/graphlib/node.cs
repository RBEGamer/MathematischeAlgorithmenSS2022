using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace graphlib
{
    public class node 
    {

        List<edge> edges;
        private int id;
        private bool visited;
     
        public int Id { get => id; }
        public bool Visited { get => visited; set => visited = value; }

        public node(int _id)
        {
            edges = new List<edge>();
            id = _id; 
            visited = false;
        }


        public List<edge> get_edges()
        {
            return edges;
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
            string tmp = "";

            tmp += "=> NODE "+ Id.ToString()+" :";
            tmp += "\n";
            
            foreach(edge e in edges)
            {
                if (!e.To.Equals(this))
                {
                    tmp += "" +e.ToStringStatisticsEdgeOnly() + "\n";
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
    }
}
