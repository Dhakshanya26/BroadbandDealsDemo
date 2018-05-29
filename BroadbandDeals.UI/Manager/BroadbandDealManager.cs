using BroadbandDeals.UI.Enums;
using BroadbandDeals.UI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BroadbandDeals.UI.Manager
{
    public class BroadbandDealManager : IBroadbandDealManager
    {
        private readonly IHttpClientManager _httpClientManager;

        public BroadbandDealManager(IHttpClientManager httpClientManager)
        {
            _httpClientManager = httpClientManager;
        }
        public async Task<BroadBandDealModel> GetBroadbandDeals(string[] productTypes, string speed)
        {
            try
            {
                var broadbandDetails = await _httpClientManager.GetBroadbandDeals(productTypes, speed);

                if (broadbandDetails != null)
                {
                    if (broadbandDetails.Result != null)
                    {
                        var broadbandModel = new BroadBandDealModel() {
                            SelectedProductTypes = productTypes,
                            SelectedSpeed = speed
                        };
                        broadbandModel.ResultModel = new ResultModel(( ResultStatus)broadbandDetails.Result.ResultStatus, broadbandDetails.Result.ResultMessage);
                        broadbandModel.DealModels = broadbandDetails.Deals?.Select(MapDealModel)?.ToList();
                        return broadbandModel;
                    }

                }
                LogManager.Error($"Unexpected error occured. Unable to fetch broadband deals - GetBroadbandDeals() BroadbandDealManager");
                return new BroadBandDealModel()
                {
                    ResultModel = new ResultModel(ResultStatus.Fail, $"Unexpected error occured. Unable to fetch broadband deals")
                };
            }
            catch (Exception ex)
            {
                LogManager.Error($"Unexpected error occured on calling GetBroadbandDeals in BroadbandDealManager", ex);
                return new BroadBandDealModel()
                {
                    ResultModel = new ResultModel(ResultStatus.Error, $"Unexpected Error occured: {ex.Message}")
                };
            }
        }


        private DealModel MapDealModel(Entities.Deal deal)
        {
            return new DealModel()
            {
                ContractLength = deal.ContractLength,
                Id = deal.Id,
                Mobile = new MobileModel()
                {
                    ConnectionType = deal.Mobile?.ConnectionType?.Label,
                    Data = deal.Mobile?.Data?.Label,
                    Minutes = deal.Mobile?.Minutes?.Label,
                    Texts = deal.Mobile?.Texts?.Label
                },
                Offer = new OfferModel()
                {
                    Description = deal.Offer?.Description,
                    ExpiresAt = deal.Offer?.ExpiresAt,
                    SmallLogo = deal.Offer?.SmallLogo,
                    Title = deal.Offer?.Title,
                    Type = deal.Offer?.Type
                },
                Title = deal.Title,
                Price = deal.Prices?.FirstOrDefault()?.TotalContractCost,
                ProductTypes = deal.ProductTypes,
                SpeedLabel = deal.Speed?.Label,
                UsageLabel = deal.Usage?.Label,
                PopularChannels = deal.PopularChannels?.Where(u=> u != null).Select(u =>
                {
                    return new PopularChannelModel()
                    {
                        ChannelCategory = u.ChannelCategory,
                        Logo = u.Logo,
                        Name = u.Name
                    };
                })?.ToList(),
            };
        }
        public void Dispose()
        {
        }
    }
}