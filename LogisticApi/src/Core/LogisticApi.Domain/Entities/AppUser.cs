using LogisticApi.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Domain.Entities
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string ProfileImage { get; set; } = "https://res.cloudinary.com/ddxhgsscq/image/upload/v1718727326/d2g3oil5fdm7lc9zcysu.png";
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        //Relational Properties
        public ICollection<Order>? Orders { get; set; }
    }
}
