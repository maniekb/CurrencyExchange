using AutoMapper;
using CurrencyExchange.BusinessLayer.DTO;
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
        private readonly IMapper _mapper;

        public RatesService(ILoggingService loggingService, IMapper mapper)
        {
            _requestHandler = new RequestHandler<ExchangeRate>(new NBPResponseToRateParser(), loggingService);
            _mapper = mapper;
        }

        public async Task<ExchangeRateDTO> GetRateAsync(string code)
        {
            if (!Enum.IsDefined(typeof(Currencies), code.ToUpper()))
            {
                return null;
            }

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, string.Format("http://api.nbp.pl/api/exchangerates/rates/a/{0}/?format=json", code));

            var rate = await _requestHandler.Handle(requestMessage);
            return _mapper.Map<ExchangeRate, ExchangeRateDTO>(rate);

        }

        public async Task<List<ExchangeRateDTO>> GetRatesAsync()
        {
            var rates = new List<ExchangeRate>();

            foreach (var currency in Enum.GetValues(typeof(Currencies)))
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, string.Format("http://api.nbp.pl/api/exchangerates/rates/a/{0}/?format=json", currency));
                rates.Add(await _requestHandler.Handle(requestMessage));
            }

            return _mapper.Map<List<ExchangeRate>, List<ExchangeRateDTO>>(rates);
        }

        public List<string> GetAvailableCurrencies()
            => Enum.GetValues(typeof(Currencies))
                .Cast<Currencies>()
                .Select(v => v.ToString())
                .ToList();


    }
}
