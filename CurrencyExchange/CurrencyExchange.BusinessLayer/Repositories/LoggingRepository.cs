using CurrencyExchange.BusinessLayer.EF;
using CurrencyExchange.BusinessLayer.Models;
using System.Threading.Tasks;

namespace CurrencyExchange.BusinessLayer.Repositories
{
    class LoggingRepository : ILoggingRepository
    {
        private readonly CurrencyExchangeContext _context;

        public LoggingRepository(CurrencyExchangeContext context)
        {
            _context = context;
        }

        public async Task SaveLogAsync(RequestLog log)
        {
            _context.RequestLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
