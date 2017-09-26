using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_blog_pro.Controllers
{
    public class ShowController : Controller
    {
        // GET: Show
        public ActionResult Index()
        {
            return Redirect("/Show/M");
            return View();
        }

        public ActionResult M()
        {
            return View();
        }
    }
}