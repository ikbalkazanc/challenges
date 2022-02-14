using Challenge.Infoset.Core.Domain;
using Challenge.Infoset.Core.Dto;
using Challenge.Infoset.Core.Request;
using Challenge.Infoset.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Infoset.Services.Contract
{
    public interface IPizzaRestaurantService : IService
    {
        Task<BaseResponse<List<RestaurantBranchesDto>>> GetCloseRestaurants(GetClosePizzaShopLocations request);
    }
}
