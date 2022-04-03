using EntityFrameworkCore.DataTokenization;
using Microsoft.EntityFrameworkCore;

namespace ORMTokenizationExample;

public class DatabaseContext : DbContext
{
    private readonly TokenizationProvider _tokenizationProvider;

    public DbSet<User> Users { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options, TokenizationProvider tokenizationProvider)
        : base(options)
    {
        _tokenizationProvider = tokenizationProvider;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseTokenization(_tokenizationProvider);

        base.OnModelCreating(modelBuilder);
    }
}
