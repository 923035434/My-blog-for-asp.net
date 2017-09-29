using BLL;
using IBLL;
using Model;
using my_blog_pro.App_Start;
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
    [AuthorizeApi]
    public class BlogController : ApiController
    {

        IBlogService blogService = new BlogService();
        IBlogTypeService blogTypeService = new BlogTypeService();
        IUserInfoService userInfoService = new UserInfoService();
        [AllowAnonymous]
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
                        Title = blog.Title,
                        Views = blog.Views
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
                Time = param.Time,
                Views = 0
             });
            BlogBackItem data = new BlogBackItem
            {
                Id = item.Id,
                BlogTypeId = (int)item.BlogTypeId,
                Description = item.Description,
                HtmlContent = item.HtmlContent,
                ImgUrl = item.ImgUrl,
                Time = item.Time,
                Title = item.Title,
                Views = item.Views
            };
            return JsonConvert.SerializeObject(new {
                code = 0,
                data = data
            });
        }
        public string Put(int? id,[FromBody] BlogPutItem param)
        {
            if (id == null)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 404,
                    message = "请选择正确的目标"
                });
            }
            if (param.TypeId == null
                || param.Title==null
                || param.Desc == null
                || param.ImgUrl == null
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
                    code = "500",
                    message = "请选择正确的类型"
                });
            }
            var blog = blogService.LoadEntites(b => b.Id == id).FirstOrDefault();
            blog.Title = param.Title;
            blog.Description = param.Desc;
            blog.ImgUrl = param.ImgUrl;
            blog.HtmlContent = param.HtmlContent;
            blog.BlogType = blogType;
            blogService.EditEntity(blog);
            return JsonConvert.SerializeObject(new {
                code = 0,
                message = "修改成功"
            });
        }
        public string Delete(int? id)
        {
            if (id == null)
            {
                return JsonConvert.SerializeObject(new {
                    code = 404,
                    message = "请选择正确的目标"
                });
            }
            var blogItem = blogService.LoadEntites(b => b.Id == id).FirstOrDefault();
            if (blogItem == null)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 404,
                    message = "没有找到要删除的目标"
                });
            }
            blogService.DeleteEntity(blogItem);
            return JsonConvert.SerializeObject(new {
                code = 0,
                message = "删除成功"
            });
        }
        [HttpPost]
        [Route("~/api/Blog/{blogId:int}/AddViews")]
        [AllowAnonymous]
        public string AddViews(int blogId)
        {
            var blog = blogService.LoadEntites(b => b.Id == blogId).FirstOrDefault();
            if (blog == null)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 404,
                    message = "没有找到该目标"
                });
            }
            blog.Views++;
            blogService.EditEntity(blog);
            return JsonConvert.SerializeObject(new
            {
                code = 0,
                message = "成功"
            });
        }
        [HttpGet]
        [Route("~/api/Blog/GetCount")]
        [AllowAnonymous]
        public string GetCount()
        {
            var blogs = blogService.LoadEntites(b => true);
            if (blogs == null)
            {
                return "";
            }
            int ViewCount = (from b in blogs
                        select b.Views).Sum();
            int blogCount = blogs.Count();
            return JsonConvert.SerializeObject(new {
                code = 0,
                data = new {
                    view = ViewCount,
                    blog = blogCount
                }
            });
        }
    }
}
