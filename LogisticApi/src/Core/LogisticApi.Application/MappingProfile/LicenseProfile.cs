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
    public class LicenseProfile:Profile
    {
        public LicenseProfile()
        {
            CreateMap<License,LicenseItemDto>();
            CreateMap<LicenseCreateDto,License>();
            CreateMap<License, LicenseUpdateDto>().ReverseMap();
        }
    }
}
