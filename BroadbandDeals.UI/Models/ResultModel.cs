using BroadbandDeals.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BroadbandDeals.UI.Models
{
    public class ResultModel
    {
        public ResultStatus ResultStatus { get; set; }

        public string ResultMessage { get; set; }

        public ResultModel(ResultStatus resultStatus, string resultMessage)
        {
            ResultStatus = resultStatus;
            ResultMessage = resultMessage;
        }
        public ResultModel(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public ResultModel() : this(ResultStatus.Success, string.Empty)
        {
        }
    }
}