using BroadbandDeals.Entities;
using BroadbandDeals.Entities.Enums;
using BroadbandDeals.Entities.Request;
using BroadbandDeals.Entities.Response;
using BroadbandDeals.Service.Helper;
using BroadbandDeals.Service.IServiceContracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BroadbandDeals.Service.ServiceContracts
{
    public class BroadbandService : IBroadbandService
    {
        private readonly  IUtilityService _utilityService;
        public BroadbandService(IUtilityService utilityService)
        {
            _utilityService = utilityService;
        }

        /// <summary>
        /// Get broadband deals based on input request
        /// </summary>
        /// <param name="broadbandRequest"></param>
        /// <returns></returns>
        public BroadbandResult GetBroadbandDeals(BroadbandRequest broadbandRequest)
        {
            try
            {
                var dealJsonString = ReadDealsJson();
                var availableProductTypes = dealJsonString.Deals?.SelectMany(x => x.ProductTypes)?.Where(x => x != null)?.Distinct()?.ToList();
                var availableSpeeds = dealJsonString.Deals?.Select(x => x.Speed.Label)?.Distinct()?.ToList();
                dealJsonString.AvailableProductTypes = availableProductTypes;
                dealJsonString.AvailableSpeedTypes = availableSpeeds;
                if (broadbandRequest != null && ((broadbandRequest.ProductTypes != null && broadbandRequest.ProductTypes.Any()) || !string.IsNullOrEmpty(broadbandRequest.SpeedLabel)))
                {

                    if (dealJsonString != null && dealJsonString.Deals != null && dealJsonString.Deals.Any())
                    {
                        var deals = dealJsonString.Deals?.ToList();
                        var broadbandArray =new string[] { "Broadband", "Fibre Broadband" };
                        var selectedProductTypesWithoutBroadband = broadbandRequest.ProductTypes?.Where(p => !string.Equals(p, "Broadband", StringComparison.OrdinalIgnoreCase))?.ToList();
                        var hasBroadband = broadbandRequest.ProductTypes?.Any(x => string.Equals(x, "Broadband", StringComparison.OrdinalIgnoreCase)) ;
                        if (broadbandRequest.ProductTypes != null && broadbandRequest.ProductTypes.Any())
                        {
                            deals = deals.Where(x => x.ProductTypes != null && (x.ProductTypes.Count() == selectedProductTypesWithoutBroadband.Count + 1)).ToList();
                            if (selectedProductTypesWithoutBroadband.Count > 0 && hasBroadband.GetValueOrDefault())
                            {
                                deals = deals.Where(x => selectedProductTypesWithoutBroadband.All(r => x.ProductTypes.Contains(r))
                                && x.ProductTypes.Any(u => broadbandArray.Contains(u)))?.ToList();
                            }
                            else if (hasBroadband.GetValueOrDefault())
                            {
                                deals = deals.Where(x =>  x.ProductTypes.Any(u => broadbandArray.Contains(u)))?.ToList();
                            }

                        }
                        if (!string.IsNullOrEmpty(broadbandRequest.SpeedLabel))
                        {
                            deals = deals.Where(x => x.Speed != null && string.Equals(x.Speed.Label, broadbandRequest.SpeedLabel, StringComparison.OrdinalIgnoreCase))?.ToList();
                        }

                        dealJsonString.Deals = deals;
                    }
                }
                dealJsonString.Result = new Result(ResultStatus.Success);
                return dealJsonString;
            }
            catch (Exception ex)
            {
                LogManager.Error("Unexpected error occured on calling GetBroadbandDeals method in BroadbandService", ex);
                return new BroadbandResult(new Result(ResultStatus.Error, ex.Message));
            }
        }


        /// <summary>
        /// Read Deals json file
        /// </summary>
        /// <returns></returns>
        private BroadbandResult ReadDealsJson()
        {
            string result = string.Empty;
            try
            {
                var jsonString = _utilityService.GetJsonFileString();

                return JsonConvert.DeserializeObject<BroadbandResult>(jsonString);
            }
            catch (Exception ex)
            {
                LogManager.Error("Unexpected error occured on calling ReadDealsJson method in BroadbandService", ex);
            }
            return null;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }


}