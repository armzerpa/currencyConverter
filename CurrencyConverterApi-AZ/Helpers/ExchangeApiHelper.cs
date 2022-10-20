using System;
using CurrencyConverterApi_AZ.Models;
using Newtonsoft.Json;

namespace CurrencyConverterApi_AZ.Helpers
{
    public class ExchangeApiHelper : IThirdPartyHelper
    {
        private const string BaseUrl = "https://api.apilayer.com/exchangerates_data";
        private const string apiKey = "RTbknsbyaIObwSushlMVhJ2mLSwTMLfp";
        private const string baseSymbol = "EUR";

        private readonly HttpClient _client;

        public ExchangeApiHelper()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("apikey", apiKey);
        }

        async public Task<Currency> GetExchangeById(string id)
        {
            HttpResponseMessage response = await _client.GetAsync(BaseUrl + "/latest?base=" + id);
            try
            {
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

        async public Task<Currency> GetExchangeHistoric(string date)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(BaseUrl + "/" + date + "?base" + baseSymbol);
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

        async public Task<Currency> GetExchangeList()
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

