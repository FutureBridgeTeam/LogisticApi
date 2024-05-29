using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.AutenticationDTOs
{
    public record LoginDto
    {
        public string UsernameOrEmail { get; set; } = null!;       
        public string Password { get; set; } = null!;
        public bool isRemembered { get; set; }
    }
}
