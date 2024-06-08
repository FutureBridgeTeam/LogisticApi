using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs
{
    public record FaqCreateDto
    {
        public string Answer { get; set; } = null!;
        public string Question { get; set; } = null!;
    }
}
