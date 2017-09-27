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
            return Redirect("/Show/P");
            return View();
        }

        public ActionResult P()
        {
            return View();
        }

        public ActionResult M()
        {
            return View();
        }
    }
}