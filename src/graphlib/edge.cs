using System;
using System.Collections.Generic;
using System.Text;

namespace graphlib
{
    public class edge: IComparable
    {

        private node? from = null;
        private node? to = null;




        private double weigth = 0.0;
        private double capacity = 0.0;
      //  private double costs = 0.0;
        private double flow = 0.0f;

        private bool residual_edge = false;

        public edge(node _from, node _to)
        {
            this.From = _from;
            this.To = _to;

        
        }

        public edge(edge _e)
        {
            this.From = _e.from;
            this.To = _e.to;
            this.Weigth = _e.weigth;


        }


        public edge(node _from, node _to, double _weigth)
        {
            this.From = _from;
            this.To = _to;
            this.Weigth = _weigth;
        }

        public edge(node _from, node _to, double _weigth, double _capacity)
        {
            this.From = _from;
            this.To = _to;
            this.Weigth = _weigth;
            this.capacity = _capacity;
        }



        public double Weigth { get => weigth; set => weigth = value; }
        public double Flow { get => flow; set => flow = value; }
        
        public bool IsResidualEdge { get => residual_edge; set => residual_edge = value; }

        public double Capacity { get => capacity; set => capacity = value; }

     //   public double Costs { get => costs; set => costs = value; }
        public node To { get => to; set => to = value; }
        public node From { get => from; set => from = value; }


        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            edge e = (edge)obj;
            if(this.To == e.To && this.From == e.From && this.Weigth == e.Weigth  )
            {
                return true;
                
            }
            
            return base.Equals(obj);
           
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
            return base.GetHashCode();
        }


        public override String ToString()
        {
            return "[" + this.From.ToString() + " => " + this.To.ToString() + " : " + this.Weigth.ToString() + "]";
           
        }

        public node getTarget(node n)
        {
            if (this.To.Id == n.Id)
            {
                return From;
            }
            else if (this.From.Id == n.Id)
            {
                return To;
            }
            else
            {
                return null;
            }
        }
        public String ToStringStatisticsEdgeOnly()
        {
                return "=> " + this.To.Id+""; 
        }

        public int CompareTo(object obj)
        {
            if (obj == null) { return 1; }

            edge other = obj as edge;
            if (other != null)
            {

                if (this.Weigth > other.Weigth)
                {
                    return -1;

                }
                else if (this.Weigth > other.Weigth)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            else
            {
                throw new ArgumentException("Object is not a edge");
            }



        }
    }
}
