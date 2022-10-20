using CurrencyConverterApi_AZ.Models;

namespace CurrencyConverterApi_AZ.Services
{
    public interface IRepository
    {
        Task<bool> Save(Currency currency);
    }
}