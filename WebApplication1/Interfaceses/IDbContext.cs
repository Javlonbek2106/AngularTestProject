using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Interfaceses
{
    public interface IDbContext
    {
          DbSet<Company> Companys { get; }

          DbSet<Role> Roles { get; }

          DbSet<User> Users { get; }
          int SaveChanges();
    }
}
