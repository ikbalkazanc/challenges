using System.ComponentModel.DataAnnotations;

namespace Pazarama.Homework.Core.Entity;

public class Category : BaseEntity
{
    [Required]
    public string Name { get; set; }

    public List<Book> Books { get; set; }
}