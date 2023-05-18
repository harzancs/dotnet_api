using System.ComponentModel.DataAnnotations;

public class LoginModel
{
    [Required]
    public string username { get; set; }
    [Required]
    public string password { get; set; }
}
public class TokenModel
{
    [Required]
    public string token { get; set; }
}