using System;
using CurrencyConverterApi_AZ.Models;

namespace CurrencyConverterApi_AZ.Repository
{
    public class RepositoryMock : IRepository
    {
        public RepositoryMock()
        {
        }

        public async Task<bool> Save(Currency currency)
        {
            await Task.Delay(10);
            return true;
        }
    }
}

