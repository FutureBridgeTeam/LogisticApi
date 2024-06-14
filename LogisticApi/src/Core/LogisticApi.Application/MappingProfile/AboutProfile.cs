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
    public class AboutProfile:Profile
    {
        public AboutProfile()
        {
            CreateMap<About, AboutItemDto>();
            CreateMap<AboutCreateDto, About>();
            CreateMap<About, AboutUpdateDto>().ReverseMap();
        }
    }
}
