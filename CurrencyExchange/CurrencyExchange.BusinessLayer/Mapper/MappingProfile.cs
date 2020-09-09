using AutoMapper;
using CurrencyExchange.BusinessLayer.DTO;
using CurrencyExchange.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange.BusinessLayer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ExchangeRate, ExchangeRateDTO>();
            CreateMap<ExchangeRateDTO, ExchangeRate>();
        }
    }
}
