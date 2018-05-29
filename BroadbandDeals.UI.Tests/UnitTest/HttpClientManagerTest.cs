using BroadbandDeals.Entities.Enums;
using BroadbandDeals.UI.Manager;
using BroadbandDeals.UI.Tests.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BroadbandDeals.UI.Tests.UnitTest
{
    [TestClass]
    public class HttpClientManagerTest
    {

        #region test GetRssFeeds


        [TestMethod]
        public async Task WhenNullInputPassed_ReturnSuccessResultWithFeeds()
        {
            //Arrage
            var data = JsonConvert.SerializeObject(TestdataGenerator.CreateFakeBroadbandResult());

            var responseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(data, System.Text.Encoding.UTF8, "application/json"),
            };
            var messageHandler = new FakeHttpMessageHandler(responseMessage);
            var _httpClientManager = new HttpClientManager(messageHandler);

            //Act
            var response = await _httpClientManager.GetBroadbandDeals(null,null);

            // Assert
            Assert.IsTrue(response != null && response.Deals != null);
            Assert.IsTrue(response.Deals.Count > 0);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == ResultStatus.Success);
        }


        [TestMethod]
        public async Task WhenValidInputPassed_ReturnListofDeals()
        {
            //Arrage
            var productTypes = new List<string> { "Broadband" };
            var speed = "17";
            var data = JsonConvert.SerializeObject(TestdataGenerator.CreateFakeBroadbandResult());

            var responseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(data, System.Text.Encoding.UTF8, "application/json"),
            };
            var messageHandler = new FakeHttpMessageHandler(responseMessage);
            var _httpClientManager = new HttpClientManager(messageHandler);

            //Act
            var response = await _httpClientManager.GetBroadbandDeals(It.IsAny<string[]>(), It.IsAny<string>());

            // Assert
            Assert.IsTrue(response != null && response.Deals != null);
            Assert.IsTrue(response.Deals.Count > 0);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == ResultStatus.Success);
        }

        [TestMethod]
        public async Task WhenAnyExceptionThrown_ReturnErrorResult()
        {
            //Arrage
            var messageHandler = new FakeHttpMessageHandler(null);
            var _httpClientManager = new HttpClientManager(messageHandler);

            //Act
            var response = await _httpClientManager.GetBroadbandDeals(It.IsAny<string[]>(), It.IsAny<string>());

            // Assert
            Assert.IsTrue(response != null && response.Deals == null);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == ResultStatus.Error);
        }


        #endregion


    }
}
