
using dotnet_api.Controllers;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<UserModel> Users { get; set; } = null!;
    public DbSet<LangModel> Langs { get; set; } = null!;
}