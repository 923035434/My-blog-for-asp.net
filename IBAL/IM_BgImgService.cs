using IBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public partial interface IM_BgImgService : IBaseService<M_BgImg>
    {
        bool EditEntityFull(List<M_BgImg> entity);
    }
}
