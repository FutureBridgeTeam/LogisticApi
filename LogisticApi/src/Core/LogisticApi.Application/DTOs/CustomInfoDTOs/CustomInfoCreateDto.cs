using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.CustomInfoDTOs
{
    public record CustomInfoCreateDto
    {
        public string Tittle { get; set; } = null!;
        public IFormFile Image { get; set; } = null!;
    }
}
