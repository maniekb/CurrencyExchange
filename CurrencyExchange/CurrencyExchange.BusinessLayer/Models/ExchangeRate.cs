namespace CurrencyExchange.BusinessLayer.Models
{
    public class ExchangeRate
    {
        public string Code { get; set; }
        public string Currency { get; set; }
        public decimal Rate { get; set; }

        public ExchangeRate()
        {
        }

        public ExchangeRate(string code, string currency, decimal rate)
        {
            Code = code;
            Currency = currency;
            Rate = rate;
        }
    }
}
