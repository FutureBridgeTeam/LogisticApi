using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.AutenticationDTOs;
using LogisticApi.Application.DTOs.TokenDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface IAutenticationService
    {
        Task Register(RegisterDto registerDto);
        Task<TokenResponseDto> Login(LoginDto loginDto);
        bool IsUserCurrent();
        Task<AppUserGetDto> GetCurrentUserAsync();
        Task<string> GetUserRoleAsync(string id);
        Task CreateRoleAsync();
    }
}
