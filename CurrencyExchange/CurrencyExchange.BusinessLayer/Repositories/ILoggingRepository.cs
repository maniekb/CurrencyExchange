using CurrencyExchange.BusinessLayer.Models;
using System.Threading.Tasks;

namespace CurrencyExchange.BusinessLayer.Repositories
{
    public interface ILoggingRepository : IRepository
    {
        Task SaveLogAsync(RequestLog log);
    }
}
