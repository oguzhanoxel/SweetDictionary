using Microsoft.EntityFrameworkCore;
using SweetDictionary.Domain.Entities;

namespace SweetDictionary.Persistence.Contexts;

public class EfCoreDbContext : DbContext
{
    public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options) : base(options)
    {
        
    }

    public DbSet<Post> Posts { get; set; }
}
