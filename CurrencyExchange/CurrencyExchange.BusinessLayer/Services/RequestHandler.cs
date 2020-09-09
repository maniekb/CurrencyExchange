using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyExchange.BusinessLayer.Services
{
    public class RequestHandler<TResponse>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private IHttpResponseParser<TResponse> _parser { get; }

        public RequestHandler(IHttpResponseParser<TResponse> parser)
        {
            _parser = parser;
        }

        public async Task<TResponse> Handle(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                return await _parser.ParseAsync(response);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}