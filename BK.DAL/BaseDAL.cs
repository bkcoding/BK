using System;
using BK.Models;
using System.Runtime.Remoting.Messaging;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;

namespace BK.DAL
{
    public class BaseDAL<T> where T : class
    {
        private static DataContext GetCurrentContext()
        {
            string name = typeof(MyDBDataContext).FullName;
            object obj = CallContext.GetData(name);
            if (obj == null)
            {
                obj = new MyDBDataContext();
                CallContext.SetData(name, obj);
            }
            return (MyDBDataContext)obj;
        }

        protected readonly DataContext context;

        public Table<T> db;

        public BaseDAL()
        {
            context = GetCurrentContext();
            db = context.GetTable<T>();
        }

        public void Update(T model)
        {
        }

        public IQueryable<T> GetModels()
        {
            return db;
        }

        public IQueryable<T> GetModels(Expression<Func<T, bool>> where)
        {
            return db.Where(where);
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            //是否升序
            if (isAsc)
            {
                return db.Where(WhereLambda).OrderBy(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return db.Where(WhereLambda).OrderByDescending(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }

        public void AddNotSubmit(T model)
        {
            db.InsertOnSubmit(model);
        }

        public void DelNotSubmit(T model)
        {
            db.DeleteOnSubmit(model);
        }

        public void SaveChanges()
        {
            context.SubmitChanges();
        }

    }
}
