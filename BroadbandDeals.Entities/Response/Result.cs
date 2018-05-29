using BroadbandDeals.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadbandDeals.Entities.Response
{
    public class Result
    {
        public ResultStatus ResultStatus { get; set; }

        public string ResultMessage { get; set; }

        public Result(ResultStatus resultStatus, string resultMessage)
        {
            ResultStatus = resultStatus;
            ResultMessage = resultMessage;
        }
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result() : this(ResultStatus.Success, string.Empty)
        {
        }
    }
}
