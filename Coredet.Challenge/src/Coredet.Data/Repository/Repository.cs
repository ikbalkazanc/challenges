
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Coredet.Core.Contract.Repository;
using Coredet.Core.Entities;
using Coredet.Data;
using Coredet.Data.Repository;


namespace Data.Repository
{
    public class Repository<TEntity> : BaseRepository<TEntity>  where TEntity : BaseEntity
    {
        public Repository(CoredetContext context) : base(context)
        {
        }

        public async override Task<TEntity> AddAsync(TEntity entity)
        {
            if(entity.Id != default)
                entity.Id = Guid.NewGuid();
            entity.CreatedDate = DateTime.UtcNow;

            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
