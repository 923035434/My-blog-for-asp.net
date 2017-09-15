using BLL;
using IBLL;
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
    }
}
