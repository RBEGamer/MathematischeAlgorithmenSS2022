using System;
using System.Collections.Generic;
using System.Text;

namespace graphlib
{
    public class edge
    {

        private node? from = null;
        private node? to = null;

        private bool directed = false;
        private bool weigthed = false;

        private float weigth = 0.0f;



        public edge(node _from, node _to, bool directed = false)
        {
            from = _from;
            To = _to;
            this.directed = directed;
        }

 
        public float Weigth { get => weigth; set => weigth = value; }
        public node To { get => to; set => to = value; }
        public node From { get => from; set => from = value; }

    public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            edge e = (edge)obj;
            if(this.To == e.To && this.From == e.From && this.Weigth == e.Weigth && this.directed == e.directed && this.weigthed == e.weigthed)
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

            string w = this.Weigth.ToString();

            if (!this.weigthed)
            {
                w = "X";
            }

            if (this.directed)
            {
                return "[" + this.From.ToString() + " <=> " + this.To.ToString() + " : " + w + "]";
            }
            else
            {
                return "[" + this.From.ToString() + " => " + this.To.ToString() + " : " + w + "]";
            }
            
        }

        public String ToStringStatisticsEdgeOnly()
        {

            string w = this.Weigth.ToString();

            if (!this.weigthed)
            {
                w = "X";
            }
            if (this.directed)
            {
                return "==> [" + this.To.Id + " WEIGTH:" +w + "]";
            }
            else
            {
                return "<==> [" + this.To.Id + " WEIGTH:" +w + "]";
            }
          
        }
       

       
    }
}
