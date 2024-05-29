using AutoMapper;
using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.AutenticationDTOs;
using LogisticApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.MappingProfile
{
    public class AppUserProfile:Profile
    {
        public AppUserProfile()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<LoginDto, AppUser>().ReverseMap();
        }
    }
}
