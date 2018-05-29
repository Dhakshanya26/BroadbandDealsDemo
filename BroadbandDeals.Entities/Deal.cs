
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BroadbandDeals.Entities
{
   
    public class Deal
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        public List<Price> Prices { get; set; }
        public int Id { get; set; }
        public int ContractLength { get; set; }
        public LabelValue Speed { get; set; }
        public string TvProduct { get; set; }
        public LabelValue StandardChannels { get; set; }
        public LabelValue TotalChannels { get; set; }
        public LabelValue HdChannels { get; set; }
        public LabelValue Usage { get; set; }
        public Mobile Mobile { get; set; }
        public Offer Offer { get; set; }
        public Provider Provider { get; set; }
        public double NewLineCost { get; set; }
        public List<UpfrontCost> UpfrontCosts { get; set; }
        public List<string> ProductTypes { get; set; }
        public PremiumFeatures PremiumFeatures { get; set; }
        public List<PopularChannel> PopularChannels { get; set; }
        public string TelephoneNumber { get; set; }
        public Extras Extras { get; set; }
        public string BroadbandType { get; set; }
    }
}
