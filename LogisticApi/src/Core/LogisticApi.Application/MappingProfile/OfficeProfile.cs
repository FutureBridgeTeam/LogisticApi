using AutoMapper;
using LogisticApi.Application.DTOs.OfficeDTOs;
using LogisticApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.MappingProfile
{
    public class OfficeProfile:Profile
    {
        public OfficeProfile()
        {
            CreateMap<Office,OfficeItemDto>();
            CreateMap<OfficeCreateDto,Office>();
            CreateMap<Office, OfficeUpdateDto>().ReverseMap();
        }
    }
}
