using CurrencyExchange.BusinessLayer.Models;
using System;
using System.Threading.Tasks;

namespace CurrencyExchange.BusinessLayer.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IRatesService _ratesService;

        public ExchangeService(IRatesService ratesService)
        {
            _ratesService = ratesService;
        }

        public async Task<decimal?> CalculateExchange(decimal amount, string from, string to)
        {
            if (!Enum.IsDefined(typeof(Currencies), from.ToUpper()) || !Enum.IsDefined(typeof(Currencies), from.ToUpper()))
            {
                return null;
            }

            var fromRate = await _ratesService.GetRateAsync(from);
            var toRate = await _ratesService.GetRateAsync(to);

            return decimal.Round(amount * fromRate.Rate / toRate.Rate, 2, MidpointRounding.AwayFromZero);
        }
    }
}
