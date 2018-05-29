using BroadbandDeals.UI.Enums;
using BroadbandDeals.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadbandDeals.UI.Tests.Setup
{
    public static class TestdataGenerator
    {

        public static BroadBandDealModel CreateFakeSuccessDealModel(List<string> productTypes =null,string speed =null)
        {
            return new BroadBandDealModel()
            {
                DealModels = new List<DealModel>() {
                        new DealModel(){
                            ContractLength=12,
                            Id=234,
                            Mobile= new MobileModel(){
                                Data="Unlimited",
                            },
                            Offer= new OfferModel(){
                                Title="50%"
                            },
                            Price=876.00,
                            Title="Broadband only",
                            ProductTypes=new List<string>{"Broadband","Mobile" },
                            PopularChannels= new List<PopularChannelModel>(),
                            SpeedLabel= "17",
                            UsageLabel="unlimited"
                        }
                    },
                ResultModel = new ResultModel(ResultStatus.Success, string.Empty)
            };

        }


        public static BroadBandDealModel CreateFakeFailureDealModel()
        {
            return new BroadBandDealModel()
            {
                ResultModel = new ResultModel(ResultStatus.Fail, "unexpected error occurred")
            };

        }

        public static BroadBandDealModel CreateFakeErrorDealModel()
        {
            return new BroadBandDealModel()
            {
                ResultModel = new ResultModel(ResultStatus.Error, "unexpected error occurred")
            };

        }

        public static Entities.BroadbandResult CreateFakeBroadbandResult(List<string> productTypes = null, string speed = null)
        {
            return new Entities.BroadbandResult()
            {
                Deals = new List<Entities.Deal>() {
                        new Entities.Deal(){
                            ContractLength=12,
                            Id=234,
                        },
                         new Entities.Deal(){
                            ContractLength=127,
                            Id=24,
                        }
                    },
                Result = new Entities.Response.Result(Entities.Enums.ResultStatus.Success, string.Empty)
            };

        }
    }
}
