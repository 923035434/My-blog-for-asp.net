using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace my_blog_pro.App_Start
{
    public class MyApiExceptionAttribute: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);
            Exception e = actionExecutedContext.Exception;
            MyExceptionAttribute.ExceptionQueue.Enqueue(e);
        }
    }
}