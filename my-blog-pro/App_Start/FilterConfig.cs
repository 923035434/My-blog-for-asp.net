using my_blog_pro.App_Start;
using System.Web;
using System.Web.Mvc;

namespace my_blog_pro
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MyExceptionAttribute());
        }
    }
}
