using LogisticApi.Application.DTOs.TokenDTOs;
using LogisticApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface IJwtTokenService
    {
        TokenResponseDto CreateJwtToken(AppUser user, int minutes);
    }
}
