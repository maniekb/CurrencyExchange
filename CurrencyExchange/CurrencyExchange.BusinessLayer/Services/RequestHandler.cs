using CurrencyExchange.BusinessLayer.Models;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyExchange.BusinessLayer.Services
{
    public class RequestHandler<TResponse>
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly ILoggingService _loggingService;

        private IHttpResponseParser<TResponse> _parser { get; }

        public RequestHandler(IHttpResponseParser<TResponse> parser, ILoggingService loggingService)
        {
            _parser = parser;
            _loggingService = loggingService;
        }

        public async Task<TResponse> Handle(HttpRequestMessage requestMessage, CancellationToken cancellationToken = default)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

                await _loggingService.LogAsync(RequestType.ExternalRequest, requestMessage.RequestUri.ToString(), requestMessage.Method.Method, (int)response.StatusCode, DateTime.Now);

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