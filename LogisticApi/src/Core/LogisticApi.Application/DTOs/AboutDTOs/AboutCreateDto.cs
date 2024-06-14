using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs
{
    public record AboutCreateDto
    {
        public string Tittle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IFormFile Image { get; set; } = null!;
    }
}
