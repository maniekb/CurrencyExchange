using CurrencyExchange.BusinessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyExchange.BusinessLayer.Services
{
    public interface IRatesService : IService
    {
        Task<ExchangeRate> GetRateAsync(string currency);
        Task<List<ExchangeRate>> GetRatesAsync();
        List<string> GetAvailableCurrencies();
    }
}
