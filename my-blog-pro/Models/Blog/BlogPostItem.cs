using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_blog_pro.Models.Blog
{
    public class BlogPostItem
    {
        public int? TypeId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImgUrl { get; set; }
        public string HtmlContent { get; set; }
        public string Time { get; set; }
    }
}