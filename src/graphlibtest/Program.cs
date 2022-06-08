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
            fg.load_flow_graph_from_file(Path.Combine(archiveFolder, "Kostenminimal1.txt"));
            System.Console.WriteLine("Kostenminimal1.txt SSP => 3 : " + algorithms.success_shortest_path(fg));
          
            
            
            flow_graph fg2 = new flow_graph();
            fg2.load_flow_graph_from_file(Path.Combine(archiveFolder, "Kostenminimal2.txt"));
            System.Console.WriteLine("Kostenminimal2.txt CC => 0:" + algorithms.cycle_canceling(fg2));
            
            flow_graph fg3 = new flow_graph();
            fg3.load_flow_graph_from_file(Path.Combine(archiveFolder, "Kostenminimal3.txt"));
            System.Console.WriteLine("Kostenminimal3.txt SSP => X: " + algorithms.success_shortest_path(fg3));


            flow_graph fg4 = new flow_graph();
            fg4.load_flow_graph_from_file(Path.Combine(archiveFolder, "Kostenminimal4.txt"));
            System.Console.WriteLine("Kostenminimal4.txt CC => X: " + algorithms.cycle_canceling(fg4));

            
            flow_graph fg5 = new flow_graph();
            fg5.load_flow_graph_from_file(Path.Combine(archiveFolder, "Kostenminimal_gross1.txt"));
            System.Console.WriteLine("Kostenminimal_gross1.txt CC => 1537: " + algorithms.cycle_canceling(fg5));
            
            flow_graph fg6 = new flow_graph();
            fg6.load_flow_graph_from_file(Path.Combine(archiveFolder, "Kostenminimal_gross2.txt"));
            System.Console.WriteLine("Kostenminimal_gross2.txt SSP => 1838: " + algorithms.success_shortest_path(fg6));

            flow_graph fg7 = new flow_graph();
            fg7.load_flow_graph_from_file(Path.Combine(archiveFolder, "Kostenminimal_gross3.txt"));
            System.Console.WriteLine("Kostenminimal_gross3.txt CC => X: " + algorithms.cycle_canceling(fg7));

         

        }
    }
}

