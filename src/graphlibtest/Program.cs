using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using graphlib;
using System.Collections.Generic;
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

            g.load_from_file(files[0], false);

            //X * 1000 knoten Y*1000 Kanten


            //2ms für K10e
            System.Console.WriteLine(algorithms.nearest_neighbour(g,g.get_node_with_id(2)));

            //1ms für K10e
            System.Console.WriteLine(algorithms.double_tree(g, g.get_node_with_id(2)));

          


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            System.Console.WriteLine(algorithms.bruteForceRoute(g, false));
            stopwatch.Stop();
            double nna_time = stopwatch.ElapsedMilliseconds;
            System.Console.WriteLine(algorithms.bruteForceRoute(g, true));


            int b = 5;

        }
    }
}

