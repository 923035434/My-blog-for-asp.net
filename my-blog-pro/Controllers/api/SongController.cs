using BLL;
using IBLL;
using my_blog_pro.App_Start;
using my_blog_pro.Models.Song;
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
    public class SongController : ApiController
    {
        ISongService songService = new SongService();
        ISingerService singerService = new SingerService();
        [AllowAnonymous]
        public string Get()
        {
            var songList = songService.LoadEntites(s => true);
            var data = from song in songList
                       select new
                       {
                           id = song.Id,
                           musicId = song.MusicId,
                           name = song.Name,
                           imgUrl = song.ImgUrl,
                           albumName = song.AlbumName,
                           singeId = song.SingerId,
                           url = song.Url
                       };
            return JsonConvert.SerializeObject(new
            {
                code = 0,
                data = data
            });
        }

        public string Post(SongPostItem param)
        {
            if (param.SingerId == null
                || param.Name == null
                || param.ImgUrl == null
                || param.MusicId == null
                || param.Url == null
                || param.AlbumName == null)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 500,
                    message = "参数错误"
                });
            }
            var singer = singerService.LoadEntites(p => p.Id == param.SingerId).FirstOrDefault();
            if (singer == null)
            {
                return JsonConvert.SerializeObject(new {
                    code = 404,
                    message = "不存在目标"
                });
            }
            if (songService.LoadEntites(s => s.MusicId == param.MusicId).Count() > 0)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 500,
                    message = "改歌曲已存在"
                });
            }
            var song = songService.AddEntity(new Model.Song {
                AlbumName = param.AlbumName,
                Singer = singer,
                Url = param.Url,
                Name = param.Name,
                MusicId = param.MusicId,
                ImgUrl = param.ImgUrl,
            });
            return JsonConvert.SerializeObject(new {
                code = 0,
                data = new {
                    id = song.Id,
                    musicId = song.MusicId,
                    name = song.Name,
                    imgUrl = song.ImgUrl,
                    albumName = song.AlbumName,
                    singeId = song.SingerId,
                    url = song.Url
                },
                message = "添加成功"
            });
        }

        public string Put()
        {
            return JsonConvert.SerializeObject(new {
                code = 404,
                message = "没有该服务"
            });
        }

        public string Delete(int? id)
        {
            if (id == null)
            {
                return JsonConvert.SerializeObject(new {
                    code = 500,
                    message = "参数不正确"
                });
            }
            var song = songService.LoadEntites(s => s.Id == id).FirstOrDefault();
            if (song == null)
            {
                return JsonConvert.SerializeObject(new
                {
                    code = 404,
                    message = "没有找到该目标"
                });
            }
            songService.DeleteEntity(song);
            return JsonConvert.SerializeObject(new {
                code = 0,
                message = "删除成功"
            });
        }

        [Route("~/api/singer/{singerId:int}/song")]
        [AllowAnonymous]
        public string GetSongListFor(int singerId) {
            var singer = singerService.LoadEntites(s => s.Id == singerId).FirstOrDefault();
            if (singer == null)
            {
                return JsonConvert.SerializeObject(new {
                    code = 404,
                    message = "不存在该歌手"
                });
            }
            var data = from song in singer.Song
                       select new {
                           id = song.Id,
                           musicId = song.MusicId,
                           name = song.Name,
                           imgUrl = song.ImgUrl,
                           albumName = song.AlbumName,
                           singeId = song.SingerId,
                           url = song.Url
                       };
            return JsonConvert.SerializeObject(new {
                code = 0,
                data = data
            });
        }
    }
}
