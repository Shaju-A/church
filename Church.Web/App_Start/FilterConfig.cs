using Church.Web.CustomAttributes;
using System.Web.Mvc;

namespace Church.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthenticationAttribute());
        }
    }
}
