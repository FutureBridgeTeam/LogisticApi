using AutoMapper;
using LogisticApi.Application.DTOs.SliderDTOs;
using LogisticApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.MappingProfile
{
    public class SliderProfile : Profile
    {
        public SliderProfile()
        {
            CreateMap<SliderCreateDto, Slider>();
            CreateMap<Slider, SliderUpdateDto>().ReverseMap();
            CreateMap<Slider, SliderItemDto>();
        }
    }
}
