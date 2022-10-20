using System;
using CurrencyConverterApi_AZ.Models;

namespace CurrencyConverterApi_AZ.Helpers
{
    public interface IThirdPartyHelper
    {
        Task<Currency> GetExchangeById(string id);
        Task<Currency> GetExchangeList();
        Task<Currency> GetExchangeHistoric(string date);
    }
}

