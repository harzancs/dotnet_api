using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_api.Controllers;

public class UserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [StringLength(50)]
    public String? username { get; set; } = null!;
    public String? firstName { get; set; } = null!;
    public String? lastName { get; set; } = null!;
    public String? password { get; set; } = null!;
    public String? avatar { get; set; } = "";
    public UserType? role { get; set; } = 0;
    public StatusActivity? status { get; set;} = (StatusActivity?)1;
    public DateTime? createdAt { get; set; } = null!;
    public DateTime? updatedAt { get; set; } = null!;
    public DateTime? deleteAt { get; set; } = null!;
}