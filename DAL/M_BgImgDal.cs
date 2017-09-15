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
    public partial class M_BgImgDal : BaseDal<M_BgImg>, IM_BgImgDal
    {
        public bool EditEntityFull(List<M_BgImg> entity)
        {
            foreach (var item in entity)
            {
                db.Entry(item).State = EntityState.Modified;
            }
            return true;
        }
    }
}
