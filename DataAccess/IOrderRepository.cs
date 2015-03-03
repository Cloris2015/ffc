using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccess
{
    public interface IOrderRepository
    {
        int Create(Order order);
        Order Update(Order order);
        void Delete(int id);
        IList<Order> Search(int? id, DateTime? startdate, DateTime? enddate, string merchant, string note);
        IList<Order> SearchinDetails(int?detailid, int?userid, string item,Decimal?price, int?quantity, string note);
        Order GetorderById(int id);
        IEnumerable<DataModel.Order> Getall();
       
      
    }
}
