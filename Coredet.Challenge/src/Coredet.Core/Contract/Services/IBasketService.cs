using System;
using System.Threading.Tasks;
using Coredet.Common.Dto;

namespace Coredet.Core.Contract.Services
{
    public interface IBasketService
    {
        Task ClearBasket(Guid UserId);

        Task<BasketListDto> GetUserBasketList(Guid Id);
        Task<BasketListDto> SetToBasketCount(Guid ProductId,Guid BasketId,Guid UserId, int count);
    }
}