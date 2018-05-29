using BroadbandDeals.UI.Enums;
using BroadbandDeals.UI.Manager;
using BroadbandDeals.UI.Tests.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadbandDeals.UI.Tests
{
    [TestClass]
    public class BroadbandDealManagerTest
    {

        #region test Broadbanddeals
        [TestMethod]
        public async Task WhenValidInputPassed_ReturnSuccessResult()
        {
            //Arrage
            var mockHttpClientManager = new Mock<IHttpClientManager>();
            mockHttpClientManager.Setup(m => m.GetBroadbandDeals(null,null)).Returns(Task.FromResult(TestdataGenerator.CreateFakeBroadbandResult()));
            var broadbandDealManager = new BroadbandDealManager(mockHttpClientManager.Object);

            //Act
            var response = await broadbandDealManager.GetBroadbandDeals(null,null);

            // Assert
            Assert.IsTrue(response != null && response.DealModels != null);
            Assert.IsTrue(response.DealModels.Count > 0);
            Assert.IsTrue(response.ResultModel != null && response.ResultModel.ResultStatus == ResultStatus.Success);
        }
        [TestMethod]
        public async Task WhenHttpClientInvokedIsNotOk_ShouldReturnFailureResult()
        {
            //Arrage
            var mockHttpClientManager = new Mock<IHttpClientManager>();
            mockHttpClientManager.Setup(m => m.GetBroadbandDeals(null,null)).Returns(Task.FromResult(
            new Entities.BroadbandResult() {
            Result = new Entities.Response.Result(Entities.Enums.ResultStatus.Fail, string.Empty)
            }));
            var broadbandDealManager = new BroadbandDealManager(mockHttpClientManager.Object);

            //Act
            var response = await broadbandDealManager.GetBroadbandDeals(null,null);

            // Assert
            Assert.IsTrue(response != null && response.DealModels == null);
            Assert.IsTrue(response.ResultModel != null && response.ResultModel.ResultStatus == ResultStatus.Fail);
        }

        [TestMethod]
        public async Task WhenHttpClientThrowsAnyError_ShouldReturnErrorResult()
        {
            //Arrage
            var mockHttpClientManager = new Mock<IHttpClientManager>();
            var broadbandDealManager = new BroadbandDealManager(null);
            mockHttpClientManager.Setup(m => m.GetBroadbandDeals(null, null)).Throws(new Exception());

            //Act
            var response = await broadbandDealManager.GetBroadbandDeals(null,null);

            // Assert
            Assert.IsTrue(response != null && response.DealModels == null);
            Assert.IsTrue(response.ResultModel != null && response.ResultModel.ResultStatus == ResultStatus.Error);
        }

        #endregion


    }
}
