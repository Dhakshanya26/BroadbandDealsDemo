using BroadbandDeals.Entities.Enums;
using BroadbandDeals.Service.Controllers;
using BroadbandDeals.Service.IServiceContracts;
using BroadbandDeals.Service.Tests.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BroadbandDeals.Service.Tests.UnitTest
{

    [TestClass]
    public class BroadbandDealControllerTest
    {
        [TestMethod]
        public void WhenNullInputPassed_ReturnMatchingBroadbandDeals()
        {
            var mockBroadbandService = new Mock<IBroadbandService>();
            mockBroadbandService.Setup(m => m.GetBroadbandDeals(null)).Returns(TestDataGenerator.CreateFakeBroadbandResult());
            var bbcFeedController = new BroadbandDealController(mockBroadbandService.Object);

            //Act
            var response = bbcFeedController.Get(null);

            // Assert
            Assert.IsTrue(response != null && response.Deals != null);
            Assert.IsTrue(response.Deals.Count > 0);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == ResultStatus.Success);
        }

        [TestMethod]
        public void WhenValidInputPassed_ReturnMatchingBroadbandDeals()
        {
            var mockBroadbandService = new Mock<IBroadbandService>();
            mockBroadbandService.Setup(m => m.GetBroadbandDeals(It.IsAny<Entities.Request.BroadbandRequest>())).Returns(TestDataGenerator.CreateFakeBroadbandResult());
            var bbcFeedController = new BroadbandDealController(mockBroadbandService.Object);

            //Act
            var response = bbcFeedController.Get(new Entities.Request.BroadbandRequest());

            // Assert
            Assert.IsTrue(response != null && response.Deals != null);
            Assert.IsTrue(response.Deals.Count > 0);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == ResultStatus.Success);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void WhenAnyExceptionOccured_ThrowException()
        {
            var mockBroadbandService = new Mock<IBroadbandService>();
            mockBroadbandService.Setup(m => m.GetBroadbandDeals(null)).Throws(new NullReferenceException());
            var bbcFeedController = new BroadbandDealController(mockBroadbandService.Object);

            //Act
            var response = bbcFeedController.Get(null);

        }
    }
}
