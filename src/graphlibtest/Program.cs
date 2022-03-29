using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using graphlib;

namespace graphlibtest
{
    internal class Program
    {
        static void Main(string[] args)
        {



            string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string archiveFolder = Path.Combine(currentDirectory, "example_graphs");
            string[] files = Directory.GetFiles(archiveFolder, "*.txt");


            graph g =  new graph();

            g.load_from_file(files[0]);
            int b = g.node_count();
            int c = g.edge_count();
            
            Console.WriteLine(g.ToString());


            algorithms.getDepthFirstSearchTrees(g, g.Nodes[0]);
            
        }
    }
}

