using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coredet.Common.Dto;
using Coredet.Core.Contract.Repository;
using Coredet.Core.Entities;
using Coredet.Data;
using Coredet.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Data.Repository
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        protected readonly DbSet<Product> _productDbset;
        protected readonly DbSet<BasketProducts> _basketprodutcsDbset;
        public BasketRepository(CoredetContext context) : base(context)
        {
            _productDbset = context.Set<Product>();
            _basketprodutcsDbset = context.Set<BasketProducts>();
        }

        public async Task<(List<BasketListItemDto>,Guid)> GetBasket(Guid UserId)
        {
            var basketId = _dbset.Where(x => !x.IsDeleted && x.UserId == UserId).OrderByDescending(x => x.CreatedDate)
                .First().Id;
            if (basketId == default) return (null,default);
            var result = await _basketprodutcsDbset.Where(x =>
                x.BasketId == basketId && !x.IsDeleted && x.Count > 0)
                .Join(_productDbset.Where(x=>!x.IsDeleted),x=>x.ProductId,y=>y.Id,(basket,produtc)=> new BasketListItemDto()
                {
                    Price = produtc.Price,
                    ProductId = produtc.Id,
                    Name = produtc.Name,
                    Count = basket.Count
                }).ToListAsync();
            return (result,basketId);
        }
    }
}