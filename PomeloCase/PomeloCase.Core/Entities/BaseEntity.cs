using System;
using System.ComponentModel.DataAnnotations;


namespace PomeloCase.Core.Entites
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        
        public Guid CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? UpdatedUserId { get; set; }
        public DateTime? UptadeDate { get; set; }
        public Guid? DeletedUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
