using LogisticApi.Domain.Entities.Common;
using LogisticApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Domain.Entities
{
    public class Order:BaseEntity
    {
        public string CompanyName { get; set; } = null!;
        public string CompanyEmail { get; set; } = null!;
        public string CompanyPhone { get; set; } = null!;
        public string Address { get; set; }=null!;
        public string LoadName { get; set; } = null!;
        public decimal LoadWeight { get; set; } 
        public decimal LoadCapasity { get; set; } 
        public string TrackingId { get; set; } = null!;
        public OrderStatus Status { get; set; }
        //Relational Properties
        public int? ToCountryId { get; set; }
        public ToCountry? ToCountry { get; set; }
        public int? FromCountryId { get; set; }
        public FromCountry? FromCountry { get; set; }
        public int? ServiceId { get; set; }
        public Service? Service { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
