using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphlib
{
    public class visited_handler
    {

        private int visited_counter = 0;
        private bool[] visited = null;

        public visited_handler(int _sz)
        {
            visited = new bool[_sz];
        }


        public bool[] get_array()
        {
            return visited;
        }

        public bool is_all_visited()
        {
            return visited.Length == visited_counter;
        }

        public bool is_not_all_visited() {
            return !is_all_visited();
        }

        public bool[] get_visited()
        {
            return visited;
        }

        public bool is_visited(node _n)
        {
            return visited[_n.Id];
        }

        public bool is_not_visited(node _n)
        {
            return !is_visited(_n);
        }
        public void set_visited(node _n)
        {
            if(_n.Id < visited.Length)
            {
                if (!visited[_n.Id])
                {
                    visited_counter++;
                    visited[_n.Id] = true;
                }
            }
        }
    }
}
