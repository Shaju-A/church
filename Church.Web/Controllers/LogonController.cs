using Church.DataLayer;
using Church.DataLayer.Models;
using Church.DataLayer.Service;
using StructureMap;
using System.Web.Mvc;

namespace Church.Web.Controllers
{
    public class LogonController : Controller
    {
        [ActionName("Login")]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult DoLogin(LoginModel model)
        {
            var loginStatus = ObjectFactory.GetInstance<ILoginService>().DoLogin(model);
            if ((UserLoginStatus)loginStatus == UserLoginStatus.Success)
            {
                Response.Write("<h1>Landing page</h1>");
            }

            return View("Index");
        }
    }
}