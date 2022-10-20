using System;
using System.Net;
using CurrencyConverterApi_AZ.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CurrencyConverterApi_AZ.Services
{
    public class CurrencyService : IService
    {
        private const string BaseUrl = "https://api.apilayer.com/exchangerates_data";
        private const string apiKey = "RTbknsbyaIObwSushlMVhJ2mLSwTMLfp";
        private const string baseSymbol = "EUR";
        private readonly HttpClient _client;

        private readonly IRepository _repo;

        public CurrencyService(IRepository repo)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("apikey", apiKey);

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
            HttpResponseMessage response = await _client.GetAsync(BaseUrl + "/latest?base=" + id);
            try
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var exchangeCurrency = JsonConvert.DeserializeObject<ExchangeCurrency>(responseBody);

                return new Currency(exchangeCurrency);
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<Currency> IService.GetHistoric(int days)
        {
            try
            {
                var date = DateTime.Now.AddDays(-days);
                var dateStr = date.ToString("yyyy-MM-dd");
                HttpResponseMessage response = await _client.GetAsync(BaseUrl + "/" + dateStr + "?base" + baseSymbol);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var exchangeCurrency = JsonConvert.DeserializeObject<ExchangeCurrency>(responseBody);

                return new Currency(exchangeCurrency);
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
                HttpResponseMessage response = await _client.GetAsync(BaseUrl + "/latest?base=" + baseSymbol);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var exchangeCurrency = JsonConvert.DeserializeObject<ExchangeCurrency>(responseBody);

                return new Currency(exchangeCurrency);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

