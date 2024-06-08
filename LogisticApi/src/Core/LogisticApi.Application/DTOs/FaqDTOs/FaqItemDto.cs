using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs
{
    public record FaqItemDto
    {
        public int Id { get; set; }
        public string Answer { get; set; } = null!;
        public string Question { get; set; } = null!;
    }
}
