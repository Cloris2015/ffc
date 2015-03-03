using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccess
{
    public interface IWishlistRepository
    {
        int Create(Wish wish);
        Wish Update(Wish wish);
        void Delete(int ID);
        IList<Wish> Search(int? UserID, DateTime? StartDate, DateTime? EndDate, string Item, WishStatusEnum? Status);
        IEnumerable<Wish> GetAll();
        Wish GetById(int ID);
        void Approve(int Id,WishStatusEnum status);   
    }
}
