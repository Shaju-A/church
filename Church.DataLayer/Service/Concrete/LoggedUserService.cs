using Church.DataLayer.Db.Entity;
using System.Web;
using Newtonsoft.Json;
using System;
using StructureMap;
using Church.DataLayer.Repositories;


namespace Church.DataLayer.Service.Concrete
{
    public class LoggedUserService : ILoggedUserService
    {
        #region IUserService Members

        public User GetLoggedInUser()
        {
            Check();
            var loggedInUser = LoggedInUser();
            return loggedInUser;
        }


        public bool IsLoggedIn()
        {
            return LoggedInUser() != null;
        }

        private static User LoggedInUser()
        {
            var httpContext = HttpContext.Current;
            if (httpContext == null) return null;
            var loggedUserId = httpContext.User.Identity.Name;
            if (httpContext.Session != null)
            {
                var user = httpContext.Session["user"];

                if (httpContext.Items.Contains("user"))
                    return (User) httpContext.Items["user"];

                if (user != null)
                    return (User)user;
                //else if(httpContext.User.Identity.IsAuthenticated && 
                //        !string.IsNullOrEmpty(loggedUserId))
                //{
                //    var userData = ObjectFactory.GetInstance<IUserRepository>().GetUserById(Convert.ToInt32(loggedUserId));
                //    HttpContext.Current.Session["user"] = userData;
                //}
            }

            return null;
        }

        public virtual void Check()
        {
            var httpContext = HttpContext.Current;
            if (!IsLoggedIn())
            {
            }
        }

        public string GetLoggedInUserJson()
        {
            var loggedUser = GetLoggedInUser();
            if (loggedUser == null)
                return
                    JsonConvert.SerializeObject(
                        new
                        {
                            Name = string.Empty,
                            Email = string.Empty,
                            Mobile = string.Empty
                        });
            return
                JsonConvert.SerializeObject(
                    new
                    {
                        loggedUser.Name,
                        loggedUser.Email,
                        loggedUser.Mobile
                    });
        }

        #endregion
    }
}
