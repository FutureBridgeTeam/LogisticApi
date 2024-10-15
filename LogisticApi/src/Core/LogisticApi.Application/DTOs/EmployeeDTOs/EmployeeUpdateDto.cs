using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.EmployeeDTOs
{
    public record EmployeeUpdateDto
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Position { get; set; } = null!;
        public int OfficeId { get; set; }
    }
}
