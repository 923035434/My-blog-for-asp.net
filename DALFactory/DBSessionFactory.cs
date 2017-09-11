using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace DALFactory
{
    public class DBSessionFactory
    {
        public static IDBSession CreateDBSession()
        {
            IDBSession dbsession = (IDBSession)CallContext.GetData("dbsession");
            if (dbsession == null)
            {
                dbsession = new DBSession();
                CallContext.SetData("dbsession", dbsession);
            }
            return dbsession;
        }
    }
}
