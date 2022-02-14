using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Coredet.Core.Entities;

namespace Coredet.Core.Contract.Repository
{
    public interface IRepository<T>  where T : class
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate);
        //Task Remove(T entity);
        Task<T> Update(T entity);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
    }
}