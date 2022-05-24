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
            




            flow_graph fg = new flow_graph();
            fg.load_from_file(Path.Combine(archiveFolder, "Fluss.txt"), true);
            fg.convert_costs_to_capacity();
            System.Console.WriteLine("FLUSS 0 => 7 : " +algorithms.edmonds_karp(fg, fg.get_node_with_id(0), fg.get_node_with_id(7)).MaxFlow);

            flow_graph fg2 = new flow_graph();
            fg2.load_from_file(Path.Combine(archiveFolder, "Fluss2.txt"), true);
            fg2.convert_costs_to_capacity();
            System.Console.WriteLine("FLUSS 2 0 => 7 :" + algorithms.edmonds_karp(fg2, fg2.get_node_with_id(0), fg2.get_node_with_id(7)).MaxFlow);

            flow_graph fg3 = new flow_graph();
            fg3.load_from_file(Path.Combine(archiveFolder, "G_1_2.txt"), true);
            fg3.convert_costs_to_capacity();
            System.Console.WriteLine("FLUSS G_2_1 0 => 7 : " + algorithms.edmonds_karp(fg3, fg3.get_node_with_id(0), fg3.get_node_with_id(7)).MaxFlow);

            int b = 5;

        }
    }
}

