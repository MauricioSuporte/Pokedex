using Business.Entities;
using Infra.Mappings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infra;

public class EFDbContext : DbContext
{
    private readonly IHostingEnvironment _hostingEnvironment;

    public DbSet<Pokemon> Pokemons { get; set; }

    public EFDbContext(DbContextOptions<EFDbContext> options, IHostingEnvironment environment) : base(options)
    {
        _hostingEnvironment = environment;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder buider)
    {
        var logConfig = new[]
        {
            RelationalEventId.ConnectionOpened,
            RelationalEventId.ConnectionClosed,
            RelationalEventId.TransactionStarted,
            RelationalEventId.TransactionCommitted,
            RelationalEventId.TransactionRolledBack,
            RelationalEventId.CommandExecuted,
        };

        buider
            .LogTo(Console.WriteLine, logConfig)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);

        if (!_hostingEnvironment.IsProduction())
            buider.EnableDetailedErrors().EnableSensitiveDataLogging();

        base.OnConfiguring(buider);
    }
}
