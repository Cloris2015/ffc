using System.Web.Mvc;
using DataModel;
using DataAccess;

namespace FFC.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
      {
          InMemoryOrderRepository orep = new InMemoryOrderRepository();
          return View(orep.Getall());
        }
        public ActionResult Add()
        {
            DataModel.Order order = new Order();
            return View(order);
        }
    }
}