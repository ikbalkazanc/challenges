using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Coredet.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}