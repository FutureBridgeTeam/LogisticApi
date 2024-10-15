using LogisticApi.Application.DTOs.EmployeeDTOs;
using LogisticApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.OfficeDTOs
{
    public record OfficeItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string? Web { get; set; }
        public string Image { get; set; } = null!;
        public ICollection<EmployeeItemDto>? Employees { get; set; }
    }
}
