using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadbandDeals.DataLayer.IRepository
{
    public interface IDealRepository: IDisposable
    {
        string GetDealJsonAsString();
    }
}
