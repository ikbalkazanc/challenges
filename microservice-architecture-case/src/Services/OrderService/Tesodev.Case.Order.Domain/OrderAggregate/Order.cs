using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tesodev.Case.Shared.D.Services.Order.Domain.Core;
using Tesodev.Case.Shared.Domain.Core;

namespace Tesodev.Case.Order.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        [Required] public Guid CustomerId { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public double Price { get; set; }
        [Required] public string Status { get; set; }
        public Address Address { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Product")] [Required] public Guid ProductId { get; set; }
    }
}