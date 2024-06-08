using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs
{
    public record PartnerCompanyCreateDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IFormFile Image { get; set; } = null!;
        public string WebsiteLink { get; set; } = null!;
    }
}
