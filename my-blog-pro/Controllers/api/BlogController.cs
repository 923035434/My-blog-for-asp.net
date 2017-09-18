using BLL;
using IBLL;
using Model;
using my_blog_pro.Models.Blog;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace my_blog_pro.Controllers.api
{
    public class BlogController : ApiController
    {

        IBlogService blogService = new BlogService();
        IBlogTypeService blogTypeService = new BlogTypeService();
        IUserInfoService userInfoService = new UserInfoService();
        public string Get()
        {
            var blogTypeList = blogTypeService.LoadEntites(b => true);
            var data = from bt in blogTypeList
                       select new
                       {
                           id = bt.Id,
                           name = bt.TypeName,
                           blogs = bt.Blog
                       };
            return JsonConvert.SerializeObject(new {
                code = 0                
            });
        }

        public string Post(BlogPostItem param)
        {
            if (param.Title == null 
                || param.ImgUrl == null 
                || param.Desc == null 
                || param.time == null 
                || param.TypeId == null 
                || param.HtmlContent == null)
            {
                return JsonConvert.SerializeObject(new {
                    code = 500,
                    message = "参数错误"
                });
            }
            var blogType = blogTypeService.LoadEntites(b => b.Id == param.TypeId).FirstOrDefault();
            if (blogType == null)
            {
                return JsonConvert.SerializeObject(new {
                    code = 404,
                    message = "没有找到该类型"
                });
            }            
             blogService.AddEntity(new Blog
            {
                BlogType = blogType,
                Title = param.Title,
                Description = param.Desc,
                ImgUrl = param.ImgUrl,
                HtmlContent = param.HtmlContent,
                Time = param.time
            });
            return JsonConvert.SerializeObject(new { });
        }
        public string Put()
        {
            return JsonConvert.SerializeObject(new { });
        }
        public string Delete()
        {
            return JsonConvert.SerializeObject(new { });
        }
    }
}
