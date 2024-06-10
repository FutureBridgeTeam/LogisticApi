using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.CustomInfoDTOs
{
    public record CustomInfoUpdateDto
    {
        public string Tittle { get; set; } = null!;
        public IFormFile? NewImage { get; set; } 
        public string? ExistImage { get; set; } 
    }
}
