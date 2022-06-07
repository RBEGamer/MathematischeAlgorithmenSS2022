using System;
using System.Collections.Generic;
using System.Drawing;
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

        public int cluster { get; set; }
        public graph_json_format_node(int id, bool root, string caption , int type, int cluster )
        {
            this.id = id;
            this.root = root;
            this.caption = caption;
            this.type = type;
            this.betweeness = 1.0f;
            this.cluster = cluster;
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
        public string color { get; set; }
        public string borderColor { get; set; }
    }


    public class graph_json_format_alchemy_js
    {
        public graph_json_format_root data { get; set; }
        public string[] node_types { get; set; }
        public string[] clusterColours { get; set; }
    }

     
    public class graph_export
    {

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(v, t, p);
            else if (hi == 1)
                return Color.FromArgb(q, v, p);
            else if (hi == 2)
                return Color.FromArgb(p, v, t);
            else if (hi == 3)
                return Color.FromArgb(p, q, v);
            else if (hi == 4)
                return Color.FromArgb(t, p, v);
            else
                return Color.FromArgb(v, p, q);
        }

        private static String HexConverter(System.Drawing.Color c)
        {
            try
            {
                return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
            }
            catch (Exception ex)
            {
                return "#112233";
            }
        }

        public static string ToJsonStringAlchemyJS(graph _g, node? _root_node)
        {
            


            graph_json_format_alchemy_js tmp = new graph_json_format_alchemy_js();

           


            //ADD TYPES = NODE CAPITONS AS STRING ARRAY
            List<string> nt = new List<string>();
            foreach (KeyValuePair<int, node> kv in _g.node_lookup)
            {
                nt.Add(kv.Value.Label);
            }
            tmp.node_types = nt.ToArray();
            
            //APPLY CLUSTERING
            //algorithms.CreateCorrelationComponentGroups(ref _g) ;
            tmp.data = ToNodeEdgeObj(_g, _root_node);

            //ADD NODE COLORS
            int groups = _g.get_group_count() + 1;

            //ADD COLORS FROM THE HSV RAINBOW SPACE
            tmp.clusterColours = new string[groups];
            for (int i = 0; i < groups; i++)
            {
                tmp.clusterColours[i] = HexConverter(ColorFromHSV((360.0 /(groups*1.0)) * (i*1.0), 1.0, 1.0));
            }


            


            string ret = JsonSerializer.Serialize(tmp);
            
            return ret;

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
            foreach (KeyValuePair<int, node> kv in _g.node_lookup)
            {
                gjson.nodes.Add(new graph_json_format_node(kv.Value.Id, kv.Value.Equals(_root_node), kv.Value.Label, kv.Value.Group_id, kv.Value.Group_id));
            }

            //ADD EDGES
            foreach(edge e in _g.get_all_edges())
            {
                gjson.edges.Add(new graph_json_format_edge(e.Costs.ToString(), e.To.Id, e.From.Id));
            }


            return gjson;
        }

    }
}
