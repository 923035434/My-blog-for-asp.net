using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public partial interface ISongDal : IBaseDal<Song>
    {
        bool DeleteEntityFull(List<Song> songList);        
    }
}
