using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Infoset.Core.Dto
{
    public class RestaurantBranchesDto
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Distance { get; set; }
        public string GoogleLocationUrl { get; set; }
    }
}
