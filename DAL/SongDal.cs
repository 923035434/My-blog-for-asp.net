using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class SongDal : BaseDal<Song>, ISongDal
    {
        public bool DeleteEntityFull(List<Song> songList)
        {
            foreach (var song in songList)
            {
                this.db.Entry<Song>(song).State = EntityState.Deleted;
            }
            return true;
        }
    }
}
