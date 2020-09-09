using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.BusinessLayer.Services
{
    public interface ILoggingService : IService
    {
        Task LogAsync(string path, string method, int? code, DateTime datetime);
    }
}
