using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coredet.Core.Entities
{
    public class Basket : BaseEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }
    }
}