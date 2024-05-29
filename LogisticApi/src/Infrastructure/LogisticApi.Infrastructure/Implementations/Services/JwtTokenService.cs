﻿using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs.TokenDTOs;
using LogisticApi.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Infrastructure.Implementations.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenResponseDto CreateJwtToken(AppUser user, int minutes)
        {
            ICollection<Claim> userclaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.GivenName,user.Name),
                new Claim(ClaimTypes.Surname,user.Surname),
                new Claim(ClaimTypes.Email,user.Email),

            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Audience"],
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(minutes),
                claims: userclaims,
                signingCredentials: credentials

                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();


            return new TokenResponseDto(user.UserName, handler.WriteToken(token), token.ValidTo);
        }
    }
}
