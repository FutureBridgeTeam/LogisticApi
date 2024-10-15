using AutoMapper;
using LogisticApi.Application.DTOs.GalleryItemDTOs;
using LogisticApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.MappingProfile
{
    public class GalleryItemProfile:Profile
    {
        public GalleryItemProfile()
        {
            CreateMap<GalleryItem,GalleryItemItemDto>();  
            CreateMap<GalleryItemCreateDto,GalleryItem>();
            CreateMap<GalleryItem, GalleryItemUpdateDto>().ReverseMap();
        }
    }
}
