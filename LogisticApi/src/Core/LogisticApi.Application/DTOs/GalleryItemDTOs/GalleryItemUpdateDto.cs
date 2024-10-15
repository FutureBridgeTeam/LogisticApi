using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.GalleryItemDTOs
{
    public record GalleryItemUpdateDto
    {
        public string Name { get; set; } = null!;
        public string? ExistedImage { get; set; }
        public IFormFile? NewImage { get; set; }
    }
}
