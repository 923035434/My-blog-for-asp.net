using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_blog_pro.Models.Blog
{
    public class BlogBackItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string HtmlContent { get; set; }
        public string Time { get; set; }
        public int BlogTypeId { get; set; }
        public int Views { get; set; }
    }
}