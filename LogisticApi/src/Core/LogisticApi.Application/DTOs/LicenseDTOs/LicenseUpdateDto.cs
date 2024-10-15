using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs
{
    public record LicenseUpdateDto
    {
        public string Name { get; set; } = null!;
        public string? ExistedImage { get; set; }
        public IFormFile? Newimage { get; set; }

    }
}
