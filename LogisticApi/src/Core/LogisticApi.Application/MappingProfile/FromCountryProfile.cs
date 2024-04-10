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
    public class FromCountryProfile:Profile
    {
        public FromCountryProfile()
        {
            CreateMap<FromCountry, FromCountryItemDto>();
            CreateMap<FromCountryCreateDto, FromCountry>();
            CreateMap<FromCountry, FromCountryUpdateDto>().ReverseMap();
        }
    }
}
