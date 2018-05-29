using BroadbandDeals.Service.IServiceContracts;
using BroadbandDeals.Service.ServiceContracts;
using BroadbandDeals.Service.Tests.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadbandDeals.Service.Tests.UnitTest
{

    [TestClass]
    public class BroadbandServiceTest
    {

        #region test GetRssFeed

        [TestMethod]
        public void WhenNullInputPassed_ReturnAllDeals()
        {
            //Arrage
            var mockUtilityService = new Mock<IUtilityService>();
            mockUtilityService.Setup(m => m.GetJsonFileString()).Returns(TestDataGenerator.GetValidDealJsonString());
            var broadbandService = new BroadbandService(mockUtilityService.Object);

            //Act
            var response = broadbandService.GetBroadbandDeals(null);

            // Assert
            Assert.IsTrue(response != null && response.Deals != null);
            Assert.IsTrue(response.Deals.Count > 0);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == Entities.Enums.ResultStatus.Success);
        }

        [TestMethod]
        public void WhenBroadbandProductTypePassed_ReturnDealsSpecificToProductType()
        {
            //Arrage
            var mockUtilityService = new Mock<IUtilityService>();
            mockUtilityService.Setup(m => m.GetJsonFileString()).Returns(TestDataGenerator.GetValidDealJsonString());
            var broadbandService = new BroadbandService(mockUtilityService.Object);

            //Act
            var response = broadbandService.GetBroadbandDeals(new Entities.Request.BroadbandRequest() {
                ProductTypes=new List<string> { "Broadband"}
            });

            // Assert
            Assert.IsTrue(response != null && response.Deals != null);
            Assert.IsTrue(response.Deals.Count==4);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == Entities.Enums.ResultStatus.Success);
        }

        [TestMethod]
        public void WhenBroadbandAndTvProductTypePassed_ReturnDealsSpecificToProductType()
        {
            //Arrage
            var mockUtilityService = new Mock<IUtilityService>();
            mockUtilityService.Setup(m => m.GetJsonFileString()).Returns(TestDataGenerator.GetValidDealJsonString());
            var broadbandService = new BroadbandService(mockUtilityService.Object);

            //Act
            var response = broadbandService.GetBroadbandDeals(new Entities.Request.BroadbandRequest()
            {
                ProductTypes = new List<string> { "Broadband","TV" }
            });

            // Assert
            Assert.IsTrue(response != null && response.Deals != null);
            Assert.IsTrue(response.Deals.Count == 4);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == Entities.Enums.ResultStatus.Success);
        }

        [TestMethod]
        public void WhenBroadbandAndMobileProductTypePassed_ReturnDealsSpecificToProductType()
        {
            //Arrage
            var mockUtilityService = new Mock<IUtilityService>();
            mockUtilityService.Setup(m => m.GetJsonFileString()).Returns(TestDataGenerator.GetValidDealJsonString());
            var broadbandService = new BroadbandService(mockUtilityService.Object);

            //Act
            var response = broadbandService.GetBroadbandDeals(new Entities.Request.BroadbandRequest()
            {
                ProductTypes = new List<string> { "Broadband", "Mobile" }
            });

            // Assert
            Assert.IsTrue(response != null && response.Deals != null);
            Assert.IsTrue(response.Deals.Count == 1);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == Entities.Enums.ResultStatus.Success);
        }

        [TestMethod]
        public void WhenBroadbandAndMobileAndTVProductTypePassed_ShouldNotReturnDealsWith5Mb()
        {
            //Arrage
            var mockUtilityService = new Mock<IUtilityService>();
            mockUtilityService.Setup(m => m.GetJsonFileString()).Returns(TestDataGenerator.GetValidDealJsonString());
            var broadbandService = new BroadbandService(mockUtilityService.Object);

            //Act
            var response = broadbandService.GetBroadbandDeals(new Entities.Request.BroadbandRequest()
            {
                ProductTypes = new List<string> { "Broadband", "Mobile" ,"TV"}
            });

            // Assert
            Assert.IsTrue(response != null && response.Deals != null);
            Assert.IsTrue(response.Deals.Where(x=>x.Mobile != null && x.Mobile.Data != null&&  x.Mobile.Data.Label == "5 GB").Count() == 0);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == Entities.Enums.ResultStatus.Success);
        }

        [TestMethod]
        public void WhenBroadbandAndMobileAndTVProductTypePassed_ReturnDealsSpecificToProductType()
        {
            //Arrage
            var mockUtilityService = new Mock<IUtilityService>();
            mockUtilityService.Setup(m => m.GetJsonFileString()).Returns(TestDataGenerator.GetValidDealJsonString());
            var broadbandService = new BroadbandService(mockUtilityService.Object);

            //Act
            var response = broadbandService.GetBroadbandDeals(new Entities.Request.BroadbandRequest()
            {
                ProductTypes = new List<string> { "Broadband", "Mobile", "TV" }
            });

            // Assert
            Assert.IsTrue(response != null && response.Deals != null);
            Assert.IsTrue(response.Deals.Where(x => x.Mobile != null && x.Mobile.Data.Label == "4 GB").Count() == 2);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == Entities.Enums.ResultStatus.Success);
        }

        [TestMethod]
        public void WhenBroadbandProductTypeAndSpeed76MbPassed_ReturnDealsSpecificToProductType()
        {
            //Arrage
            var mockUtilityService = new Mock<IUtilityService>();
            mockUtilityService.Setup(m => m.GetJsonFileString()).Returns(TestDataGenerator.GetValidDealJsonString());
            var broadbandService = new BroadbandService(mockUtilityService.Object);

            //Act
            var response = broadbandService.GetBroadbandDeals(new Entities.Request.BroadbandRequest()
            {
                ProductTypes = new List<string> { "Broadband" },
                SpeedLabel="76"

            });

            // Assert
            Assert.IsTrue(response != null && response.Deals != null);
            Assert.IsTrue(response.Deals.Count == 2);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == Entities.Enums.ResultStatus.Success);
        }


        [TestMethod]
        public void WhenInJsonReturned_ReturnErrorresponse()
        {
            //Arrage
            var mockUtilityService = new Mock<IUtilityService>();
            mockUtilityService.Setup(m => m.GetJsonFileString()).Returns(TestDataGenerator.GetInValidDealJsonString());
            var broadbandService = new BroadbandService(mockUtilityService.Object);

            //Act
            var response = broadbandService.GetBroadbandDeals(null);

            // Assert
            Assert.IsTrue(response != null && response.Deals == null);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == Entities.Enums.ResultStatus.Error);
        }

        [TestMethod]
        public void WhenAnyExceptionOccurs_ShouldReturnErrorResponse()
        {
            //Arrage
            var mockUtilityService = new Mock<IUtilityService>();
            mockUtilityService.Setup(m => m.GetJsonFileString()).Returns(It.IsAny<string>());
            var broadbandService = new BroadbandService(mockUtilityService.Object);

            //Act
            var response = broadbandService.GetBroadbandDeals(null);

            // Assert
            Assert.IsTrue(response != null && response.Deals == null);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == Entities.Enums.ResultStatus.Error);
        }

        #endregion

    }

}
