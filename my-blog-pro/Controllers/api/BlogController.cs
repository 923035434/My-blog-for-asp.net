using BLL;
using IBLL;
using Model;
using my_blog_pro.Models.Blog;
using my_blog_pro.Models.BlogType;
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
            List<BlogTypeBackItem> data = new List<BlogTypeBackItem>();
            foreach (var blogType in blogTypeList)
            {
                List<BlogBackItem> tempBlogList = new List<BlogBackItem>();
                BlogTypeBackItem tempBlogType = new BlogTypeBackItem {
                    id = blogType.Id,
                    name = blogType.TypeName,
                    rank = blogType.Rank,
                    blogs = tempBlogList
                };
                foreach (var blog in blogType.Blog)
                {
                    tempBlogType.blogs.Add(new BlogBackItem
                    {
                        Id = blog.Id,
                        BlogTypeId = (int)blog.BlogTypeId,
                        Description = blog.Description,
                        HtmlContent = blog.HtmlContent,
                        ImgUrl = blog.ImgUrl,
                        Time = blog.Time,
                        Title = blog.Title
                    });
                }
                data.Add(tempBlogType);
            }
            
            return JsonConvert.SerializeObject(new {
                code = 0,
                data = data
            });
        }

        public string Post(BlogPostItem param)
        {
            if (param.Title == null 
                || param.ImgUrl == null 
                || param.Desc == null 
                || param.Time == null 
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
             var item =  blogService.AddEntity(new Blog
            {
                BlogType = blogType,
                Title = param.Title,
                Description = param.Desc,
                ImgUrl = param.ImgUrl,
                HtmlContent = param.HtmlContent,
                Time = param.Time
             });
            BlogBackItem data = new BlogBackItem
            {
                Id = item.Id,
                BlogTypeId = (int)item.BlogTypeId,
                Description = item.Description,
                HtmlContent = item.HtmlContent,
                ImgUrl = item.ImgUrl,
                Time = item.Time,
                Title = item.Title

            };
            return JsonConvert.SerializeObject(new {
                code = 0,
                data = data
            });
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
