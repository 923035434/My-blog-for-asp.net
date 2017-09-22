using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public partial interface ISongService : IBaseService<Song>
    {
        bool DeleteEntityFull(List<Song> songList);
    }
}
