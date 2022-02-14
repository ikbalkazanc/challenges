using System;
using System.ComponentModel.DataAnnotations;

namespace Coredet.Core.Entities
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}