using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomeloCase.Core.Entites
{
    public class Post : BaseEntity
    {
        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        
        [MaxLength(100)]
        public string Title { get; set; }
        public string Body { get; set; }

    }
}
