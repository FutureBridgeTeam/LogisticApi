using LogisticApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Domain.Entities
{
    public class Faq:BaseEntity
    {
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
    }
}
