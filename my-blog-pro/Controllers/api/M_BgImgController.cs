using BLL;
using IBLL;
using Model;
using my_blog_pro.App_Start;
using my_blog_pro.Models.BlogSetting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace my_blog_pro.Controllers.api
{
    //[RoutePrefix("api/BlogSetting/M_BgImg")]
    [AuthorizeApi]
    public class M_BgImgController : ApiController
    {
        private IBlogSettingService blogSettingService = new BlogSettingService();
        private IM_BgImgService m_bgImgService = new M_BgImgService();

        [Route("api/BlogSetting/M_BgImg")]
        [HttpGet]
        [AllowAnonymous]
        public string Get()
        {
            var m_bgImgList = m_bgImgService.LoadEntites(m => true);
            var data = m_bgImgList.Select(m => new
            {
                id = m.Id,
                blogImg = m.M_BlogImg,
                homeImg = m.M_HomeImg,
                isDelete = m.IsDelete
            });
            var result = new
            {
                code = 0,
                data = data
            };
            return JsonConvert.SerializeObject(result);
        }

        [Route("api/BlogSetting/M_BgImg/Select")]
        [HttpGet]
        [AllowAnonymous]
        public string GetSelect()
        {
            var settingItem = blogSettingService.LoadEntites(m => true).FirstOrDefault();
            if (settingItem == null)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 404,
                    data = "没有找到该目标"
                });
            }
            var item = (from i in settingItem.M_BgImg
                        where i.IsDelete == 1
                        select i).FirstOrDefault();
            if (item == null)
            {
                return "";
            }
            var result = new
            {
                id = item.Id,
                blogImg = item.M_BlogImg,
                homeImg = item.M_HomeImg
            };
            return JsonConvert.SerializeObject(new
            {
                code = 0,
                data = result
            });

        }

        [Route("api/BlogSetting/M_BgImg")]
        [HttpPost]
        public string Post()
        {
            var blogSettingItem = blogSettingService.LoadEntites(b => true).FirstOrDefault();
            if (blogSettingItem == null)
            {
                return JsonConvert.SerializeObject(
                new
                {
                    code = 404,
                    message = "Do not have this service"
                });
            }
            var item = m_bgImgService.AddEntity(new M_BgImg
            {
                M_BlogImg = "",
                M_HomeImg = "",
                IsDelete = 1,
                BlogSetting = blogSettingItem
            });
            var result = new
            {
                code = 0,
                data = new
                {
                    id = item.Id,
                    blogImg = item.M_BlogImg,
                    homeImg = item.M_HomeImg,
                    isDelete = item.IsDelete
                }
            };
            return JsonConvert.SerializeObject(result);
        }

        [Route("api/BlogSetting/M_BgImg")]
        [HttpPut]
        public string Put([FromBody] M_BgImgPut param)
        {
            if (param.Id == null)
            {
                return JsonConvert.SerializeObject(new { code = 404, message = "没有找到相应的资源" });
            }
            if (param.IsDelete != null)
            {
                var m_bgImgList = m_bgImgService.LoadEntites(m => true).ToList();
                foreach (var item in m_bgImgList)
                {
                    item.IsDelete = item.Id == param.Id ? 1 : 0;                    
                }
                m_bgImgService.EditEntityFull(m_bgImgList);

            }
            var m_blImgItem = m_bgImgService.LoadEntites(m => m.Id == param.Id).FirstOrDefault();
            if (m_blImgItem == null)
            {
                return JsonConvert.SerializeObject(new { code = 404, message = "没有找到相应的资源" });
            }
            m_blImgItem.M_HomeImg = param.M_HomeImg ?? m_blImgItem.M_HomeImg;
            m_blImgItem.M_BlogImg = param.M_BlogImg ?? m_blImgItem.M_BlogImg;
            m_bgImgService.EditEntity(m_blImgItem);
            var result = new
            {
                code = 0,
                message = "修改成功"
            };
            return JsonConvert.SerializeObject(result);
        }

        [Route("api/BlogSetting/M_BgImg")]
        [HttpDelete]
        public string Delete(M_BgImgDlete param)
        {
            if (param.id == null)
            {
                return JsonConvert.SerializeObject(new {
                    code=404,
                    message="参数错误"
                });
            }
            var item = m_bgImgService.LoadEntites(m => m.Id == param.id).FirstOrDefault();
            if (item == null)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 404,
                    message = "没有找到要删除的对象"
                });
            }
            m_bgImgService.DeleteEntity(item);
            return JsonConvert.SerializeObject(new
            {
                code = 0,
                message = "删除成功"
            });
        }
    }
}
