using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coredet.Core.Entities
{

    public class BasketProducts : BaseEntity
    {
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Basket")]
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }

        public int Count { get; set; }
    }
}