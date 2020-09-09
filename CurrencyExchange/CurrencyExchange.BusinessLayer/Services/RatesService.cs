using CurrencyExchange.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyExchange.BusinessLayer.Services
{
    public class RatesService : IRatesService
    {
        private readonly RequestHandler<ExchangeRate> _requestHandler;

        public RatesService(ILoggingService loggingService)
        {
            _requestHandler = new RequestHandler<ExchangeRate>(new NBPResponseToRateParser(), loggingService);

        }

        public async Task<ExchangeRate> GetRateAsync(string code)
        {
            if (!Enum.IsDefined(typeof(Currencies), code.ToUpper()))
            {
                return null;
            }

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, string.Format("http://api.nbp.pl/api/exchangerates/rates/a/{0}/?format=json", code));

            return await _requestHandler.Handle(requestMessage);

        }

        public async Task<List<ExchangeRate>> GetRatesAsync()
        {
            var rates = new List<ExchangeRate>();

            foreach (var currency in Enum.GetValues(typeof(Currencies)))
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, string.Format("http://api.nbp.pl/api/exchangerates/rates/a/{0}/?format=json", currency));
                rates.Add(await _requestHandler.Handle(requestMessage));
            }

            return rates;
        }

        public List<string> GetAvailableCurrencies()
            => Enum.GetValues(typeof(Currencies))
                .Cast<Currencies>()
                .Select(v => v.ToString())
                .ToList();


    }
}
