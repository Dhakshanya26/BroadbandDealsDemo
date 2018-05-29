using BroadbandDeals.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BroadbandDeals.Service.Helper
{
    public interface IDealSpecificFilter
    {
        bool Match(Deal deal);
    }

}