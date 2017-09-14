using BLL;
using IBLL;
using Model;
using my_blog_pro.Models;
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
        //public void Post()
        //{
        //    var form = HttpContext.Current.Request.Form;
        //}
        IUserInfoService userInfoService = new UserInfoService();
        public string Post([FromBody] LoginItem param)
        {
            UserInfo user = userInfoService.LoadEntites(u => u.Account == param.account).FirstOrDefault();
            if (user == null || param.password!= user.PassWord)
            {
                return JsonConvert.SerializeObject(new { code = 404, message = "输入信息有误"});
            }
            HttpContext context = HttpContext.Current;
            if (param.ifChecked)
            {
                context.Response.Cookies["userInfo"].Value = JsonConvert.SerializeObject(new { account = param.account, password = param.password });
                context.Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(10);
            }
            else
            {
                context.Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(-1);
            }
            context.Session["user"] = user;
            return JsonConvert.SerializeObject(new { code = 0, message = "登录成功", redirectUrl="/Admin" });
        }
    }
}
