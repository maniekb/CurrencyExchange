using CurrencyExchange.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly IRatesService _ratesService;
        public CurrenciesController(IRatesService ratesService)
        {
            _ratesService = ratesService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var currencies = _ratesService.GetAvailableCurrencies();
            return Ok(currencies);
        }
    }
}