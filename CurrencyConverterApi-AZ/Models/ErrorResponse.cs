namespace CurrencyConverterApi_AZ.Models;

public class ErrorResponse
{
    public ErrorResponse(int code, string message, string detail)
    {
        this.code = code;
        this.message = message;
        this.detail = detail;
    }

    public int code { get; set; }
    public string message { get; set; }
    public string detail { get; set; }
}

