using System;
using System.Linq;
using System.Linq.Expressions;
using BK.IDAL;

namespace BK.BLL
{
    public abstract partial class BaseBLL<T> where T : class, new()
    {
        public BaseBLL()
        {
            SetDAL();
        }

        public IBaseDAL<T> DAL { get; set; }

        public abstract void SetDAL();

        public void Add(T t)
        {
            DAL.AddNotSubmit(t);
            DAL.SaveChanges();
        }

        public void Update(T t)
        {
            DAL.Update(t);
            DAL.SaveChanges();
        }

        public void Del(T t)
        {
            DAL.DelNotSubmit(t);
            DAL.SaveChanges();
        }

        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return DAL.GetModels(whereLambda);
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            return DAL.GetModelsByPage(pageSize, pageIndex, isAsc, OrderByLambda, WhereLambda);
        }

    }
}
