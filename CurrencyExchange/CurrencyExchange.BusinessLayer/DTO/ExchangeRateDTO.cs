using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange.BusinessLayer.DTO
{
    public class ExchangeRateDTO
    {
        public string Code { get; set; }
        public string Currency { get; set; }
        public decimal Rate { get; set; }
    }
}
