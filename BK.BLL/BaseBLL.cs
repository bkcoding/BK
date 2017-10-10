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

        public bool Add(T t)
        {
            DAL.AddNotSubmit(t);
            return DAL.SaveChanges();
        }

        public bool Update(T t)
        {
            DAL.Update(t);
            return DAL.SaveChanges();
        }

        public bool Del(T t)
        {
            DAL.DelNotSubmit(t);
            return DAL.SaveChanges();
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
