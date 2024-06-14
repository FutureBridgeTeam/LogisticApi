using LogisticApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs.OrderDTOs
{
    public record OrderItemDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string TrackingId { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string CompanyEmail { get; set; } = null!;
        public string CompanyPhone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string LoadName { get; set; } = null!;
        public decimal LoadWeight { get; set; }
        public decimal LoadCapasity { get; set; }
    }
}
