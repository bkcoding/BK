
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BK.IBLL
{
    public partial interface IBaseBLL<T>where T : class, new()
    {
        void Add(T t);
        void Del(T t);
        void Update(T t);
        IQueryable<T> GetModels();
        IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda);

    }
}
