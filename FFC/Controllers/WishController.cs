using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModel;
using DataAccess;
using FFC.Models.ViewModel;

namespace FFC.Controllers
{
    public class WishController : Controller
    {
        // GET: Wish
        public ActionResult Index()
        {
            var Wishlist = new InMemoryWishlistRepository().GetAll();
            var userList = new InMemoryUserRepository().GetAll();

            return View(from w in Wishlist join u in userList on w.UserID equals u.ID select new WishView { Wish = w, UserName = u.Name });
        }
        public ActionResult Add()
        {
            ViewBag.Title = "I am trying to add";
            WishView wishview = new WishView();
            int UserId = Convert.ToInt32(Session["userId"]);
            var user = new InMemoryUserRepository().Get(UserId);
            wishview.UserName = user.Name;
            Wish wish=new Wish();
            wish.UserID = UserId;
            wishview.Wish=wish;
            return View(wishview);
        }
        [HttpPost]
        public ActionResult Add([ModelBinder(typeof(WishBinder))] Wish wish)
        {
            InMemoryWishlistRepository Wrep = new InMemoryWishlistRepository();
            wish.UserID = Convert.ToInt32(Session["userId"]);
            Wrep.Create(wish);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            InMemoryWishlistRepository Wrep = new InMemoryWishlistRepository();
            IUserRepository urep = new InMemoryUserRepository();
            Wish w = Wrep.GetById(id);
            return View(new WishView { Wish = w,UserName = urep.Get(w.UserID).Name });
        }
        [HttpPost]
        public ActionResult Edit([ModelBinder(typeof(WishBinder))] Wish wish)
        {
            InMemoryWishlistRepository Wrep = new InMemoryWishlistRepository();
            Wrep.Update(wish);
            return RedirectToAction("Index");
        }
        public ActionResult ListtobeApproved()
        {
            var wishlist = new InMemoryWishlistRepository().GetAll();
            var userlist = new InMemoryUserRepository().GetAll();
            return View(from w in wishlist
                        where (w.Status == WishStatusEnum.New || w.Status == WishStatusEnum.Disapproved)
                        join u in userlist 
                        on w.UserID equals u.ID
                        select new WishView { Wish = w, UserName = u.Name });
 
        }
        [HttpPost]
        public ActionResult Approve(int id)
        {
            InMemoryWishlistRepository Wrep = new InMemoryWishlistRepository();
            int UserId = Convert.ToInt32(Session["userId"]);
            Wrep.Approve(id,WishStatusEnum.Approved);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Disapprove(int id)
        {
            InMemoryWishlistRepository wrep = new InMemoryWishlistRepository();
            wrep.Approve(id, WishStatusEnum.Disapproved);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            InMemoryWishlistRepository wrep = new InMemoryWishlistRepository();
            wrep.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Search()
        {
            var Wishlist = new InMemoryWishlistRepository().GetAll();
            var userList = new InMemoryUserRepository().GetAll();
            ViewBag.userlist = userList;
            return View(from w in Wishlist join u in userList on w.UserID equals u.ID select new WishView { Wish = w, UserName = u.Name });
    

        }
        [HttpPost]
        public ActionResult Search(int? UserID, DateTime? StartDate, DateTime? EndDate, string Item, WishStatusEnum? Status)
        {
            InMemoryWishlistRepository Wrep = new InMemoryWishlistRepository();
            var wishlist = Wrep.Search(UserID, StartDate, EndDate, Item, Status);
            var userList = new InMemoryUserRepository().GetAll();
            ViewBag.userlist = userList;
            ViewData["Item"] = Item;
            return(View(from w in wishlist join u in userList on w.UserID equals u.ID select new WishView{Wish=w, UserName=u.Name}));          
        }
     
    }

}