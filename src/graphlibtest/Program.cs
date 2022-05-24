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
            double fg_res =  algorithms.edmonds_karp(fg, fg.get_node_with_id(0), fg.get_node_with_id(7)).MaxFlow;

            int b = 5;

        }
    }
}

