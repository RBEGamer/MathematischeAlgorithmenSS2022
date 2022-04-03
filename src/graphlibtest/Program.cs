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


            // Console.WriteLine(g.ToString());


            // System.Collections.Generic.List<node> nt =algorithms.getDepthFirstSearchTrees(ref g, g.get_random_node(), false, true);


            g.set_directed(true);


            int b = algorithms.getCorrelationComponents(g);
            b = 5;

        }
    }
}

