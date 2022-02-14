using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coredet.API.Models;
using Coredet.Common.Dto;
using Coredet.Core.Contract.Services;
using Coredet.Shared.Dto.Base;
using Erlab.Challenge.API.Core.Dto.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Coredet.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost]
        public async Task<Response<BasketListDto>> AddToCard(AddToCardModel model)
        {
            var response = new Response<BasketListDto>();
           
            response.Data = await _basketService.SetToBasketCount(model.ProductId,model.BasketId,model.UserId,model.Count);
            return response;
        }
        [HttpGet("{UserId}")]
        public async Task<Response<BasketListDto>> GetBasket(Guid UserId)
        {
            var response = new Response<BasketListDto>();
            response.Data = await _basketService.GetUserBasketList(UserId);
            return response;
        }
    }
}
