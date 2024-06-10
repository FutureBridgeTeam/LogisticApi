using AutoMapper;
using LogisticApi.Application.DTOs.CustomInfoDTOs;
using LogisticApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.MappingProfile
{
    public class CustomInfoProfile : Profile
    {
        public CustomInfoProfile()
        {
            CreateMap<CustomInfo, CustomInfoItemDto>();
            CreateMap<CustomInfoCreateDto, CustomInfo>();
            CreateMap<CustomInfoUpdateDto, CustomInfo>().ReverseMap();
        }
    }
}
