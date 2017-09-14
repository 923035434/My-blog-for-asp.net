using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_blog_pro.Models
{
    public class LoginItem
    {
        public string account { get; set; }
        public string password { get; set; }
        public bool ifChecked { get; set; }
    }
}