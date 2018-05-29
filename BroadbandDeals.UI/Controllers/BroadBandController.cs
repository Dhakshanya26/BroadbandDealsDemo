using BroadbandDeals.UI.Manager;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BroadbandDeals.UI.Controllers
{
    public class BroadBandController : Controller
    {
        private readonly IBroadbandDealManager _broadbandDealManager;

        public BroadBandController(IBroadbandDealManager broadbandDealManager)
        {
            _broadbandDealManager = broadbandDealManager;
        }
        /// <summary>
        /// Get Broadband deals
        /// </summary>
        /// <param name="selectedProductTypes"></param>
        /// <param name="selectedSpeed"></param>
        /// <returns></returns>
        public async Task<ActionResult> Index(string selectedProductTypes, string selectedSpeed)
        {
            var productTypes = string.IsNullOrEmpty(selectedProductTypes) ? null : selectedProductTypes.Split(',');
            var broadBandDeals = await _broadbandDealManager.GetBroadbandDeals(productTypes, selectedSpeed);
            return View(broadBandDeals);
        }

    }
}