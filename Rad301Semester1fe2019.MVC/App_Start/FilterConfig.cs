using System.Web;
using System.Web.Mvc;

namespace Rad301Semester1fe2019.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
