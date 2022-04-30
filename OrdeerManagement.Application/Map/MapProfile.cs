using AutoMapper;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Map;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();

        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Customer, CreateCustomerDto>().ReverseMap().AfterMap((src,dest)=>dest.UserName=src.Email);
        CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
     
        CreateMap<CustomerOrder, CustomerOrderDto>().ReverseMap();
        CreateMap<CustomerOrder, CreateCustomerOrderDto>().ReverseMap();
        CreateMap<CustomerOrder, UpdateCustomerOrderDto>().ReverseMap();

        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        CreateMap<OrderItem, CreateOrderItemDto>().ReverseMap();
        CreateMap<OrderItem, UpdateOrderItemDto>().ReverseMap();
    }
}
