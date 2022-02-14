using System;
using System.ComponentModel.DataAnnotations;

namespace PomeloCase.Core.Entites
{
    public class User : BaseEntity
    {
        public string AuthorName  { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoggedTime { get; set; }
        [MaxLength(20)]
        public string? LastLoggedIp { get; set; }

    }
}