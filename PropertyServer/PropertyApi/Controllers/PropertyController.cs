using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using PropertyApi.Models;
using PropertyService;

namespace PropertyApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PropertiesController : ControllerBase
{

    private readonly ILogger<PropertiesController> _logger;

    public PropertiesController(ILogger<PropertiesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProperties")]
    public async Task<string> Get()
    {
        try {
            var jsonResponse =  await PropertyData.GetJsonFromAzureBlob();
            return jsonResponse;
        }
        catch (Exception ex)
        {
            // Log Error for observability
            Console.WriteLine($"Error accessing blob: {ex.Message}");
            return "";
        }
    }
}
