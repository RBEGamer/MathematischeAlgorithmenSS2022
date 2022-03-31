namespace graphlibvisu.Data
{
    public class GraphLoadingItem
    {

        public string title;
        public string filename;
        public string type;




        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            GraphLoadingItem e = (GraphLoadingItem)obj;
            if (this.filename == e.filename)
            {
                return true;
            }

            string s = (string)obj;
            if (this.filename == s)
            {
                return true;
            }

            return base.Equals(obj);

        }
    }
}
