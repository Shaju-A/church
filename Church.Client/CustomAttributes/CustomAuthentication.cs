using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Church.Client.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CustomAuthentication : AuthorizeAttribute
    {
        private bool _isAuthorized;

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            _isAuthorized = base.AuthorizeCore(httpContext);
            return _isAuthorized;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
            || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
            if (!skipAuthorization)
            {
                base.OnAuthorization(filterContext);
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated) return;
            var session = filterContext.HttpContext.Session;
            if (session == null) return;
            filterContext.HttpContext.Response.StatusCode = 401;
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                base.HandleUnauthorizedRequest(filterContext);
                return;
            }
            var url = new UrlHelper(filterContext.RequestContext);
            var loginUrl = url.Action("Index", "Logon");
            session.RemoveAll();
            session.Clear();
            session.Abandon();
            if (loginUrl != null)
            {
                filterContext.HttpContext.Response.AddHeader("Url", loginUrl);
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }
            filterContext.HttpContext.Response.Flush();
            filterContext.HttpContext.Response.End();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            
            if (user == null || !user.Identity.IsAuthenticated)
                filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}