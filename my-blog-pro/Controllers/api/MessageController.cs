﻿using BLL;
using IBLL;
using Model;
using my_blog_pro.Models.Message;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace my_blog_pro.Controllers.api
{
    public class MessageController : ApiController
    {
        IMessageService messageService = new MessageService();
        public string Get()
        {
            var list = messageService.LoadEntites(m => true);
            var result = from m in list
                         select new
                         {
                             id = m.Id,
                             name = m.Name,
                             phone = m.Phone,
                             time = m.Time,
                             emial = m.Emial
                         };
            return JsonConvert.SerializeObject(new
            {
                code = 0,
                data = result
            });
        }

        public string Post([FromBody]MessagePost param)
        {
            if (param.Name == null
                || param.Phone == null
                || param.Email == null
                || param.Content == null
                || param.Time == null
                )
            {
                return JsonConvert.SerializeObject(new
                {
                    code=500,
                    message="param error"
                });
            }
            messageService.AddEntity(new Message
            {
                Name = param.Name,
                Phone = param.Phone,
                Emial = param.Email,
                Content = param.Content,
                Time = param.Time
            });
            return JsonConvert.SerializeObject(new
            {
                code = 0,
                message = "留言成功"
            });
        }

        public string Put([FromBody]MessagePost param)
        {
            return JsonConvert.SerializeObject(new
            {
                code = 404,
                message = "服务未开放"
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
            var message = messageService.LoadEntites(m => m.Id == id).FirstOrDefault();
            if (message == null)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 404,
                    message = "没有找到对应的消息"
                });
            }
            messageService.DeleteEntity(message);
            return JsonConvert.SerializeObject(new
            {
                code = 0,
                message = "删除成功"
            });
        }
    }
}
