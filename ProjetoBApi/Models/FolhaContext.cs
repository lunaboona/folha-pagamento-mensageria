using Microsoft.EntityFrameworkCore;

namespace ProjetoBApi.Models;

public class FolhaContext : DbContext
{
    public FolhaContext(DbContextOptions<FolhaContext> options)
        : base(options)
    {
    }

    public DbSet<FolhaCalculada> Folhas { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<FolhaCalculada>().HasKey(m => m.Id);
        base.OnModelCreating(builder);
    }
}