using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IBLL
{
    public interface IBaseService<T> where T : class, new()
    {
        IDBSession CurrentDBSession { get; }
        IDAL.IBaseDal<T> CurrentDal { get; set; }
        IQueryable<T> LoadEntites(Expression<Func<T, bool>> wherelambda);
        IQueryable<T> LoadPageEntites<s>(int pageIndex, int pageSize, out int pageCount, Expression<Func<T, bool>> wherelambda, Expression<Func<T, s>> orderbyLambda, bool isAsc);
        T AddEntity(T entity);
        bool DeleteEntity(T entity);
        bool EditEntity(T entity);
    }
}
