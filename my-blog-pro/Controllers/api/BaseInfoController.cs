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
    [RoutePrefix("api/BlogSetting/BaseInfo")]
    [AuthorizeApi]
    public class BaseInfoController : ApiController
    {
        private IBlogSettingService blogSettingService = new BlogSettingService();
        private IM_BgImgService m_bgImgService = new M_BgImgService();

        [Route("")]
        [AllowAnonymous]
        public string Get()
        {
            BlogSetting settingInfo = blogSettingService.LoadEntites(b => true).FirstOrDefault();
            if (settingInfo == null)
            {

                settingInfo = blogSettingService.AddEntity(new BlogSetting
                {
                    UserName = "刘先森。",
                    Avatar = "",
                    Signature = "嘻嘻",
                    Address = "广州",
                });

                m_bgImgService.AddEntity(
                new M_BgImg
                {
                    IsDelete = 1,
                    M_BlogImg = "",
                    M_HomeImg = "",
                    BlogSetting = settingInfo
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

        [Route("")]
        public string Post([FromBody] BaseInfoPostItem param)
        {
            var result = new
            {
                code = 404,
                message = "Do not have this service"
            };
            return JsonConvert.SerializeObject(result);
        }

        [Route("")]
        public string Put([FromBody] BaseInfoPutItem param)
        {
            BlogSetting settingInfo = blogSettingService.LoadEntites(b => true).FirstOrDefault();
            if (settingInfo == null)
            {

                settingInfo = blogSettingService.AddEntity(new BlogSetting
                {
                    UserName = "刘先森。",
                    Avatar = "",
                    Signature = "嘻嘻",
                    Address = "广州"
                });
                var m_bgImg = m_bgImgService.AddEntity(
                    new M_BgImg
                    {
                        IsDelete = 1,
                        M_BlogImg = "",
                        M_HomeImg = "",
                        BlogSetting = settingInfo
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

        [Route("")]
        public string Delete(int id)
        {
            var result = new
            {
                code = 404,
                message = "Do not have this service"
            };
            return JsonConvert.SerializeObject(result);
        }
    }    
}
