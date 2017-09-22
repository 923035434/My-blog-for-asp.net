using DAL;
using IBLL;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class SongService : BaseService<Song>, ISongService
    {
        public bool DeleteEntityFull(List<Song> songList)
        {
            ISongDal songDal = (SongDal)this.CurrentDal;
            songDal.DeleteEntityFull(songList);
            return CurrentDBSession.SaveChanges();
        }
    }
}
