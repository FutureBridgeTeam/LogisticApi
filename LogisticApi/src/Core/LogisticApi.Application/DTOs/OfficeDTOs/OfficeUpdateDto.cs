using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.OfficeDTOs
{
    public record OfficeUpdateDto
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string? Web { get; set; }
        public string? ExistedImage { get; set; }
        public IFormFile? NewImage { get; set; }
    }
}
