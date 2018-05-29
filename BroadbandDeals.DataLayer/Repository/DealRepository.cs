using BroadbandDeals.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;

namespace BroadbandDeals.DataLayer.Repository
{
    /// <summary>
    /// Deal Repository
    /// </summary>
    public class DealRepository : IDealRepository
    {

        /// <summary>
        /// Read deal json from local file and return json string
        /// </summary>
        /// <returns></returns>
        public string GetDealJsonAsString()
        {
            string result = string.Empty;
            try
            {
                string filepath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"\deals.json");
                string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                //string[] files = File.ReadAllLines(path);
               _filePath = Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName;

                var jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "deals.json");

                string currentDirectory = Directory.GetCurrentDirectory();
                string filePath = System.IO.Path.Combine(currentDirectory,"deals.json");
                using (StreamReader r = new StreamReader(filePath))
                {
                    var json = r.ReadToEnd();
                    var jsonObject = JsonConvert.SerializeObject(json);
                    //foreach (var item in jsonObject.Properties())
                    //{
                    //    item.Value = item.Value.ToString().Replace("v1", "v2");
                    //}
                    result = jsonObject.ToString();
                }
            }
            catch (Exception ex)
            {
              //Log Error
            }
            return result;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            //dispose unused objects.
        }
    }
}
