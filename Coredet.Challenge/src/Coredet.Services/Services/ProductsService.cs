using System.Collections.Generic;
using System.Threading.Tasks;
using Coredet.Common.Dto;
using Coredet.Core.Contract.Services;
using Coredet.Data.Repository;
using Coredet.Services.Mapper;

namespace Coredet.Services.Services
{
    public class ProductsService : IProductService
    {
        private readonly DataRepository _repo;

        public ProductsService(DataRepository repo)
        {
            _repo = repo;
        }


        public async Task<List<ProductDto>> GetAllProducts()
        {
            var result = await _repo.ProductRepository.Value.Where(x => !x.IsDeleted);
            var dtos = ObjectMapper.Mapper.Map<List<ProductDto>>(result);
            return dtos;
        }
    }
}