using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadbandDeals.Entities.Request
{
    public class BroadbandRequest
    {

        private string _productTypeString;

        public string ProductTypeString
        {
            get
            {
                return _productTypeString;
            }
            set
            {
                ProductTypes = value?.Split(',')?.ToList();
                _productTypeString = value;
            }
        }
        public List<string> ProductTypes { get; set; }
        public string SpeedLabel { get; set; }
    }
}
