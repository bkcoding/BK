
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BK.IBLL
{
    public partial interface IBaseBLL<T>where T : class, new()
    {
        bool Add(T t);
        bool Del(T t);
        bool Update(T t);
        IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda);

    }
}
