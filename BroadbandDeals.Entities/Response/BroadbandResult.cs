using BroadbandDeals.Entities.Request;
using BroadbandDeals.Entities.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BroadbandDeals.Entities
{
    public class BroadbandResult
    {
        [JsonProperty("deals")]
        public List<Deal> Deals { get; set; }
        public Result Result { get; set; }
        public List<string> AvailableProductTypes { get; set; }
        public List<string> AvailableSpeedTypes { get; set; }
        public BroadbandResult(Result result)
        {
            Result = result;
        }

        public BroadbandResult()
        {
            Result = new Result(Enums.ResultStatus.Success);
        }
    }

}
