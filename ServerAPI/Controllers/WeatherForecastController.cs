﻿using Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace ServerAPI.Controllers;

[ApiController]
[Route("vejr")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly string[] Locations = new[]
    {
        "Paris", "Berlin", "London", "København", "Oslo"
    };

    [HttpGet]
    [Route("{n}")]
    public IEnumerable<WeatherForecast> Get(int n)
    {
        return Enumerable.Range(1, n).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            Location = Locations[Random.Shared.Next(Locations.Length)]            
        })
        .ToArray();
    }
}

