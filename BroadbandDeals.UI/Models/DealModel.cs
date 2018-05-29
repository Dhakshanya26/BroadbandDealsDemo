using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BroadbandDeals.UI.Models
{
    public class DealModel
    {
        public string Title { get; set; }
        public double? Price { get; set; }
        public int Id { get; set; }
        public int ContractLength { get; set; }
        public string SpeedLabel { get; set; }
        public string UsageLabel { get; set; }
        public MobileModel Mobile { get; set; }
        public OfferModel Offer { get; set; }
        public List<string> ProductTypes { get; set; }
        public List<PopularChannelModel> PopularChannels { get; set; }
    }
}