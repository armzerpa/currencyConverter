using System;
using CurrencyConverterApi_AZ.Models;
using CurrencyConverterApi_AZ.Services;

namespace service_tests.Mocks
{
    public class FakeService : IService
    {
        public FakeService()
        {
        }

        public async Task<bool> Create(Currency currency)
        {
            await Task.Delay(5);
            return true;
        }

        public async Task<Currency> GetById(string id)
        {
            await Task.Delay(5);
            return new Currency();
        }

        public async Task<Currency> GetHistoric(int days)
        {
            await Task.Delay(5);
            return new Currency();
        }

        public async Task<Currency> GetList()
        {
            await Task.Delay(5);
            return new Currency();
        }
    }
}

