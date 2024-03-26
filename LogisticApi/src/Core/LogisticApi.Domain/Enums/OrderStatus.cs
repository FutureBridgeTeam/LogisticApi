using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Domain.Enums
{
    public enum OrderStatus
    {
        GettingReady=1,
        ClearedCustoms,
        OnTheWay,
        ArrivedAtTheSetSpot
    }
}
