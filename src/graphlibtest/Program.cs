﻿using System;
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
            graph r = algorithms.Prim(ref g, g.get_node_with_id(0));
            //graph r = algorithms.Kruskal(g);
            double w = algorithms.calculateWeigth(r);
            int b = 5;

        }
    }
}

