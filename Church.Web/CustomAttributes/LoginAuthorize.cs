using System.Web.Mvc;
using System.IO;
using System.Web;
using System;

namespace Church.Web.CustomAttributes
{
    // IAuthenticationFilter
    public class AuthenticationAttribute : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var message = string.Format("Exception : OnException -> \t{0} -> {1}\t{2}\n",
                                        filterContext.RouteData.Values["controller"].ToString(),
                                        filterContext.RouteData.Values["action"].ToString(),
                                        DateTime.Now.ToString());
            LogExecutionTime(message);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var message = string.Format("Event : OnActionExecuting -> \t{0} -> {1}\t{2}\n",
                                        filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                                        filterContext.ActionDescriptor.ActionName,
                                        DateTime.Now.ToString());
            LogExecutionTime(message);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var message = string.Format("Event : OnActionExecuted -> \t{0} -> {1}\t{2}\n",
                                        filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                                        filterContext.ActionDescriptor.ActionName,
                                        DateTime.Now.ToString());
            LogExecutionTime(message);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var message = string.Format("Event : OnResultExecuting -> \t{0} -> {1}\t{2}\n",
                                        filterContext.RouteData.Values["controller"].ToString(),
                                        filterContext.RouteData.Values["action"].ToString(),
                                        DateTime.Now.ToString());
            LogExecutionTime(message);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var message = string.Format("Event : OnResultExecuted -> \t{0} -> {1}\t{2}\n",
                                        filterContext.RouteData.Values["controller"].ToString(),
                                        filterContext.RouteData.Values["action"].ToString(),
                                        DateTime.Now.ToString());
            LogExecutionTime(message);
        }



        private void LogExecutionTime(string data)
        {
            //File.AppendAllText(HttpContext.Current.Server.MapPath("~/data/data.txt"), data);
        }

        //public void OnAuthentication(AuthenticationContext filterContext)
        //{
        //    if (string.IsNullOrEmpty(filterContext.HttpContext.Session["userid"].ToString()))
        //    {
        //        filterContext.Result = new HttpUnauthorizedResult();
        //    }

        //}

        //public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        //{
        //    if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
        //        filterContext.Result = new ViewResult
        //        {
        //            ViewName = "Error"
        //        };
        //}
    }
}