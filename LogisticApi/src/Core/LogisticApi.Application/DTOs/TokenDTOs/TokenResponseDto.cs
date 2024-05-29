using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.TokenDTOs
{
    public record TokenResponseDto(string Username, string Token, DateTime ExpirdeAt);

}
