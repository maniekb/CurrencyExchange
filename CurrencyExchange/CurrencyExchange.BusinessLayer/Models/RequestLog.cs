using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange.BusinessLayer.Models
{
    public class RequestLog
    {
        public string Path { get; set; }
        public string Method { get; set; }
        public int? ResponseStatusCode { get; set; }
        public DateTime Datetime { get; set; }

        public RequestLog()
        {
        }

        public RequestLog(string path, string method, int? code, DateTime datetime)
        {
            Path = path;
            Method = method;
            ResponseStatusCode = code;
            Datetime = datetime;
        }
    }
}
