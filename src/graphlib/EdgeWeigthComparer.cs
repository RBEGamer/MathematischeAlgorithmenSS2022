using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace graphlib
{
    internal class EdgeWeigthComparer : IComparer<edge>
    {
       
            public int Compare(edge a, edge b)
            {
               
                if (a.Weigth == b.Weigth) //If both are fancy (Or both are not fancy, return 0 as they are equal)
                {
                    return 0;
                }
                else if (a.Weigth < b.Weigth) //Otherwise if A is fancy (And therefore B is not), then return -1
                {
                    return -1;
                }
                else //Otherwise it must be that B is fancy (And A is not), so return 1
                {
                    return 1;
                }
            }

    }
}
