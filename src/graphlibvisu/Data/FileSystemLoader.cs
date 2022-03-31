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
                graphlib.graph g = new graph();
                if (g.load_from_file(real_path))
                {

                    string t = graph_export.ToJsonStringAlchemyJS(g, null);
                    return t;
                }
            }

            return "{\"nodes\": [],\"edges\":[}], \"nodeTypes\": null}";
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
