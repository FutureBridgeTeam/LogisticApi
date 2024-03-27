using LogisticApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs
{
    public record ServiceItemDto
    {
        public string Name { get; set; }=null!;
        public string Tittle { get; set; }=null!;
        public string Description { get; set; }=null!;
        public string Icon { get; set; }=null!;
        public string Image { get; set; }=null!;
    }
}
