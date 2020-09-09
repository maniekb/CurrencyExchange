using CurrencyExchange.BusinessLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyExchange.BusinessLayer.Services
{
    public interface IRatesService : IService
    {
        Task<ExchangeRateDTO> GetRateAsync(string currency);
        Task<List<ExchangeRateDTO>> GetRatesAsync();
        List<string> GetAvailableCurrencies();
    }
}
