using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Challenge.Infoset.Core.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
        
    }
}
