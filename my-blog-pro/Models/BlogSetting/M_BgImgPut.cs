using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_blog_pro.Models.BlogSetting
{
    public class M_BgImgPut
    {
        public int? Id { get; set; }
        public string M_HomeImg { get; set; }
        public string M_BlogImg { get; set; }
        public int? IsDelete { get; set; }
    }
}