using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using Tesodev.Case.Shared.D.Services.Order.Domain.Core;
using Tesodev.Case.Shared.Domain.Core;

namespace Tesodev.Case.Customer.Domain.CustomerAggregate
{
    public class Customer : Entity, IAggregateRoot
    {
        [Required]
        public string Name{ get; set; }
        [Required]
        public string Email{ get; set; }
        public Address Address{ get; set; }
    }
}