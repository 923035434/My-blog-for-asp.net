using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_blog_pro.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            string userInfo = null;
            if (Request.Cookies["userInfo"] != null)
            {
                userInfo = Request.Cookies["userInfo"].Value;
            }
            ViewBag.userInfo = userInfo;
            return View();
        }
    }
}