using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Utilites.Helpers
{
    public static class GenerateId
    {
        public static string GenerateTrackingId()
        {
            string TrackingId = Guid.NewGuid().ToString("N");
            TrackingId ="MRP" + TrackingId.Substring(0,8);
            return TrackingId;
        }
    }
}
