using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.GalleryItemDTOs
{
    public record GalleryItemItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; }=null!;

    }
}
