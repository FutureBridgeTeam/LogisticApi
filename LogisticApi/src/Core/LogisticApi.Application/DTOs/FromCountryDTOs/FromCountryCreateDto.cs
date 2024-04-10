using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs
{
    public record FromCountryCreateDto
    {
        public string Name { get; set; } = null!;
    }
}
