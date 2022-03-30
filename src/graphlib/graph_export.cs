using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace graphlib
{

    

    public class graph_json_format_node
    {
        public int Id { get; set; }
        public bool root { get; set; }
        public int caption { get; set; } //LABEEL
        public int type { get; set; } //GROUP
    } 

    public class graph_json_format_edge
    {
        public int source { get; set; }
        public int target { get; set; }
        public int caption { get; set; }
    }

    public class graph_json_format_root{
        public List<graph_json_format_node> nodes { get; set; }
        public List<graph_json_format_edge> edges { get; set; }
    }


    public class graph_export
    {



        public static string ToJsonString(graph _g, node? _root_node)
        {

            graph_json_format_root gjson = new graph_json_format_root();

            string jsonString = JsonSerializer.Serialize(gjson);
            return jsonString;
        }

    }
}
