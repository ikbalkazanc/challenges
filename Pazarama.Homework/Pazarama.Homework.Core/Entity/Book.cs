using System.ComponentModel.DataAnnotations;

namespace Pazarama.Homework.Core.Entity;

public class Book : BaseEntity
{
    [Required]
    public string Title { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    [Required]
    public List<Category> Categories { get; set; }
}