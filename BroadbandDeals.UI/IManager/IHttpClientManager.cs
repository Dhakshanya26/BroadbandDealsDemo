using BroadbandDeals.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BroadbandDeals.UI.Manager
{
    public interface IHttpClientManager: IDisposable
    {
        Task<BroadbandResult> GetBroadbandDeals(string[] productTypes, string speed);
    }
}