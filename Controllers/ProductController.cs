using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProduct")]
    public IEnumerable<String> Get()
    {
        return Enumerable.Range(1, 5).Select(index => $"index")
        .ToArray();
    }
    [HttpGet("dummy1")]
    public IEnumerable<String> GetDummy1()
    {
        return Enumerable.Range(1, 5).Select(index => $"index : {index}")
        .ToArray();
    }

    [HttpGet("dummy2")]
    public IEnumerable<String> GetDummy2()
    {
        return Enumerable.Range(6, 5).Select(index => $"index : {index}")
        .ToArray();
    }
}
