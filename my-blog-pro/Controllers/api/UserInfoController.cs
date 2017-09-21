using BLL;
using IBLL;
using Model;
using my_blog_pro.Models.UserInfo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace my_blog_pro.Controllers.api
{
    public class UserInfoController : ApiController
    {
        IUserInfoService userInfoService = new UserInfoService();
        public string Put([FromBody]UserInfoPutItem param)
        {
            UserInfo user = (UserInfo)HttpContext.Current.Session["user"];
            user = userInfoService.LoadEntites(u => user.Id == u.Id).FirstOrDefault();
            if (user == null)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 500,
                    message = "没有找到该用户"
                });
            }
            string password = user.PassWord;
            if (param.OldPassword != password)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 500,
                    message = "输入密码不正确"
                });
            }
            user.PassWord = param.NewPassWord;
            userInfoService.EditEntity(user);
            HttpContext.Current.Session["user"] = user;
            return JsonConvert.SerializeObject(new
            {
                code = 0,
                message = "修改成功"
            });
        }
    }
}
