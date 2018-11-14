using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMB
{
    class Smart
    {
        public struct Data
        {
            public string Des1;
            public string Des2;
            public string Des3;
            public int Qty;
        }
        public static Dictionary<string, Data> Element = new Dictionary<string, Data>();
        public static void addValue(string reference, string Qty, string Des1 = "", string Des2 = "", string Des3 = "")
        {
            int qty1 = 0;
            try
            {
                double.Parse(Qty);
            }
            catch (Exception)
            {

                // System.Windows.Forms.MessageBox.Show("Quantity must be numeric");
                return;
            }
            if (Element.ContainsKey(reference))
            {
                Data x;
                x = Element[reference];
                x.Qty = Element[reference].Qty + qty1;
            }
            else
            {
                Data x;
                x.Qty = qty1;
                x.Des1 = Des1;
                x.Des2 = Des2;
                x.Des3 = Des3;

                Element.Add(reference, x);
            }
        }
    }
}
