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
    public class SettingProfile:Profile
    {
        public SettingProfile()
        {
            CreateMap<Setting, SettingItemDto>();
            CreateMap<SettingCreateDto, Setting>();
            CreateMap<Setting, SettingUpdateDto>().ReverseMap();
        }
    }
}
