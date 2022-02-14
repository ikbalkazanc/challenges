using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Coredet.Common.Dto
{
    public class UserDto
    {
        public UserDto(string name, Guid userId)
        {
            Name = name;
            UserId = userId;
        }

        public Guid UserId { get; set; }
        public string Name { get; set; }
    }

    public class BasketListDto
    {
        public Guid BasketId { get; set; }
        public List<BasketListItemDto> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
    public class BasketListItemDto
    {
        public Guid  ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

    }
}