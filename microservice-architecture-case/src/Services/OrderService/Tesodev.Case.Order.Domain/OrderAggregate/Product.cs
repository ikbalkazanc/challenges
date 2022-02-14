using System.ComponentModel.DataAnnotations;
using Tesodev.Case.Shared.D.Services.Order.Domain.Core;
using Tesodev.Case.Shared.Domain.Core;

namespace Tesodev.Case.Order.Domain.OrderAggregate
{
    public class Product : Entity, IAggregateRoot
    {
        [Required] public string IamgeUrl { get; set; }
        [Required] public string Name { get; set; }
    }
}