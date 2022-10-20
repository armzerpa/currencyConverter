using System.Text.Json.Serialization;

namespace CurrencyConverterApi_AZ.Models;

public class Currency
{
    public Currency(ExchangeCurrency exchange)
    {
        this.BaseCurrency = exchange.Base;
        this.Date = exchange.Date;
        this.Exchanges = exchange.Rates;
    }

    [JsonConstructor]
    public Currency() { }

    public string BaseCurrency { get; set; }
    public string Date { get; set; }
    public Dictionary<string, double> Exchanges { get; set; }
}
