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
            

            graph w1 =  new graph();
            w1.load_from_file(Path.Combine(archiveFolder, "Wege1.txt"), true);
            graph w2 = new graph();
            w2.load_from_file(Path.Combine(archiveFolder, "Wege2.txt"), true);
            graph w3 = new graph();
            w3.load_from_file(Path.Combine(archiveFolder, "Wege3.txt"), true);
            graph g12 = new graph();
            g12.load_from_file(Path.Combine(archiveFolder, "G_1_2.txt"), true);
            graph g12u = new graph();
            g12u.load_from_file(Path.Combine(archiveFolder, "G_1_2.txt"), false);

            //DIJREKSTRA WEGE1 => DISTANCE 6
            Console.WriteLine("djikstra W1: 2 => 0 DIST:" + algorithms.djikstra(w1, w1.get_node_with_id(2)).get_distance(w1.get_node_with_id(0)).ToString("N3"));
            //WEGE 2
            Console.WriteLine("bellman_ford W2: 2 => 0 DIST:" + algorithms.bellman_ford(w2, w2.get_node_with_id(2)).get_distance(w2.get_node_with_id(0)).ToString("N3"));
            //WEGE 3
            Console.WriteLine("bellman_ford W3: 2 => 0 IS_NEGATIVE_CYCLE:" + algorithms.bellman_ford(w3, w3.get_node_with_id(2)).is_negative_cycle().ToString());
            //WEGE 3
            Console.WriteLine("UNDIRECTED bellman_ford G_1_2: 0 => 1 DIST:" + algorithms.bellman_ford(g12u, g12u.get_node_with_id(0)).get_distance(g12u.get_node_with_id(1)).ToString("N3"));
            Console.WriteLine("DIRECTED djikstra G_1_2: 0 => 1 DIST:" + algorithms.djikstra(g12, g12.get_node_with_id(0)).get_distance(g12.get_node_with_id(1)).ToString("N3"));

            int b = 5;

        }
    }
}

