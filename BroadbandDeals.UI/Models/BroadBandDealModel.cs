using System;
using System.Collections.Generic;

namespace BroadbandDeals.UI.Models
{
    public class BroadBandDealModel : BasePageModel
    {
        public BroadBandDealModel() 
        {
        }
        public List<DealModel> DealModels { get; set; }
        public ResultModel ResultModel { get; set; }
    }
}