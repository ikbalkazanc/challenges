using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomeloCase.Core.Entites
{
    public class PostsCategories
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("Post")]
        public Guid PostId { get; set; }
        [ForeignKey("Category")]
        [Required]

        public Guid CategoryId { get; set; }
    }
}