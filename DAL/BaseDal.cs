using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    public class BaseDal<T> where T : class, new()
    {
        public DbContext db = DBContextFactory.CreateDbContext();
        public T AddEntity(T entity)
        {
            db.Set<T>().Add(entity);
            return entity;
        }

        public bool DeleteEntity(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Deleted;
            return true;
        }

        public bool EditEntity(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;
            return true;
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> wherelambda)
        {
            return db.Set<T>().Where<T>(wherelambda);
        }

        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> wherelambda, Expression<Func<T, s>> orderbylambda, bool isAsc)
        {
            var temp = db.Set<T>().Where<T>(wherelambda);
            totalCount = temp.Count();
            if (isAsc)
            {
                //升序
                temp = temp.OrderBy<T, s>(orderbylambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                //降序
                temp = temp.OrderByDescending<T, s>(orderbylambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }
    }
}
