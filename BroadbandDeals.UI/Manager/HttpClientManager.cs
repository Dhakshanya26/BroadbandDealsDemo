using BroadbandDeals.Entities;
using BroadbandDeals.Entities.Enums;
using BroadbandDeals.Entities.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BroadbandDeals.UI.Manager
{
    public class HttpClientManager : IHttpClientManager
    {
        private HttpMessageHandler _httpMessageHandler;

        /// <summary>
        /// Intialize
        /// </summary>
        public HttpClientManager(HttpMessageHandler httpMessageHandler)
        {
            _httpMessageHandler = httpMessageHandler;
        }


        public async Task<BroadbandResult> GetBroadbandDeals(string[] productTypes, string speed)
        {
            try
            {
                var httpClient = new HttpClient(_httpMessageHandler);
                httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BroadbandWebApi.Url"]);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = (productTypes == null || !productTypes.Any()) && string.IsNullOrEmpty(speed) ? null
                    : new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("ProductTypeString",productTypes == null? null: string.Join("," ,productTypes)),
                new KeyValuePair<string, string>("SpeedLabel", speed)
                });

                HttpResponseMessage response = await httpClient.PostAsync(ConfigurationManager.AppSettings["BroadbandWebApi.GetDeals.Url"], content);
                if (response.IsSuccessStatusCode)
                {

                    var details = response.Content.ReadAsAsync<BroadbandResult>().Result;
                    return details;
                }
                else
                {
                    LogManager.Info("Sorry, it looks like the broadband deal service is not working.");
                    return new BroadbandResult()
                    {
                        Result = new Result()
                        {
                            ResultStatus = ResultStatus.Fail,
                            ResultMessage = "Sorry, it looks like the broadband deal service is not working."
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                LogManager.Error($"Unexpected error occured on calling GetBroadbandDeals in HttpClientManager", ex);
                return new BroadbandResult()
                {
                    Result = new Result()
                    {
                        ResultStatus = ResultStatus.Error,
                        ResultMessage = $"Unexpected Error occured: {ex.Message}"
                    }
                };
            }
        }

        public void Dispose()
        {
        }
    }
}