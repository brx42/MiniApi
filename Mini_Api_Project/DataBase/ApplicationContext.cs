using Microsoft.EntityFrameworkCore;
using ASP.NET_CORE_TRY.Models;

namespace ASP.NET_CORE_TRY.DataBase;

public sealed class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }
}
