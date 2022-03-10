using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUST.Model.Models
{
    public class BaseResponseModel
    {
        public string Version { get; set; }
        public string Datetime { set; get; }
        public long Timestamp { get; set; }
        public string Status { set; get; }
        public int Code { set; get; }
        public string Message { set; get; }
        public dynamic Data { set; get; }
        public dynamic Errors { set; get; }
        public BaseResponseModel()
        {
            DateTime now = DateTime.UtcNow;

            Version = "1.0";
            Datetime = now.ToString("u");
            Timestamp = ((DateTimeOffset)now).ToUnixTimeSeconds();
            Status = "Error";
            Code = 400;
            Message = "Error";
            Data = null;
            Errors = null;
        }
    }
}
