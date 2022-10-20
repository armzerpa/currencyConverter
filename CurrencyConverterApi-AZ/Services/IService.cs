using System;
using CurrencyConverterApi_AZ.Models;

namespace CurrencyConverterApi_AZ.Services
{
    public interface IService
    {
        Task<Currency> GetById(string id);
        Task<Currency> GetList();
        Task<Currency> GetHistoric(int days);
        Task Create(Currency currency);
    }
}

