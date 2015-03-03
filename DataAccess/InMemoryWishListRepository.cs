using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Linq.Expressions;
using System.Web;

namespace DataAccess
{
    public class InMemoryWishlistRepository : IWishlistRepository
    {
        static Dictionary<int, Wish> wishlist = new Dictionary<int, Wish>();

        static InMemoryWishlistRepository()
        {
            wishlist.Add(1, new Wish(1) { Date = new DateTime(2015,2,1), Item = "New Toys", Note = "Desired",Status = WishStatusEnum.New,UserID=1});
            wishlist.Add(2, new Wish(2) { Date = new DateTime(2015, 1, 1), Item = "Books", Note = "Desired", Status = WishStatusEnum.New, UserID = 2 });
            wishlist.Add(3, new Wish(3) { Date = new DateTime(2014, 12, 10), Item = "Crafts Materials", Note = "Desired", Status = WishStatusEnum.Approved, UserID = 1, LastUpdate = new DateTime(2014, 12, 10), LastUpdatedBy = 3 });
            wishlist.Add(4, new Wish(4) { Date = new DateTime(2014, 12, 8), Item = "$1000000", Note = "Cool", Status = WishStatusEnum.Disapproved, UserID = 1, LastUpdate = new DateTime(2014, 10, 10), LastUpdatedBy = 3 });
        }


        public int Create(Wish wish)
        {
            lock (wishlist)
            {
                try
                {
                    int id = wishlist.Keys.Max()+1;
                    wishlist.Add(id, new Wish(id) { Date =DateTime.Now, Item = wish.Item, LastUpdate = wish.LastUpdate, LastUpdatedBy = wish.LastUpdatedBy, Note = wish.Note, Status = WishStatusEnum.New, UserID = wish.UserID });
                    return id;
                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        public Wish Update(Wish wish)
        {
            if (wish == null)
            {
                throw new EntryPointNotFoundException("wishlist");
            }
            lock (wishlist)
            {
                int id = wish.ID;
                if (wishlist.ContainsKey(id))
                {
                    Wish w = wishlist[id];
                    w.Date = wish.Date;
                    w.Item = wish.Item;
                    w.Note = wish.Note;
                    return new Wish(id) { Date = wish.Date, Item = wish.Item,Note = wish.Note, UserID = wish.UserID };  
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public void Delete(int ID)
        {
            if (wishlist.ContainsKey(ID))
            {
                wishlist.Remove(ID);
            }
            else
            {
                throw new EntryPointNotFoundException("wishlist");
            }
        }

        public IList<Wish> Search(int? UserID, DateTime? StartDate, DateTime? EndDate, string Item, WishStatusEnum? Status)
        {

            var vlist = wishlist.Where(v => (v.Value.UserID.Equals(UserID) || UserID==null)
                && ((v.Value.Date >= StartDate && v.Value.Date <= EndDate) || (v.Value.Date >= StartDate && EndDate == null) || (v.Value.Date <= EndDate && StartDate == null)||(StartDate==null&&EndDate==null))
                &&(v.Value.Item.IndexOf(Item, StringComparison.InvariantCultureIgnoreCase)>=0||string.IsNullOrEmpty(Item))
                &&( v.Value.Status.Equals(Status)||Status==null)
                ).Select(v => new Wish(v.Value.ID) { UserID = v.Value.UserID, Status = v.Value.Status, Date = v.Value.Date, Item = v.Value.Item, LastUpdate = v.Value.LastUpdate, LastUpdatedBy = v.Value.LastUpdatedBy, Note = v.Value.Note }).ToList();

            return vlist;
        }
        public IEnumerable<Wish> GetAll()
        {
            return (from w in wishlist select w.Value);
    
        }
        public Wish GetById(int ID)
        {
            if (wishlist.ContainsKey(ID))
            {
            return wishlist[ID];
            }
            else
            {
                return null;
            }
        }
        /*Approval or Cancel*/
        public void Approve(int Id, WishStatusEnum status)
        {
            if (wishlist.ContainsKey(Id))
            {
                Wish w=wishlist[Id];
                w.Status = status;
                w.LastUpdate = DateTime.Now;
                w.LastUpdatedBy = Convert.ToInt16(HttpContext.Current.Session["userId"]);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
      
    }
}
