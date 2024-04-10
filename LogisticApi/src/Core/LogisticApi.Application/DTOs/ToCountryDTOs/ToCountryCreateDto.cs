using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.ToCountryDTOs
{
    public record ToCountryCreateDto
    {
        public string Name { get; set; } = null!;
    }
}
