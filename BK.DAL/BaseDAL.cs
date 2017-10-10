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

        public virtual IQueryable<T> ViewListALL()
        {
            return db;
        }

        public IQueryable<T> ViewListWhere(Expression<Func<T, bool>> where)
        {
            return db.Where(where);
        }

        public void AddNotSubmit(T model)
        {
            db.InsertOnSubmit(model);
        }

        public void DeleteNotSubmit(T model)
        {
            db.DeleteOnSubmit(model);
        }

        public void Save()
        {
            context.SubmitChanges();
        }

    }
}
