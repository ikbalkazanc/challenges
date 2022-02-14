using Challenge.Infoset.Core.Domain;
using Challenge.Infoset.Core.Dto;
using Challenge.Infoset.Core.Request;
using Challenge.Infoset.Core.Response;
using Challenge.Infoset.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Infoset.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaShopLocation : ControllerBase
    {
        private readonly IPizzaRestaurantService _pizzaRestaurantService;
        public PizzaShopLocation(IPizzaRestaurantService pizzaRestaurantService)
        {
            _pizzaRestaurantService = pizzaRestaurantService;
        }
        [HttpPost]
        public async Task<BaseResponse<List<RestaurantBranchesDto>>> GetClosePizzaShopLocation(GetClosePizzaShopLocations request)
        {
            var response = await _pizzaRestaurantService.GetCloseRestaurants(request);
            return response;
        }
    }
}
