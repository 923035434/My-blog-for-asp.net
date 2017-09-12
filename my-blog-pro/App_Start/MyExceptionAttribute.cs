using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_blog_pro.App_Start
{
    public class MyExceptionAttribute : HandleErrorAttribute
    {
        public static Queue<Exception> ExceptionQueue = new Queue<Exception>();
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Exception ex = filterContext.Exception;
            ExceptionQueue.Enqueue(ex);
            //filterContext.HttpContext.Response.Redirect();
        }
    }
}