using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.SliderDTOs
{
    public record SliderUpdateDto
    {
        public string? Tittle { get; set; } 
        public string? Description { get; set; } 
        public IFormFile? NewImage { get; set; } 
        public string? ExistImage { get; set; }
        public int? Order { get; set; }
    }
}
