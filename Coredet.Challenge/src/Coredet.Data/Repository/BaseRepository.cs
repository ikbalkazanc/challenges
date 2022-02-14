using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Coredet.Core.Contract.Repository;
using Coredet.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Coredet.Data.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly CoredetContext _context;
        protected readonly DbSet<TEntity> _dbset;
        public BaseRepository(CoredetContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
            
        }

        public async virtual Task<TEntity> AddAsync(TEntity entity)
        {
            if (typeof(TEntity).BaseType?.Name != "BaseEntity") _dbset.AsNoTracking();
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbset.Where(predicate).ToListAsync();
        }

        public async virtual Task<TEntity> Update(TEntity entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbset.FirstOrDefaultAsync(predicate);
        }

    }
}
