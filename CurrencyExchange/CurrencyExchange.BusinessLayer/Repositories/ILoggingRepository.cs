using CurrencyExchange.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.BusinessLayer.Repositories
{
    public interface ILoggingRepository : IRepository
    {
        Task SaveLogAsync(RequestLog log);
    }
}
