using System;
using System.Linq;
using System.Linq.Expressions;

namespace BK.IDAL
{
    public interface IBaseDAL<T> where T : class, new()
    {
        void AddNotSubmit(T t);
        void DelNotSubmit(T t);
        void Update(T t);
        IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda);
        void SaveChanges();
    }
}
