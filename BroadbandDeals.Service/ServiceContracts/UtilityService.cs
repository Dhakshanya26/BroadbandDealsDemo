using BroadbandDeals.Service.IServiceContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BroadbandDeals.Service.ServiceContracts
{
    public class UtilityService : IUtilityService
    {

        /// <summary>
        /// Get file path
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GetJsonFileString() {
            var filePath= System.Web.Hosting.HostingEnvironment.MapPath(System.Configuration.ConfigurationManager.AppSettings["DealJsonFileName"]);
            using (StreamReader r = new StreamReader(filePath))
            {
                return r.ReadToEnd();
            }
        }
    }
}