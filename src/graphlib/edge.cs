using System;
using System.Collections.Generic;
using System.Text;

namespace graphlib
{
    public class edge: IComparable
    {

        private node? from = null;
        private node? to = null;


        private bool weigthed = false;

        private float weigth = 0.0f;


        public edge(node _from, node _to)
        {
            this.From = _from;
            this.To = _to;

            this.weigthed = false;
        }

        public edge(node _from, node _to, float weigth)
        {
            this.From = _from;
            this.To = _to;

            this.Weigth = weigth;
            this.weigthed = true;
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
            if(this.To == e.To && this.From == e.From && this.Weigth == e.Weigth  && this.weigthed == e.weigthed)
            {
                if (this.weigthed == e.weigthed && this.weigth == e.weigth) {
                    return true;
                }
                else
                {
                    return true;
                }
                
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

            string w = "X";

            if (this.weigthed)
            {
                w = this.Weigth.ToString();
            }
            
            return "[" + this.From.ToString() + " => " + this.To.ToString() + " : " + w + "]";
           
            
        }

        public String ToStringStatisticsEdgeOnly()
        {

            string w = "X";

            if (this.weigthed)
            {
                w = this.Weigth.ToString();
            }
         
                return "==> [" + this.To.Id + " WEIGTH:" +w + "]";
          
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
