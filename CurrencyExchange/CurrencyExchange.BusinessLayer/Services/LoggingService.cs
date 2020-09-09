using CurrencyExchange.BusinessLayer.Models;
using CurrencyExchange.BusinessLayer.Repositories;
using System;
using System.Threading.Tasks;

namespace CurrencyExchange.BusinessLayer.Services
{
    class LoggingService : ILoggingService
    {
        private readonly ILoggingRepository _loggingRepository;
        public LoggingService(ILoggingRepository loggingRepository)
        {
            _loggingRepository = loggingRepository;
        }
        public async Task LogAsync(RequestType type, string path, string method, int? code, DateTime datetime)
        {
            var log = new RequestLog(type, path, method, code, datetime);

            await _loggingRepository.SaveLogAsync(log);
        }
    }
}
