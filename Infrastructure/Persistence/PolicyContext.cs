namespace Infrastructure.Persistence;

using Infrastructure.Persistence.Application;
using Infrastructure.Persistence.Car;
using Infrastructure.Persistence.Policy;
using Microsoft.EntityFrameworkCore;

public class PolicyContext : DbContext
{
    public DbSet<PolicyEntity> Policies { get; set; }
    public DbSet<CarEntity> Cars { get; set; }
    public DbSet<ApplicationEntity> Applications { get; set; }

    public PolicyContext(DbContextOptions<PolicyContext> options) : base(options) { }
}