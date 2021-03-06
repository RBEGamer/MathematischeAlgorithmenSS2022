using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using graphlib;



namespace graphlibvisu.Data
{
    public class FileSystemLoader
    {

        public enum ALOGORITHM
        {
            NONE,
            CLUSTER,
            BREITENSUCHE,
            TIEFENSUCHE,
            RESET,
            PRIM
        }

        static graph loaded_graph = new graph();
        static graph org_loaded_graph = new graph();

        public static string[] get_files_from_fs()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string archiveFolder = Path.Combine(currentDirectory, "example_graphs");
            string[] files = Directory.GetFiles(archiveFolder, "*.txt");

            return files;
        }


       public static string LoadGraphToJSONString(string _path)
        {

            string[] files = get_files_from_fs();

            bool fok = false;
            string real_path = null;
            foreach (string f in files)
            {
                if (Path.GetFileName(f).Equals(_path))
                {
                    fok = true;
                    real_path = f;
                    break;
                }
            }

            if (fok && real_path != null && real_path.Length > 0)
            {
                
                if (loaded_graph.load_from_file(real_path, false))
                {
                    loaded_graph = algorithms.prim(loaded_graph, loaded_graph.get_node_with_id(0));
                }
            }

            return "{\"nodes\": [],\"edges\":[}], \"nodeTypes\": null}";
        }


        public static string CurrentGraphToJSONSTring()
        {
                return graph_export.ToJsonStringAlchemyJS(loaded_graph, null);
        }




        public static void ApplyEffectOnGraph(ALOGORITHM _alg)
        {
            switch (_alg)
            {
                case ALOGORITHM.PRIM:
                    loaded_graph = algorithms.prim(loaded_graph, loaded_graph.get_random_node());
                    break;
                    algorithms.getRelatedComponents(loaded_graph);
                    break;
                case ALOGORITHM.TIEFENSUCHE:
                    algorithms.getDepthFirstSearchTreesNode(loaded_graph);
                    break;
                case ALOGORITHM.BREITENSUCHE:
                   // algorithms.getDepthFirstSearchTreesSimple(ref loaded_graph, loaded_graph.get_random_node(), null);
                    break;
                case ALOGORITHM.RESET:
                    loaded_graph.set_all_unvisited();
                    loaded_graph.ungroup_all();
                        //= org_loaded_graph;
                    break;
                default:
                    break;
            }
        }


        public static Task<GraphLoadingItem[]> GetGraphLoadingItem()
        {
            List<GraphLoadingItem> it = new List<GraphLoadingItem>();   
            foreach(string file in get_files_from_fs())
            {
                GraphLoadingItem item = new GraphLoadingItem();
                item.title = Path.GetFileNameWithoutExtension(file);
                item.filename = Path.GetFileName(file);
                if (item.filename.StartsWith("G_"))
                {
                    item.type = "DIRECTED";
                }else if (item.filename.StartsWith("Graph"))
                {
                    item.type = "NOT DIRECTED, NOT WEIGHTED";
                }
               it.Add(item);

            }
            return Task.FromResult(it.ToArray());
        }
    }
}
