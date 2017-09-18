using IBLL;
using BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using my_blog_pro.Models.BlogType;
using Model;

namespace my_blog_pro.Controllers.api
{
    public class BlogTypeController : ApiController
    {
        IBlogTypeService blogTypeService = new BlogTypeService();
        public string Get()
        {
            var result = blogTypeService.LoadEntites(b => true).OrderBy(b => b.Rank).Select(b => new {
                id = b.Id,
                name = b.TypeName,
                rank = b.Rank
            });
            return JsonConvert.SerializeObject(new {
                code=0,
                data=result
            });
        }

        public string Post(BlogTypePostItem param)
        {
            if (param.Name == null || param.Rank == null)
            {
                return JsonConvert.SerializeObject(new {
                    code = 500,
                    message = "参数错误"
                });
            }
            var item = blogTypeService.AddEntity(new BlogType {
                TypeName = param.Name,
                Rank = (int)param.Rank
            });
            return JsonConvert.SerializeObject(new {
                code = 0,
                message = "添加成功",
                data = new {
                    id =item.Id,
                    name = item.TypeName,
                    rank = item.Rank
                }
            });
        }

        public string Put(int? id,[FromBody] BlogTypePostItem param)
        {
            if (id == null)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 500,
                    message = "参数错误"
                });
            }            
            var blogTypeItem = blogTypeService.LoadEntites(b => b.Id == id).First();
            if (blogTypeItem == null)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 404,
                    message = "没有找到该类型"
                });
            }
            blogTypeItem.TypeName = param.Name ?? blogTypeItem.TypeName;
            blogTypeItem.Rank = param.Rank ?? blogTypeItem.Rank;
            blogTypeService.EditEntity(blogTypeItem);
            return JsonConvert.SerializeObject(new {
                code = 0,
                message = "修改成功"
            });
        }
        public string Delete(int? id)
        {
            if (id == null)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 500,
                    message = "参数错误"
                });
            }
            var item = blogTypeService.LoadEntites(b => b.Id == id).FirstOrDefault();
            if (item == null)
            {
                return JsonConvert.SerializeObject(new {
                    code = 404,
                    message = "没有找到该类型"
                });
            }
            blogTypeService.DeleteEntity(item);
            return JsonConvert.SerializeObject(new {
                code = 0,
                message = "删除成功"
            });
        }
    }
}
