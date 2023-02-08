using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_api.Controllers;

public class UserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [StringLength(50)]
    public String username { get; set; }
    public String firstName { get; set; }
    public String lastName { get; set; }
    public String password { get; set; }
    public String createdAt { get; set; }
}