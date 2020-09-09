using System;

namespace CurrencyExchange.BusinessLayer.Models
{
    public class RequestLog
    {
        public int Id { get; set; }
        public RequestType Type { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public int? ResponseStatusCode { get; set; }
        public DateTime Datetime { get; set; }

        public RequestLog()
        {
        }

        public RequestLog(RequestType type, string path, string method, int? code, DateTime datetime)
        {
            Type = type;
            Path = path;
            Method = method;
            ResponseStatusCode = code;
            Datetime = datetime;
        }
    }
}
