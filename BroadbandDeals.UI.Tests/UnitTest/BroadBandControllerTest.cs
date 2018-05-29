using BroadbandDeals.UI.Controllers;
using BroadbandDeals.UI.Enums;
using BroadbandDeals.UI.Manager;
using BroadbandDeals.UI.Models;
using BroadbandDeals.UI.Tests.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BroadbandDeals.UI.Tests.UnitTest
{
    [TestClass]
    public class BroadBandControllerTest
    {

        /// <summary>
        /// Positive case
        /// </summary>
        [TestMethod]
        public async Task WhenNullInputPassed_ReturnAllRecords()
        {
            // Arrange
            var mockedBroadbandDealManager = new Mock<IBroadbandDealManager>();
            BroadBandController broadBandController = new BroadBandController(mockedBroadbandDealManager.Object);
            mockedBroadbandDealManager.Setup(m => m.GetBroadbandDeals(null, null)).Returns(Task.FromResult(TestdataGenerator.CreateFakeSuccessDealModel()));

            // Act
            var result = await broadBandController.Index(null, null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model != null);
            var model = (BroadBandDealModel)result.Model;
            Assert.IsTrue(model != null && model.DealModels != null && model.DealModels.Count > 0);
            Assert.IsTrue(model != null && model.ResultModel != null && model.ResultModel.ResultStatus == ResultStatus.Success);
        }

        [TestMethod]
        public async Task WhenValidInputPassed_ReturnRecordsBasedOnInput()
        {
            // Arrange
            var productTypes = new List<string> { "Broadband" };
            var speed = "17";
            var mockedBroadbandDealManager = new Mock<IBroadbandDealManager>();
            BroadBandController broadBandController = new BroadBandController(mockedBroadbandDealManager.Object);
            mockedBroadbandDealManager.Setup(m => m.GetBroadbandDeals(It.IsAny<string[]>(), It.IsAny<string>())).Returns(Task.FromResult(TestdataGenerator.CreateFakeSuccessDealModel(productTypes, speed)));

            // Act
            var result = await broadBandController.Index(It.IsAny<string>(), It.IsAny<string>()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model != null);
            var model = (BroadBandDealModel)result.Model;
            Assert.IsTrue(model != null && model.DealModels != null && model.DealModels.Count > 0);
            Assert.IsTrue(model != null && model.ResultModel != null && model.ResultModel.ResultStatus == ResultStatus.Success);
        }

        /// <summary>
        /// Exception case
        /// </summary>
        [TestMethod]
        public async Task WhenAnyExceptionOccured_ReturnErrorResult()
        {
            // Arrange
            var mockedBroadbandDealManager = new Mock<IBroadbandDealManager>();
            BroadBandController broadBandController = new BroadBandController(mockedBroadbandDealManager.Object);
            mockedBroadbandDealManager.Setup(m => m.GetBroadbandDeals(null, null)).Returns(Task.FromResult(TestdataGenerator.CreateFakeErrorDealModel()));

            // Act
            var result = await broadBandController.Index(null, null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var model = (BroadBandDealModel)result.Model;
            Assert.IsTrue(model != null && model.ResultModel != null && model.ResultModel.ResultStatus == ResultStatus.Error);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public async Task WhenAnyExceptionOccured_ThrowException()
        {
            // Arrange
            var mockedBroadbandDealManager = new Mock<IBroadbandDealManager>();
            BroadBandController broadBandController = new BroadBandController(mockedBroadbandDealManager.Object);
            mockedBroadbandDealManager.Setup(m => m.GetBroadbandDeals(null, null)).Throws(new NullReferenceException());

            // Act
            var result = await broadBandController.Index(null, null) as ViewResult;

        }
    }
}
