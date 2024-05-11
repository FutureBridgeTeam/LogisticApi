using LogisticApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.OrderDTOs
{
    public record OrderCreateDto
    {
        public string CompanyName { get; set; } = null!;
        public string CompanyEmail { get; set; } = null!;
        public string CompanyPhone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string LoadName { get; set; } = null!;
        public decimal LoadWeight { get; set; }
        public decimal LoadCapasity { get; set; }       
        public int? ToCountryId { get; set; }
        public int? FromCountryId { get; set; }
        public int? ServiceId { get; set; }
        public string? AppUserId { get; set; }
    }
}
