using System.ComponentModel.DataAnnotations;

namespace Pazarama.Homework.Core.Entity;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}