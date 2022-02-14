using System;
using System.Text.Json.Serialization;


namespace Tesodev.Case.Order.Application.Dto
{
    public class OrderDto
    {
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public AddressDto Address { get; set; }
        public ProductDto Product { get; set; }

    }
}