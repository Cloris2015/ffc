using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    [Serializable]
    public class Order
    {
        public int ID { get; private set; }
        public Order(int id)
        {
            this.ID = id;
        }
        public Order()
        {

        }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [DataType(DataType.Currency)]
        public Decimal Tax { get; set; }
        [DataType(DataType.Currency)]
        public Decimal Shipping { get; set; }
        [DataType(DataType.Currency)]
        public Decimal Total { get; set; }
        public string Merchant { get; set; }
        public string Note { get; set; }
        public List<OrderDetail> Details { get; set; }
        

    }
}
