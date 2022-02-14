using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tesodev.Case.Order.Application.Dto
{
    public class CreateOrUpdateOrderDto
    {
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }
        public string IamgeUrl { get; set; }
        [JsonPropertyName("Name")]
        public string ProductName { get; set; }
    }
}
