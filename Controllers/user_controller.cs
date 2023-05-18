using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Cryptography;

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



    [HttpGet] // GET
    public ActionResult<UserModel> Get()
    {
        return Ok(_dbContext.Users.ToList());
    }


    [HttpPost("addUser")]  // /addUser
    public ActionResult<UserModel> PostTModel([FromBody] UserModel model)
    {
        DateTime localDate = DateTime.Now;

        model.createdAt = localDate;
        model.password = CrypMd5.CreateMD5(model.password);
        _dbContext.Users.Add(model);
        _dbContext.SaveChanges();
        return Ok(model);
    }


    [HttpPut("updateUser/{id}")]  //  /updateUser/:id
    public ActionResult<dynamic> UpdateUser(int id, [FromBody] UserModel item)
    {
        var _data = _dbContext.Users.Where(t => t.id == id).DefaultIfEmpty().First();
        if (_data is null)
        {
            return new OkObjectResult(new { success = false, message = "Insert Fail !", result = NotFound() });
        }
        else
        {
            DateTime localDate = DateTime.Now;

            _data.firstName = item.firstName;
            _data.lastName = item.lastName;
            _data.password = CrypMd5.CreateMD5(item.password);
            _data.updatedAt = localDate;

            _dbContext.SaveChanges();
            var _data_tmp = _dbContext.Users.Where(t => t.id == id).DefaultIfEmpty().First();

            return new OkObjectResult(new { success = true, message = "Insert Successs !", result = _data_tmp });
        }

    }

    [HttpDelete("deleteUser/{id}")]  //  /deleteUser/:id
    public ActionResult<dynamic> DeleteUser(int id)
    {
        var _data = _dbContext.Users.Where(t => t.id == id).DefaultIfEmpty().First();
        if (_data is null)
        {
            return new OkObjectResult(new { success = false, message = "Insert Fail !", result = NotFound() });
        }
        else
        {
            DateTime localDate = DateTime.Now;

            _data.deleteAt = localDate;
            _data.status = (StatusActivity?)2;
            _dbContext.SaveChanges();
            return new OkObjectResult(new { success = true, message = "Successs !" });
        }



    }

}