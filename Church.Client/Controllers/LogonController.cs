using Church.DataLayer;
using Church.DataLayer.Models;
using Church.DataLayer.Service;
using StructureMap;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace Church.Client.Controllers
{
    public class LogonController : Controller
    {
        [AllowAnonymous]
        [ActionName("Login")]
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [OutputCache(Duration = 259200, Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            var loginStatus = ObjectFactory.GetInstance<ILoginService>().DoLogin(model);
            if (loginStatus == (UserLoginStatus.Success))
            {
                returnUrl = string.IsNullOrEmpty(returnUrl) ? Url.Action("Index", "Home") : returnUrl;
                return Redirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid user name or password");
                return View("Index");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return View("Index");
        }
    }
}