using CurrencyExchange.BusinessLayer.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyExchange.BusinessLayer.Services
{
    public class NBPResponseToRateParser : IHttpResponseParser<ExchangeRate>
    {
        public async Task<ExchangeRate> ParseAsync(HttpResponseMessage response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var content = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(content);

            var code = (string)jObject["code"];
            var currency = (string)jObject["currency"];
            var rates = jObject["rates"];
            var value = (decimal)rates[0]["mid"];

            var rate = new ExchangeRate(code, currency, value);

            return rate;
        }
    }
}
