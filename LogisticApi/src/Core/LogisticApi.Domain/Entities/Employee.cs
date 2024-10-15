using LogisticApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Domain.Entities
{
    public class Employee:BaseEntityNameable
    {
        public string Surname { get; set; } = null!;
        public string Position { get; set; } = null!;
        //Relational Properties

        public int OfficeId { get; set; }
        public Office Office { get; set; } = null!;

    }
}
