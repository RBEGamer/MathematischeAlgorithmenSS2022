using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphlib
{
    internal class GroupHandler
    {
        private List<List<node>> groupToNodes = new List<List<node>>();
        private List<int> nodeToGroup = new List<int>();

        public GroupHandler(List<node> _nodes)
        {

            _nodes = _nodes.OrderBy(o => o.Id).ToList();
            for (int i = 0; i < _nodes.Count; i++)
            {
                groupToNodes.Add(new List<node>());
                groupToNodes[_nodes[i].Id].Add(_nodes[i]);
                nodeToGroup.Add(i);
            }
        }

        public void addNodeToGroup(node n, int g)
        {
            groupToNodes[g].Add(n);
            nodeToGroup[n.Id]= g;
        }

        public int getGroupId(node n)
        {
            return nodeToGroup[n.Id];
        }

        public List<node> getNodesToGroup(int groupID)
        {
            return groupToNodes[groupID];
        }

        private void changeGroupId(List<node> nodes, int groupID, int oldGroup)
        {
            //groupToNodes.set(oldGroup, new ArrayList<Node>());
            foreach (node n in nodes)
            {
                addNodeToGroup(n, groupID);
            }
        }

        public void unionGroups(node a, node b)
        {
            int g1 = getGroupId(a);
            int g2 = getGroupId(b);
            if (g1 == g2)
            {
                return;
            }
            //speichere Nodes einer Gruppe ab und überprüfe ob Nodelist von g1 größer als g2
            //falls ja: füge Nodes der Gruppe g2 zur größeren Gruppe g1 hinzu und lösche g2
            //falls nicht: füge Nodes der Gruppe g1 zur Gruppe g2 hinzu und lösche g1
            List<node> nodes = getNodesToGroup(g1);
            if (groupToNodes[g2].Count< nodes.Count)
            {
                nodes = getNodesToGroup(g2);
                changeGroupId(nodes, g1, g2);
            }
            else
            {
                changeGroupId(nodes, g2, g1);
            }
        }
    }
}
