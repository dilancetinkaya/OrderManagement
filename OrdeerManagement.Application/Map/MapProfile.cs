using AutoMapper;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Map;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<CustomerOrder, CustomerOrderDto>().ReverseMap();
    }
}
