using DALFactory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
    public abstract class BaseService<T> where T : class, new()
    {
        public IBaseDal<T> CurrentDal { get; set; }
        //设为抽象函数，子类必须实现
        public abstract void SetCurrentDal();
        //用构造函数来调用SetCurrentDal()来实现不同CurrentDal的
        public BaseService()
        {
            SetCurrentDal();
        }

        public IDBSession CurrentDBSession
        {
            get
            {
                return DBSessionFactory.CreateDBSession();
            }
        }

        public T AddEntity(T entity)
        {
            CurrentDal.AddEntity(entity);
            CurrentDBSession.SaveChanges();
            return entity;
        }

        public bool DeleteEntity(T entity)
        {
            CurrentDal.DeleteEntity(entity);
            return CurrentDBSession.SaveChanges();
        }

        public bool EditEntity(T entity)
        {
            CurrentDal.EditEntity(entity);
            return CurrentDBSession.SaveChanges();
        }

        public IQueryable<T> LoadEntites(Expression<Func<T, bool>> wherelambda)
        {
            return CurrentDal.LoadEntities(wherelambda);
        }

        public IQueryable<T> LoadPageEntites<s>(int pageIndex, int pageSize, out int pageCount, Expression<Func<T, bool>> wherelambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            return CurrentDal.LoadPageEntities<s>(pageIndex, pageSize, out pageCount, wherelambda, orderbyLambda, isAsc);
        }
    }
}
