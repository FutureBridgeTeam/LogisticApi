using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs
{
    public record ServiceUpdateDto
    {
        public string Name { get; set; } = null!;
        public string Tittle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public IFormFile? Photo { get; set; }
        public string? Image { get; set; }

    }
}
