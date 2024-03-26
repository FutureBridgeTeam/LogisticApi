using LogisticApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Domain.Entities
{
    public class Service:BaseEntityNameable
    {
        public string Tittle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public string Image { get; set; } = null!;
        //Relational Properties
        public ICollection<Order>? Orders { get; set; }
    }
}
