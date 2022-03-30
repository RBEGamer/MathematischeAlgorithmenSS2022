using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace graphlibvisu.Data
{
    public class FileSystemLoader
    {
       

        public Task<GraphLoadingItem[]> GetGraphLoadingItem()
        {

            string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string archiveFolder = Path.Combine(currentDirectory, "example_graphs");
            string[] files = Directory.GetFiles(archiveFolder, "*.txt");


            List<GraphLoadingItem> it = new List<GraphLoadingItem>();   
            foreach(string file in files)
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
