using CurrencyConverterApi_AZ.Models;

namespace CurrencyConverterApi_AZ.Repository
{
    public interface IRepository
    {
        Task<bool> Save(Currency currency);
    }
}