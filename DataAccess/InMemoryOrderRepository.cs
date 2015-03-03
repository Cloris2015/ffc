using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Linq.Expressions;

namespace DataAccess
{
  public  class InMemoryOrderRepository: IOrderRepository
    {
        static Dictionary<int, Order> Orders = new Dictionary<int, Order>();
        public int Create(DataModel.Order order)
        {
            lock (Orders)
            {
                int id = Orders.Keys.Max()+1;
                Orders.Add(id, order.Clone());

                return id;

            }
        }

        public DataModel.Order Update(DataModel.Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("order");
            }
            if (Orders.ContainsKey(order.ID))
            {
                Order o=Orders[order.ID];
                o.Details=order.Details;
                o.Date=order.Date;
                o.Merchant=order.Merchant;
                o.Note = order.Note;
                o.Shipping = order.Shipping;
                o.Tax = order.Tax;
                o.Total = order.Total;
                return order;
            }
            else
            {
                throw new Exception();
            }
        }

        public void Delete(int id)
        {
            if (Orders.ContainsKey(id))
            {
                Orders.Remove(id);
            }
        }

        public IList<DataModel.Order> Search(int? id, DateTime? startdate, DateTime? enddate, string merchant, string note)
        {
          
            var olist = Orders
                .Where(o => !id.HasValue || o.Value.ID.Equals(id.Value))
                .Where(o => !startdate.HasValue || o.Value.Date >= startdate.Value)
                .Where(o => !enddate.HasValue || o.Value.Date <= enddate.Value)
                .Where(o => !String.IsNullOrEmpty(merchant) || (!String.IsNullOrEmpty(o.Value.Merchant) && o.Value.Merchant.IndexOf(merchant, StringComparison.InvariantCultureIgnoreCase) >= 0))
                .Where(o => !String.IsNullOrEmpty(note) || (!String.IsNullOrEmpty(o.Value.Note) && o.Value.Note.IndexOf(note, StringComparison.InvariantCultureIgnoreCase) >= 0))
                .Select(o => o.Value.Clone()).ToList();
            return olist;
         
                  

                  
           
        }

        public IList<DataModel.Order> SearchinDetails(int?detailid, int?userid, string item,Decimal?price, int?quantity, string note)
        {
            //Order o=new Order()
            //var olist=Orders.Where(o=>o.Value.Details.Contains(ID=DetailID))
            return null;
        }
        public Order GetorderById(int id)
        {
            return Orders.ContainsKey(id) ? Orders[id] : null;
        }
        public IEnumerable<DataModel.Order> Getall()
        {
            return (from o in Orders select o.Value);
        }
    }
}
