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
    public class FaqProfile:Profile
    {
        public FaqProfile()
        {
            CreateMap<Faq, FaqItemDto>();
            CreateMap<FaqCreateDto, Faq>();
            CreateMap<FaqUpdateDto, Faq>().ReverseMap();
        }
    }
}
