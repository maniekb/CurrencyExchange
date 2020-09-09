using CurrencyExchange.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.BusinessLayer.EF
{
    public class CurrencyExchangeContext :DbContext
    {
        public DbSet<RequestLog> RequestLogs { get; set; }

        public CurrencyExchangeContext(DbContextOptions<CurrencyExchangeContext> options)
         : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
