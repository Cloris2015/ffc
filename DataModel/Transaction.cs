using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [Serializable]
    public class Transaction
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public Decimal Amount { get; set; }
        public string Comment { get; set; }
        public string RefID { get; set; }

    }
}
