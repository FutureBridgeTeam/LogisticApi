using AutoMapper;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Implementations.Services
{
    public class AutenticationService:IAutenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public AutenticationService(UserManager<AppUser> userManager, IMapper mapper, ICloudinaryService cloudinaryService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }
        public async Task Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.UserName || x.Email == registerDto.Email)) throw new Exception("Email or Username have");
            AppUser user = _mapper.Map<AppUser>(registerDto);
            if(registerDto.ProfileImage != null)
            {
                user.ProfileImage=await _cloudinaryService.FileCreateAsync(registerDto.ProfileImage);
            }
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    builder.AppendLine(error.Description);
                }
                throw new Exception(builder.ToString());
            }
        }
    }
}
