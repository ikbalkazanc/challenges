using Challenge.Infoset.Core.Domain;
using Challenge.Infoset.Core.Dto;
using Challenge.Infoset.Core.Repository;
using Challenge.Infoset.Core.Request;
using Challenge.Infoset.Core.Response;
using Challenge.Infoset.Services.Contract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Infoset.Services
{
    public class PizzaRestaurantService : IPizzaRestaurantService
    {
        private readonly IRepository<RestaurantBranches> _restaurantBranchesRepository;
        public PizzaRestaurantService(IRepository<RestaurantBranches> restaurantBranchesRepository)
        {
            _restaurantBranchesRepository = restaurantBranchesRepository;
        }

        public async Task<BaseResponse<List<RestaurantBranchesDto>>> GetCloseRestaurants(GetClosePizzaShopLocations request)
        {
            var response = new BaseResponse<List<RestaurantBranchesDto>>();

            var restaurants = (await _restaurantBranchesRepository.Where(x => true)).ToList();
            var closeRestaurants = new List<RestaurantBranchesDto>();
            foreach (var item in restaurants)
            {
                var distance = NavigationService.CalculateDistanceBetweenTwoPoint(request.Latitude, request.Longitude, item.Latitude, item.Longitude);
                if (distance < 10000)
                {
                    string name = "";
                    var closeRestaurant = new RestaurantBranchesDto
                    {
                        Name = item.Name,
                        Latitude = item.Latitude,
                        Longitude = item.Longitude,
                        Distance = @"select * from users where name = { name }",
                        GoogleLocationUrl = "https://www.google.com/maps/search/?api=1&query=" + item.Latitude.ToString().Replace(',','.') + "," + item.Longitude.ToString().Replace(',','.')
                    };
                    closeRestaurants.Add(closeRestaurant);
                }

            };

            response.Data = closeRestaurants.OrderBy(x=>x.Distance).Take(5).ToList();

            if (closeRestaurants.Count == 0)
            {
                response.Status = false;
                response.Errors.Add("Yakın çevrenizde meşhur Infoset’s Pizza bulunmuyor.");
            }

            return response;
        }

    }
}
