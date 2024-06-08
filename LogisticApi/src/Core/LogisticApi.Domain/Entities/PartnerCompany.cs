using LogisticApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Domain.Entities
{
    public class PartnerCompany:BaseEntityNameable
    {
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string WebsiteLink { get; set; } = null!;
    }
}
