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
            route r = algorithms.nearest_neighbour(g,g.node_lookup[0]);
            System.Console.WriteLine("nearest_neighbour:" + r);

            //1ms für K10e
            r = algorithms.double_tree(g, g.node_lookup[0]);
            System.Console.WriteLine("double_tree:" + r);




            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            r = algorithms.bruteForceRoute(g, false);
            System.Console.WriteLine("bruteForceRoute:" + r);
            stopwatch.Stop();
            double nna_time = stopwatch.ElapsedMilliseconds;
            r = algorithms.bruteForceRoute(g, true);
            System.Console.WriteLine("branch&bound:" + r);

            int b = 5;

        }
    }
}

