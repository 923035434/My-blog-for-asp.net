using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.ModelBinding;

namespace my_blog_pro.Controllers.api
{
    public class loginController : ApiController
    {
        public void Post()
        {
            var form = HttpContext.Current.Request.Form;
        }
    }
}
