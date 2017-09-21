using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_blog_pro.Models.UserInfo
{
    public class UserInfoPutItem
    {
        public string OldPassword { get; set; }
        public string NewPassWord { get; set; }
    }
}