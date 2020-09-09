using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyExchange.BusinessLayer.Services
{
    public interface IHttpResponseParser<TResult>
    {
        Task<TResult> ParseAsync(HttpResponseMessage response);
    }
}