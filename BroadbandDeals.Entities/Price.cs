using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadbandDeals.Entities
{

    public class Price
    {
        public List<Period>  Periods { get; set; }
        public double FirstYear { get; set; }
        public double TotalContractCost { get; set; }
        public double UpFrontCost { get; set; }
    }
}
