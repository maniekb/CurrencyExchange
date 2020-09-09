using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.BusinessLayer.Services
{
    public interface IExchangeService : IService
    {
        Task<decimal?> CalculateExchange(decimal amount, string from, string to);
    }
}
