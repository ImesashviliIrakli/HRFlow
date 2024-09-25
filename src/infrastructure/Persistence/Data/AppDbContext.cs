using Domain.Entities;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<DomainEvent>();

        modelBuilder.Entity<Employee>()
        .OwnsOne(e => e.Address, a =>
        {
            a.Property(ad => ad.Street).HasColumnName("Street").IsRequired();
            a.Property(ad => ad.City).HasColumnName("City").IsRequired();
            a.Property(ad => ad.State).HasColumnName("State").IsRequired();
            a.Property(ad => ad.ZipCode).HasColumnName("ZipCode").IsRequired();
        });

        modelBuilder.Entity<Employee>()
           .HasMany(e => e.LeaveRequests);

        modelBuilder.Entity<Employee>()
            .HasIndex(e => e.UserId)
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}
