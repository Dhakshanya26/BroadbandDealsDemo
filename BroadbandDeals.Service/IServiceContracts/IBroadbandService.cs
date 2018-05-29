using BroadbandDeals.Entities;
using BroadbandDeals.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BroadbandDeals.Service.IServiceContracts
{
    public interface IBroadbandService :IDisposable
    {
        BroadbandResult GetBroadbandDeals(BroadbandRequest broadbandRequest);
    }
}