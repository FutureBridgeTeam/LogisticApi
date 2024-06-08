using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.PartnerCompanyDTOs
{
    public record PartnerCompanyUpdateDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string WebsiteLink { get; set; } = null!;
        public string? Image { get; set; } 
        public IFormFile? Photo { get; set; }

    }
}
