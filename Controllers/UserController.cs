using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly DatabaseContext _dbContext;

    public UserController(ILogger<UserController> logger, DatabaseContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet]
    public ActionResult<UserModel> Get()
    {
        return Ok(_dbContext.Users.ToList());
    }


    [HttpPost("addUser")]
    public ActionResult<UserModel> PostTModel([FromBody] UserModel model)
    {
        DateTime localDate = DateTime.Now;
        model.createdAt = localDate.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
        _dbContext.Users.Add(model);
        _dbContext.SaveChanges();
        return Ok(model);
    }


}