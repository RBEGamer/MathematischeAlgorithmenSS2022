using System;
using System.Collections.Generic;
using System.Text;

namespace graphlib
{
    internal class predesessor
    {
        private node[] prev = null;

        public predesessor(graph g, node s)
        {
            prev = new node[g.node_count()];
            prev[s.Id] = s;
        }

        public node getPrevNode(node x)
        {
            return prev[x.Id];
        }

        public void setPrevNode(node x, node prevNode)
        {
            prev[x.Id] = prevNode;
        }
    }
}
