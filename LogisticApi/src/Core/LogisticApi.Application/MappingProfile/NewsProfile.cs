using AutoMapper;
using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.NewsDTOs;
using LogisticApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.MappingProfile
{
    public class NewsProfile:Profile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsItemDto>();
            CreateMap<NewsCreateDto, News>();
            CreateMap<News, NewsUpdateDto>().ReverseMap();
        }
    }
}
