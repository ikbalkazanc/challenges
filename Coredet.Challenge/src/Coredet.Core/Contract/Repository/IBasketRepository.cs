using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Coredet.Common.Dto;
using Coredet.Core.Entities;

namespace Coredet.Core.Contract.Repository
{
    public interface IBasketRepository : IRepository<Basket>
    {
        Task<(List<BasketListItemDto>, Guid)> GetBasket(Guid UserId);
    }
}