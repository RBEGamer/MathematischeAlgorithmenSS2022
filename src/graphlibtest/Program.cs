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


            int ab = algorithms.getRelatedComponents(g);
          


            int b = 5;

        }
    }
}

