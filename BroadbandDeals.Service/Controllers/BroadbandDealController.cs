using BroadbandDeals.Entities;
using BroadbandDeals.Entities.Request;
using BroadbandDeals.Service.IServiceContracts;
using System.Web.Http;

namespace BroadbandDeals.Service.Controllers
{
    public class BroadbandDealController : ApiController
    {
        private readonly IBroadbandService _broadbandService;

        /// <summary>
        /// Intialize
        /// </summary>
        /// <param name="broadbandService"></param>
        public BroadbandDealController(IBroadbandService broadbandService)
        {
            _broadbandService = broadbandService;
        }

        /// <summary>
        /// Get broad band deals
        /// </summary>
        /// <param name="broadbandRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public BroadbandResult Get([FromBody]BroadbandRequest broadbandRequest)
        { 
            return _broadbandService.GetBroadbandDeals(broadbandRequest);
        }

    }
}
