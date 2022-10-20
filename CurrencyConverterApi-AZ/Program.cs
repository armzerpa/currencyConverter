using CurrencyConverterApi_AZ.Helpers;
using CurrencyConverterApi_AZ.Repository;
using CurrencyConverterApi_AZ.Services;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
                ("BasicAuthentication", null);
builder.Services.AddAuthorization();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddScoped<IService, CurrencyService>();
builder.Services.AddScoped<IThirdPartyHelper, ExchangeApiHelper>();
builder.Services.AddTransient<IRepository, RepositoryMock>();
builder.Logging.AddJsonConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();

