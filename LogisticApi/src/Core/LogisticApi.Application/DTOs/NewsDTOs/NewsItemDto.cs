using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.NewsDTOs
{
    public record NewsItemDto
    {
        public int Id { get; set; }
        public string Tittle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}
