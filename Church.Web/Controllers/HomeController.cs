using Church.DataLayer.Db.Entity;
using Church.DataLayer.Models;
using System.Web.Mvc;

namespace Church.Web.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Title = "Home Page";
            UpdateModel(new Employee());
            return View();
        }
    }
}
