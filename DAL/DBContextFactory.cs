using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public class DBContextFactory
    {
        /// <summary>
        /// 创建线程内唯一的ef对象
        /// </summary>
        /// <returns></returns>
        public static DbContext CreateDbContext()
        {
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new Model1Container();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
