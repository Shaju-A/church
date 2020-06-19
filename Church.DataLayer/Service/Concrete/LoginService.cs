using System;
using Church.DataLayer.Models;
using Church.DataLayer.Repositories;
using StructureMap;
using System.Web;
using System.Web.Security;

namespace Church.DataLayer.Service.Concrete
{
    public class LoginService : ILoginService
    {
        public UserLoginStatus DoLogin(LoginModel loginModel)
        {
            var user = ObjectFactory.GetInstance<IUserRepository>().GetUserByMail(loginModel.Email);
            if (user == null)
                return UserLoginStatus.UserNotFound;
            
            if (user.Id != default(int))
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);

                var authenticationTicket =
                   new FormsAuthenticationTicket(
                       1,
                       user.Name.Trim(),
                       DateTime.Now,
                       DateTime.Now.AddMinutes(120),
                       true,
                       user.Id.ToString().Trim()
                       );
                var cookie = new HttpCookie(
                    FormsAuthentication.FormsCookieName,
                    FormsAuthentication.Encrypt(authenticationTicket));
                HttpContext.Current.Response.Cookies.Add(cookie);

                HttpContext.Current.Items.Add("user", user);
                HttpContext.Current.Session["user"] = user;

                //string encTicket = FormsAuthentication.Encrypt(authenticationTicket);
                //HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                //HttpContext.Current.Items.Add("user", user);
                
                return UserLoginStatus.Success;
            }

            return UserLoginStatus.Fail;
        }
    }
}
