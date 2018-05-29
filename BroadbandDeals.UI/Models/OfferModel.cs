using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BroadbandDeals.UI.Models
{
    public class OfferModel
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string SmallLogo { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string Description { get; set; }
    }
}