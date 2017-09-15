using BLL;
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
    public partial class M_BgImgService : BaseService<M_BgImg>, IM_BgImgService
    {
        public bool EditEntityFull(List<M_BgImg> entity)
        {
            var dal = CurrentDal as IM_BgImgDal;
            dal.EditEntityFull(entity);
            return CurrentDBSession.SaveChanges();
        }
    }
}
