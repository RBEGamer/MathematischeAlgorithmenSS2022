using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace graphlib
{

    

    public class graph_json_format_node
    {

        public int id { get; set; }

        public bool root { get; set; }
        public string caption { get; set; } //LABEEL
        public int type { get; set; } //GROUP
        public float betweeness { get; set; }  //distance between node in pixel

        public graph_json_format_node(int id, bool root, string caption , int type )
        {
            this.id = id;
            this.root = root;
            this.caption = caption;
            this.type = type;
            this.betweeness = 0.2f;
        }

        
    } 

    public class graph_json_format_edge
    {
        public int source { get; set; }
        public int target { get; set; }
        public string caption { get; set; }

        public graph_json_format_edge(string caption, int target, int source)
        {
            this.caption = caption;
            this.target = target;
            this.source = source;
        }
    }

    public class graph_json_format_root{
        public List<graph_json_format_node> nodes { get; set; }
        public List<graph_json_format_edge> edges { get; set; }

        public HashSet<graph_json_format_node_style> nodeStyle { get; set;}
    }



    public class graph_json_format_node_style {
        public string color;
        public string borderColor;
    }


    public class graph_json_format_alchemy_js
    {
        public graph_json_format_root data;
        public string[] node_types;
    }

    public 
    public class graph_export
    {


        public static string ToJsonStringAlchemyJS(graph _g, node? _root_node)
        {
            


            graph_json_format_alchemy_js tmp = new graph_json_format_alchemy_js();

            tmp.data = ToNodeEdgeObj(_g, _root_node);

            //ADD TYPES = NODE CAPITONS AS STRING ARRAY


            //ADD NODE COLORS


            return JsonSerializer.Serialize(tmp);

        }

        public static string ToJsonString(graph _g, node? _root_node)
           
        {
            return JsonSerializer.Serialize(ToNodeEdgeObj(_g, _root_node));
        }

        public static graph_json_format_root ToNodeEdgeObj(graph _g, node? _root_node)
        {

            graph_json_format_root gjson = new graph_json_format_root();
            gjson.nodes = new List<graph_json_format_node>();
            gjson.edges = new List<graph_json_format_edge>();
            gjson.nodeStyle = new HashSet<graph_json_format_node_style>();

            //gjson.nodeStyle.

            //ADD NODES
            foreach (node n in _g.Nodes)
            {
                gjson.nodes.Add(new graph_json_format_node(n.Id, n.Equals(_root_node), n.Label, n.Group_id));
            }

            //ADD EDGES
            foreach(edge e in _g.get_all_edges())
            {
                gjson.edges.Add(new graph_json_format_edge(e.Weigth.ToString(), e.To.Id, e.From.Id));
            }


            return gjson; ;
        }

    }
}
