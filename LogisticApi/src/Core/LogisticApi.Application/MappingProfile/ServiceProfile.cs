using AutoMapper;
using LogisticApi.Application.DTOs;
using LogisticApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.MappingProfile
{
    public class ServiceProfile:Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, ServiceItemDto>();
            CreateMap<ServiceCreateDto, Service>();
            CreateMap<Service, ServiceUpdateDto>().ReverseMap();
        }
    }
}
