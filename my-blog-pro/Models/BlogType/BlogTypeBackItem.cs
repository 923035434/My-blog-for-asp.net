using my_blog_pro.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_blog_pro.Models.BlogType
{
    public class BlogTypeBackItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public int rank { get; set; }
        public IList<BlogBackItem> blogs { get; set; }
    }
}