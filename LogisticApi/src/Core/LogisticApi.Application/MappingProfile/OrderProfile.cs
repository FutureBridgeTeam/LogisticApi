using AutoMapper;
using LogisticApi.Application.DTOs.OrderDTOs;
using LogisticApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.MappingProfile
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderCreateDto, Order>()
                .ForMember(dest => dest.TrackingId, opt => opt.MapFrom(src => "0"));          
            CreateMap<Order,OrderItemDto>();
        }
    }
}
