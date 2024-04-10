using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.ToCountryDTOs
{
    public record ToCountryItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
