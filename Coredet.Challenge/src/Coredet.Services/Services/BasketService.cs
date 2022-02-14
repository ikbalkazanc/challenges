using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Coredet.Common.Dto;
using Coredet.Core.Contract.Services;
using Coredet.Core.Entities;
using Coredet.Data.Repository;

namespace Coredet.Services.Services
{
    public class BasketService : IBasketService
    {
        private readonly DataRepository _repo;

        public BasketService(DataRepository repo)
        {
            _repo = repo;
        }

        public Task ClearBasket(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketListDto> GetUserBasketList(Guid UserId)
        {
            var (basketlist,basketid) = await _repo.BasketRepository.Value.GetBasket(UserId);
            var basket = new BasketListDto();
            basket.Items = basketlist ?? new List<BasketListItemDto>();

            basket.Items.ForEach(x => basket.TotalPrice += x.Price * x.Count);
            basket.BasketId = basketid;
            return basket;
        }

        public async Task<BasketListDto> SetToBasketCount(Guid ProductId, Guid BasketId, Guid UserId, int count)
        {
            Basket basket = null;
            if (BasketId == default)
                basket = await _repo.BasketRepository.Value.AddAsync(new Basket() { UserId = UserId });
            else
                basket = await _repo.BasketRepository.Value.FirstOrDefault(x=>x.Id == BasketId);

            if (basket == null)
                throw new Exception("cuuld nt access basket");

            BasketProducts basketprodutcs = await _repo.BasketProductsRepository.Value.FirstOrDefault(
                x => x.BasketId == basket.Id && x.ProductId == ProductId);

            if (basketprodutcs == null){
                var temp = basket.Id;

                basketprodutcs = await _repo.BasketProductsRepository.Value.AddAsync(new BasketProducts()
                {
                    ProductId = ProductId,
                    BasketId = temp,
                    Count = count
                });
            }
            else
            {
                if (count <= 0)
                    basketprodutcs.IsDeleted = true;
                else
                    basketprodutcs.Count = count;

                await _repo.BasketProductsRepository.Value.Update(basketprodutcs);
            }

            return await this.GetUserBasketList(UserId);
        }
    }
}