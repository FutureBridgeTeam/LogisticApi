using AutoMapper;
using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.PartnerCompanyDTOs;
using LogisticApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.MappingProfile
{
    public class PartnerCompanyProfile:Profile
    {
        public PartnerCompanyProfile()
        {
            CreateMap<PartnerCompany, PartnerCompanyItemDto>();
            CreateMap<PartnerCompanyCreateDto, PartnerCompany>();
            CreateMap<PartnerCompanyUpdateDto, PartnerCompany>().ReverseMap();
        }
    }
}
