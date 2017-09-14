using BLL;
using IBLL;
using Model;
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
    public class BlogSettingController : ApiController
    {

        private IBlogSettingService blogSettingService = new BlogSettingService();
        private IM_BgImgService m_bgImgService = new M_BgImgService();

        [HttpGet]
        public string BaseInfo()
        {
            BlogSetting settingInfo = blogSettingService.LoadEntites(b => true).FirstOrDefault();
            if (settingInfo == null)
            {
                var m_bgImg = m_bgImgService.AddEntity(
                new M_BgImg
                {
                    IsDelete = 1,
                    M_BlogImg = "",
                    M_HomeImg = ""
                });
                settingInfo = blogSettingService.AddEntity(new BlogSetting
                {
                    UserName = "刘先森。",
                    Avatar = "",
                    Signature = "嘻嘻",
                    Address = "广州",
                    M_BgImg = m_bgImg
                });
            }
            var result = new
            {
                code = 0,
                data = new
                {
                    userName = settingInfo.UserName,
                    avatar = settingInfo.Avatar,
                    signature = settingInfo.Signature,
                    address = settingInfo.Address
                }
            };
            return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string BaseInfo([FromBody] BaseInfoPostItem param)
        {
            var result = new
            {
                code = 404,
                message = "Do not have this service"
            };
            return JsonConvert.SerializeObject(result);
        }

        [HttpPut]
        public string BaseInfo([FromBody] BaseInfoPutItem param)
        {
            BlogSetting settingInfo = blogSettingService.LoadEntites(b => true).FirstOrDefault();
            if (settingInfo == null)
            {
                var m_bgImg = m_bgImgService.AddEntity(
                new M_BgImg
                {
                    IsDelete = 1,
                    M_BlogImg = "",
                    M_HomeImg = ""
                });
                settingInfo = blogSettingService.AddEntity(new BlogSetting
                {
                    UserName = "刘先森。",
                    Avatar = "",
                    Signature = "嘻嘻",
                    Address = "广州",
                    M_BgImg = m_bgImg
                });
            }
            settingInfo.UserName = param.UserName ?? settingInfo.UserName;
            settingInfo.Avatar = param.Avatar ?? settingInfo.Avatar;
            settingInfo.Signature = param.Signature ?? settingInfo.Signature;
            settingInfo.Address = param.Address ?? settingInfo.Address;
            blogSettingService.EditEntity(settingInfo);
            var result = new
            {
                code = 0,
                data = new
                {
                    userName = settingInfo.UserName,
                    avatar = settingInfo.Avatar,
                    signature = settingInfo.Signature,
                    address = settingInfo.Address
                }
            };
            return JsonConvert.SerializeObject(result);
        }

        [HttpDelete]
        public string BaseInfo(int id)
        {
            var result = new
            {
                code = 404,
                message = "Do not have this service"
            };
            return JsonConvert.SerializeObject(result);
        }

        [HttpGet]
        public string M_BgImg(int? isDelete)
        {            
            if (isDelete != null)
            {
                var item = m_bgImgService.LoadEntites(m => m.IsDelete == isDelete).FirstOrDefault();
                return JsonConvert.SerializeObject(new {
                    code = 0,
                    data = new {
                        id = item.Id,
                        blogImg = item.M_BlogImg,
                        homeImg = item.M_HomeImg
                    }
                });
            }
            var m_bgImgList = m_bgImgService.LoadEntites(m => true);
            var data = m_bgImgList.Select(m => new
            {
                id = m.Id,
                blogImg = m.M_BlogImg,
                homeImg = m.M_HomeImg
            });
            var result = new
            {
                code = 0,
                data = data
            };
            return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string M_BgImg()
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
                IsDelete = 0,
                BlogSetting = blogSettingItem
            });
            var result = new
            {
                code = 0,
                data = new
                {
                    id = item.Id,
                    blogImg = item.M_BlogImg,
                    homeImg = item.M_HomeImg
                }
            };
            return JsonConvert.SerializeObject(result);
        }

        [HttpPut]
        public string M_BgImg([FromBody] M_BgImgPut param)
        {
            if (param.Id == null)
            {
                return JsonConvert.SerializeObject(new { code = 404, message = "没有找到相应的资源" });
            }
            if (param.IsDelete != null)
            {
                var m_bgImgList = m_bgImgService.LoadEntites(m => true);
                foreach (var item in m_bgImgList)
                {
                    item.IsDelete = item.Id == param.Id ? 1 : 0;
                    m_bgImgService.EditEntity(item);
                }
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
    }
}
