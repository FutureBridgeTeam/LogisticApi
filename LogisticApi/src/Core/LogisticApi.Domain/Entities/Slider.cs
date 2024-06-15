using LogisticApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Domain.Entities
{
    public class Slider : BaseEntity
    {
        public string Tittle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Image { get; set;} = null!;
        public int Order { get; set; }
    }
}
