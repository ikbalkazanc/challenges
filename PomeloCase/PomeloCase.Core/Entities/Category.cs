using System.ComponentModel.DataAnnotations;

namespace PomeloCase.Core.Entites
{
    public class Category : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}