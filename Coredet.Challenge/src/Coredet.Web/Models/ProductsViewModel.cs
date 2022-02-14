using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coredet.Common.Dto;
using Coredet.Core.Entities;

namespace Coredet.Web.Models
{
    public class ProductsViewModel
    {
        public List<ProductDto> Products { get; set; }
    }
}
