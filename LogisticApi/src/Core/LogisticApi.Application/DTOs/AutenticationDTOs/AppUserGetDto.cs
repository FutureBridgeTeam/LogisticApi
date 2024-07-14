using LogisticApi.Domain.Entities;
using LogisticApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.AutenticationDTOs
{
    public record AppUserGetDto
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string ProfileImage { get; set; } = null!;
        public Gender Gender { get; set; }
        public string Email { get; set; } = null!;
        public string? Role { get; set; }
        //Relational Properties
        public ICollection<Order>? Orders { get; set; }
    }
}
