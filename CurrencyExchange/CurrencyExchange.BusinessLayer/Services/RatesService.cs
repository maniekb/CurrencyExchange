using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.BusinessLayer.Models;

namespace CurrencyExchange.BusinessLayer.Services
{
    public class RatesService : IRatesService
    {
        private readonly RequestHandler<ExchangeRate> _requestHandler = new RequestHandler<ExchangeRate>(new NBPResponseToRateParser());

        public RatesService()
        {
        }

        public async Task<ExchangeRate> GetRateAsync(string code)
        {
            if (!Enum.IsDefined(typeof(Currencies), code.ToUpper()))
            {
                return null;
            }

            return await _requestHandler.Handle(string.Format("http://api.nbp.pl/api/exchangerates/rates/a/{0}/?format=json", code));

        }

        public async Task<List<ExchangeRate>> GetRatesAsync()
        {
            var rates = new List<ExchangeRate>();

            foreach (var currency in Enum.GetValues(typeof(Currencies)))
            {
                rates.Add(await _requestHandler.Handle(string.Format("http://api.nbp.pl/api/exchangerates/rates/a/{0}/?format=json", currency)));
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
