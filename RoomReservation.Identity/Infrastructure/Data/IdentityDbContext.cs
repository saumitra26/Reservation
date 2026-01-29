using Microsoft.EntityFrameworkCore;
using RoomReservation.Identity.Domain.Entities;

namespace RoomReservation.Identity.Infrastructure.Data;

public class IdentityDbContext:DbContext
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext>options):base(options)
    {
        
    }
  public DbSet<AuthUser> Users => Set<AuthUser>();
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
      modelBuilder.HasDefaultSchema("auth");
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<AuthUser>().HasIndex(u => u.Email).IsUnique();
  }
}