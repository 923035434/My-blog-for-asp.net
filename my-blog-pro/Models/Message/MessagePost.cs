using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_blog_pro.Models.Message
{
    public class MessagePost
    {
        public string Email { get; set; }
        public string Name { get; set; }        
        public string Content { get; set; }
        public string Time { get; set; }
    }
}