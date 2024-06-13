using AutoMapper;
using CloudinaryDotNet;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.AutenticationDTOs;
using LogisticApi.Application.DTOs.TokenDTOs;
using LogisticApi.Domain.Entities;
using LogisticApi.Domain.Enums;
using LogisticApi.Persistance.Utilites.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Implementations.Services
{
    public class AutenticationService : IAutenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IHttpContextAccessor _accessor;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly IUrlHelper _urlHelper;

        public AutenticationService(UserManager<AppUser> userManager, IMapper mapper,
           ICloudinaryService cloudinaryService, IJwtTokenService jwtTokenService, IHttpContextAccessor accessor,
           RoleManager<IdentityRole> roleManager, IEmailService emailService, IUrlHelper urlHelper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _jwtTokenService = jwtTokenService;
            _accessor = accessor;
            _roleManager = roleManager;
            _emailService = emailService;
            _urlHelper = urlHelper;
        }
        public async Task Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.UserName || x.Email == registerDto.Email)) throw new Exception("Email or Username have");
            AppUser user = _mapper.Map<AppUser>(registerDto);
            if (registerDto.ProfileImage != null)
            {
                user.ProfileImage = await _cloudinaryService.FileCreateAsync(registerDto.ProfileImage);
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
            await _userManager.AddToRoleAsync(user, Roles.User.ToString());
        }
        public async Task<TokenResponseDto> Login(LoginDto loginDto)
        {
            AppUser user = await _userManager.FindByNameAsync(loginDto.UsernameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(loginDto.UsernameOrEmail);
                if (user == null) throw new Exception("Email,Password or Username is incorrect");
            }
            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password)) throw new Exception("Email,Password or Username is incorrect");
            int expiredat = loginDto.isRemembered ? 4300 : 60;
            return _jwtTokenService.CreateJwtToken(user, expiredat);
        }
        public bool IsUserCurrent()
        {
            return _accessor.HttpContext?.User.Identity?.IsAuthenticated == true;
        }
        public async Task<AppUserGetDto> GetCurrentUserAsync()
        {
            var id = _accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id is null)
                throw new Exception("UserId is null");

            var user = await _userManager.FindByIdAsync(id);
            if (user is null)
                throw new Exception("User not Found");

            var dto = _mapper.Map<AppUserGetDto>(user);

            dto.Role = await GetUserRoleAsync(dto.Id);

            return dto;
        }
        public async Task<string> GetUserRoleAsync(string id)
        {
            var user = await _getUserById(id);
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.FirstOrDefault() is null) return "";
            return roles.FirstOrDefault();
        }

        public async Task CreateRoleAsync()
        {
            foreach (var item in Enum.GetValues(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(item.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = item.ToString() });
                };
            }
        }
        public async Task<string> ForgotPasswordAsync(string email)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            if (user == null) throw new Exception("User not found");
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return token;
        }
        public async Task ResetPassword(ResetPasswordDto dto, string token)
        {
            var userid = _accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier); // Bu hisse deyisdirilecek //
            if (userid == null) throw new Exception("Userid not found");
            var user = await _userManager.FindByIdAsync(userid);
            if (user == null) throw new Exception("User not found");
            if (await _userManager.CheckPasswordAsync(user, dto.Password)) throw new Exception("The new password cannot be the same as the old one.");
            var result = await _userManager.ResetPasswordAsync(user, token, dto.Password);
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in result.Errors)
                {
                    sb.AppendLine(item.Description);
                }
                throw new Exception(sb.ToString());
            }
        }
        private async Task<AppUser> _getUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is null) throw new Exception("User not found(");
            return user;
        }

    }
}
