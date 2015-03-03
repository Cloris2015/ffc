using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [Serializable]
    public class OrderDetail
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public string Item { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }

    }
}
