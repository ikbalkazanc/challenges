using AutoMapper;
using Coredet.Common.Dto;
using Coredet.Core.Entities;

namespace Coredet.Services.Mapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<ProductDto, Product>().ReverseMap();

        }
    }
}