using AutoMapper;
using Tesodev.Case.Order.Application.Commands;
using Tesodev.Case.Order.Application.Dto;
using Tesodev.Case.Order.Domain.OrderAggregate;
using Tesodev.Case.Shared.Domain.Core;

namespace Tesodev.Case.Order.Application.Mapping
{
    internal class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Tesodev.Case.Order.Domain.OrderAggregate.Order, OrderDto>().ReverseMap();
            CreateMap<Tesodev.Case.Order.Domain.OrderAggregate.Order, CreateOrderCommand>().ReverseMap().ForMember(x => x.Address, x => x.MapFrom(x => x.Address));
            CreateMap<AddressDto, Address>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}