using LogisticApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Domain.Entities
{
    public class ToCountry:BaseEntityNameable
    {
        //Relational Properties
        public ICollection<Order>? Orders { get; set; }
    }
}
