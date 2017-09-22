using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_blog_pro.Models.Song
{
    public class SongPostItem
    {
        public int? SingerId { get; set; }
        public string MusicId { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string AlbumName { get; set; }        
        public string Url { get; set; }        
    }
}