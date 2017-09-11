using DAL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DALFactory
{
    public partial class DBSession : IDBSession
    {
        public DbContext Db
        {
            get { return DBContextFactory.CreateDbContext(); }
        }

        //统一映射数据库
        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;
        }
    }
}
