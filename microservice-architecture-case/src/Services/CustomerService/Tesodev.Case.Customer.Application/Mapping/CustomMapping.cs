using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesodev.Case.Customer.Application.Commands;
using Tesodev.Case.Customer.Application.Dto;
using Tesodev.Case.Customer.Application.Dtos;
using Tesodev.Case.Shared.Domain.Core;

namespace Tevodev.Case.Customer.Application.Mapping
{
    internal class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Tesodev.Case.Customer.Domain.CustomerAggregate.Customer, CustomerDto>().ReverseMap();
            CreateMap<Tesodev.Case.Customer.Domain.CustomerAggregate.Customer, CreateCustomerCommand>().ReverseMap().ForMember(x=>x.Address,x=> x.MapFrom(x=>x.Address));
            CreateMap<AddressDto, Address>().ReverseMap();
        }
    }
}