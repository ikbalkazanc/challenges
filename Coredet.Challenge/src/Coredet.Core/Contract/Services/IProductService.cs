using System.Collections.Generic;
using System.Threading.Tasks;
using Coredet.Common.Dto;

namespace Coredet.Core.Contract.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProducts();
    }
}