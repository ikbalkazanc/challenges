using System;

namespace Coredet.API.Models
{
    public class AddToCardModel
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public Guid BasketId { get; set; }
        public int Count { get; set; }
    }
}