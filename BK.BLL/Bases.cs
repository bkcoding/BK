using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using BK.Models;

namespace BK.BLL
{
    public abstract class Base<T> where T : class
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

        public Base()
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

        public void AddListNotSubmit(List<T> model)
        {
            db.InsertAllOnSubmit(model);
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