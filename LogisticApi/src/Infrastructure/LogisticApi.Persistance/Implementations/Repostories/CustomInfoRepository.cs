using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Domain.Entities;
using LogisticApi.Persistance.Contexts;
using LogisticApi.Persistance.Implementations.Repostories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Implementations.Repostories
{
    public class CustomInfoRepository : Repository<CustomInfo>, ICustomInfoRepository
    {
        public CustomInfoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
