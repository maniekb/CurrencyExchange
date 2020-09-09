using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CurrencyExchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeService _exchangeService;
        public ExchangeController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int amount, string from, string to)
        {
            var exchange = await _exchangeService.CalculateExchange(amount, from, to);

            return Ok(exchange);
        }
    }
}
