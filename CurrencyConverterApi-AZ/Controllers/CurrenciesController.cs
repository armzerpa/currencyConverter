using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyConverterApi_AZ.Models;
using CurrencyConverterApi_AZ.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrenciesConverterApi_AZ.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CurrenciesController : ControllerBase
{
    private readonly ILogger<CurrenciesController> _logger;
    private readonly IService _service;

    public CurrenciesController(ILogger<CurrenciesController> logger, IService service)
    {
        _logger = logger;
        _service = service;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _service.GetList();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError("error en getList", ex.Message);
            return StatusCode(500, new ErrorResponse(500, "some error happen", ex.Message));
        }
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        try
        {
            var result = await _service.GetById(id);
            return Ok(result);
        } catch (Exception ex)
        {
            _logger.LogError("error en getByid", ex.Message);
            return StatusCode(500, new ErrorResponse(500, "some error happen", ex.Message));
        }
    }

    [Authorize]
    [HttpGet("historic/{days}")]
    public async Task<IActionResult> Get(int days)
    {
        try
        {
            var result = await _service.GetHistoric(days);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError("error en getHistoric", ex.Message);
            return StatusCode(500, new ErrorResponse(500, "some error happen", ex.Message));
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post(Currency currency)
    {
        var res = await _service.Create(currency);
        if (res)
        {
            return StatusCode(201, currency);
        } else
        {
            return StatusCode(500, "internal server");
        }
    }
}


