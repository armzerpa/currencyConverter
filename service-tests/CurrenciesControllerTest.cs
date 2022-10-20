using System;
using CurrenciesConverterApi_AZ.Controllers;
using CurrencyConverterApi_AZ.Models;
using CurrencyConverterApi_AZ.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using service_tests.Mocks;

namespace service_tests
{
    public class CurrenciesControllerTest
    {
        private readonly CurrenciesController _controller;
        private readonly IService _service;

        public CurrenciesControllerTest()
        {
            _service = new FakeService();
            _controller = new CurrenciesController(null, _service);
        }

        [Fact]
        public void Get_WhenGet_ReturnsOkResult()
        {
            var result = _controller.Get();
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void Get_WhenGetById_ReturnsOkResult()
        {
            var result = _controller.Get("SOMEID");
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void Post_WhenPost_ReturnsOkResult()
        {
            var result = _controller.Post(new Currency());
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotNull(result.Result);
        }
    }
}

