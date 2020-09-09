using CurrencyExchange.BusinessLayer.Models;
using System;
using System.Threading.Tasks;

namespace CurrencyExchange.BusinessLayer.Services
{
    public interface ILoggingService : IService
    {
        Task LogAsync(RequestType type, string path, string method, int? code, DateTime datetime);
    }
}
