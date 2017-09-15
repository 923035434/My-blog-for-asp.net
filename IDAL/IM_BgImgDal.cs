using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public partial interface IM_BgImgDal : IBaseDal<M_BgImg>
    {
        bool EditEntityFull(List<M_BgImg> entity);
    }
}
