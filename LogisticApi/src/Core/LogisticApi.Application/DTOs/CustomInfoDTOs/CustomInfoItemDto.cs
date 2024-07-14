using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.CustomInfoDTOs
{
    public record CustomInfoItemDto
    {
        public int Id { get; set; }
        public string Tittle { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}
