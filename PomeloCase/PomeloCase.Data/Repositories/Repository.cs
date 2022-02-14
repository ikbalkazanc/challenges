using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Constant;
using Core.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using PomeloCase.Core.Entites;

namespace PomeloCase.Data.Repositories
{
    public class Repository<TEntity> : BaseRepository<TEntity> where TEntity : BaseEntity
    {
        //protected readonly DbContext _context;
        //protected readonly DbSet<TEntity> _dbset;
        public Repository(DatabaseContext context) : base(context)
        {
        }

        
        public  override async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedDate = DateTime.UtcNow;
            if (entity.CreatedUserId == default)
                entity.CreatedUserId = Constant.SystemUserId;
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task Remove(TEntity entity)
        {

            entity.DeleteDate = DateTime.Now;
            entity.DeletedUserId = Constant.SystemUserId;
            entity.IsDeleted = true;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public override async Task<TEntity> Update(TEntity entity)
        {
            entity.UptadeDate = DateTime.Now;
            entity.UpdatedUserId = Constant.SystemUserId;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
