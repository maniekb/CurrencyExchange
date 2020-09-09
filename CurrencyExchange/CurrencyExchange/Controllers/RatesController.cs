using CurrencyExchange.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CurrencyExchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly IRatesService _ratesService;
        private readonly IExchangeService _exchangeService;
        public RatesController(IRatesService ratesService, IExchangeService exchangeService)
        {
            _ratesService = ratesService;
            _exchangeService = exchangeService;
        }

        [HttpGet]
        [Route("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            var rate = await _ratesService.GetRateAsync(code);
            if (rate == null)
            {
                return NotFound();
            }

            return Ok(rate);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rates = await _ratesService.GetRatesAsync();
            if (rates == null)
            {
                return NotFound();
            }

            return Ok(rates);
        }
    }
}