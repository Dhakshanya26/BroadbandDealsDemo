using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BroadbandDeals.UI.Models
{
    public abstract class BasePageModel
    {
        public BasePageModel()
        {

        }
        public string[] SelectedProductTypes { get; set; }
        public string SelectedSpeed { get; set; }

    }
}