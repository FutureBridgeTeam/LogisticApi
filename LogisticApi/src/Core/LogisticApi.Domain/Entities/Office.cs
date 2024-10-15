using LogisticApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Domain.Entities
{
    public class Office:BaseEntityNameable
    {
        public string Location { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Web { get; set; }
        public string Image { get; set; }=null!;
        //Relational Properties
        public ICollection<Employee>? Employees { get; set; }
    }
}
