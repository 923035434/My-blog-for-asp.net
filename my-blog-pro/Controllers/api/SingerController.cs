using BLL;
using IBLL;
using my_blog_pro.App_Start;
using my_blog_pro.Models.Singer;
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
    public class SingerController : ApiController
    {

        ISingerService singerService = new SingerService();
        ISongService songService = new SongService();
        [AllowAnonymous]
        public string Get()
        {
            var singerList = singerService.LoadEntites(s => true);
            var data = from singer in singerList
                       select new {
                           id = singer.Id,
                           singerId = singer.SingerId,
                           img = singer.ImgUrl,
                           name = singer.Name                           
                       };
            return JsonConvert.SerializeObject(new {
                code = 0,
                data = data
            });
        }

        public string Post([FromBody]SingerPostItem param)
        {
            if (param.ImgUrl == null|| param.Name == null|| param.SingerId == null)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 500,
                    message = "参数错误"
                });
            }
            var singer = singerService.LoadEntites(s => s.SingerId == param.SingerId).FirstOrDefault();
            if (singer != null)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 500,
                    message = "添加失败，已经存在该歌手"
                });
            }
            var data = singerService.AddEntity(new Model.Singer {
                SingerId = param.SingerId,
                ImgUrl = param.ImgUrl,
                Name = param.Name                
            });
            return JsonConvert.SerializeObject(new {
                code = 0,
                data = new {
                    id = data.Id,
                    singerId = data.SingerId,
                    img = data.ImgUrl,
                    name = data.Name
                },
                message = "添加成功"
            });
        }

        public string Put()
        {
            return JsonConvert.SerializeObject(new {
                code = "404",
                message = "不存在该服务"
            });
        }

        public string Delete(int? id)
        {
            if (id == null)
            {
                return JsonConvert.SerializeObject(new {
                    code = 500,
                    message = "参数错误"
                });
            }
            var singer = singerService.LoadEntites(s => s.Id == id).FirstOrDefault();
            if (singer == null)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 404,
                    message = "没有找到该目标"
                });
            }
            var songList = singer.Song.ToList();
            songService.DeleteEntityFull(songList);
            singerService.DeleteEntity(singer);
            return JsonConvert.SerializeObject(new {
                code = 0,
                message = "删除成功"
            });
        }
    }
}
