using BroadbandDeals.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BroadbandDeals.UI.Manager
{
    public interface IBroadbandDealManager: IDisposable
    {
        Task<BroadBandDealModel> GetBroadbandDeals(string[] productTypes, string speed);
    }
}