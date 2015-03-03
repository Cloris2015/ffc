using System.Web.Mvc;
using DataModel;
using DataAccess;

namespace FFC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            IUserRepository urep = new InMemoryUserRepository();
            return View(urep.GetAll());
        }
        public ActionResult Add()
        {
         
            DataModel.User user = new User();
            return View(user);


        }
        [HttpPost]
        public ActionResult Add(User user)
        {
            InMemoryUserRepository urep = new InMemoryUserRepository();
            urep.Create(user);
            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {
            IUserRepository urep = new InMemoryUserRepository();
            DataModel.User user = urep.Get(id);
            return View(user);

        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            InMemoryUserRepository urep = new InMemoryUserRepository();
            urep.Update(user);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            InMemoryUserRepository urep = new InMemoryUserRepository();
            return View(urep.Get(id));

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            InMemoryUserRepository urep = new InMemoryUserRepository();
            urep.Delete(id);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK, "Sucessfully deleted");
        }
        public ActionResult Search()
        {
            IUserRepository urep = new InMemoryUserRepository();
            return View(urep.GetAll());
        }
        [HttpPost]
        public ActionResult Search(string name, string email, string phone)
        {
            InMemoryUserRepository urep = new InMemoryUserRepository();
            return View(urep.Search(name, email, phone));

        }
    }
}