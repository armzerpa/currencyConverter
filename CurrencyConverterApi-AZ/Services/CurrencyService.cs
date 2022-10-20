using System;
using System.Net;
using CurrencyConverterApi_AZ.Helpers;
using CurrencyConverterApi_AZ.Models;
using CurrencyConverterApi_AZ.Repository;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CurrencyConverterApi_AZ.Services
{
    public class CurrencyService : IService
    { 
        private readonly IThirdPartyHelper _helper;
        private readonly IRepository _repo;

        public CurrencyService(IThirdPartyHelper helper, IRepository repo)
        {
            _helper = helper;
            _repo = repo;
        }

        async Task<bool> IService.Create(Currency currency)
        {
            try
            {
                bool result = _repo.Save(currency).Result;
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<Currency> IService.GetById(string id)
        {
            try
            {
                var result = await _helper.GetExchangeById(id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<Currency> IService.GetHistoric(int days)
        {
            var date = DateTime.Now.AddDays(-days);
            var dateStr = date.ToString("yyyy-MM-dd");

            try
            {
                var result = await _helper.GetExchangeHistoric(dateStr);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<Currency> IService.GetList()
        {
            try
            {
                var result = await _helper.GetExchangeList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

