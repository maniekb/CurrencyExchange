using CurrencyExchange.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange.BusinessLayer.EF
{
    public class CurrencyExchangeContext :DbContext
    {
        public DbSet<RequestLog> Logs { get; set; }

        public CurrencyExchangeContext(DbContextOptions<CurrencyExchangeContext> options)
         : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
