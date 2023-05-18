
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticateController : ControllerBase
{
    private IConfiguration _config;
    private readonly ILogger<UserController> _logger;
    private readonly DatabaseContext _dbContext;
    public AuthenticateController(IConfiguration config, ILogger<UserController> logger, DatabaseContext dbContext)
    {
        _config = config;
        _logger = logger;
        _dbContext = dbContext;
    }

    private string GenerateJSONWebToken(LoginModel userInfo)
    {
        DateTime localDateAdd = DateTime.Now.AddMinutes(60).AddHours(7);
        var baseUri = $"{Request.Scheme}://{Request.Host}:{Request.Host.Port ?? 80}";
        // =====
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@2410"));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var tokenOptions = new JwtSecurityToken(
            issuer: userInfo.username,
            audience: baseUri,
            claims: new List<Claim>(),
            expires: localDateAdd,
            signingCredentials: signinCredentials
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return tokenString;
    }

    [HttpPost("verifyToken")]
    public ActionResult<dynamic> verifyToken([FromBody] TokenModel token)
    {
        if (token == null)
            return NotFound();

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("superSecretKey@2410");
        try
        {
            tokenHandler.ValidateToken(token.token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            DateTime localDate = DateTime.Now;
            return new OkObjectResult(new { token = token.token, validate = jwtToken.ValidTo > localDate ? true : false, endToken = jwtToken.ValidTo, nowTime = localDate });
            // return Convert.ToDateTime(jwtToken.ValidTo) < getDateTime.dateTime() ? true : false;
        }
        catch
        {
            // return null if validation fails
            return Unauthorized();
        }
    }

    [HttpPost] // POST
    public ActionResult<dynamic> login([FromBody] LoginModel item)
    {
        var _data = _dbContext.Users.Where(t => t.username == item.username && t.password == CrypMd5.CreateMD5(item.password)).DefaultIfEmpty().First();
        if (_data is null)
        {
            return new OkObjectResult(new { success = false, message = "Fail !", token = "" });
        }
        else
        {
            var tokenString = GenerateJSONWebToken(item);
            return new OkObjectResult(new { success = true, message = "Success !", token = tokenString });
        }

    }
}