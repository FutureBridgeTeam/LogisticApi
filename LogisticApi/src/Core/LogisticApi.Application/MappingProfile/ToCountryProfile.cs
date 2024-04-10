using AutoMapper;
using LogisticApi.Application.DTOs.ToCountryDTOs;
using LogisticApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.MappingProfile
{
    public class ToCountryProfile:Profile
    {
        public ToCountryProfile()
        {
            CreateMap<ToCountry,ToCountryItemDto>();
            CreateMap<ToCountryCreateDto, ToCountry>();
            CreateMap<ToCountryUpdateDto, ToCountry>().ReverseMap();
        }
    }
}
