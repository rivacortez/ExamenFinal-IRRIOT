

using API.Inventory.Domain.Model.Aggregates;
using API.Inventory.Domain.Model.ValueObjects;
using API.Observability.Domain.Model.Aggregates;
using API.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace API.Shared.Infrastructure.Persistance.EFC.Configuration;


public class AppDbContext : DbContext
{
    public DbSet<ThingState> ThingStates { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
       
        builder.AddCreatedUpdatedInterceptor();
    }

    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        base.OnModelCreating(builder);
            
        
        builder.Entity<Thing>().ToTable("Things");
        builder.Entity<Thing>().HasKey(c => c.Id);
        builder.Entity<Thing>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Thing>().Property(c=> c.Model).IsRequired();
        builder.Entity<Thing>().OwnsOne<SerialNumber>(serial => serial.SerialNumberValObj, ex =>
        {
            ex.WithOwner().HasForeignKey("Id");
            ex.Property(serial => serial.Value).HasColumnName("SerialNumber");
        });
        builder.Entity<Thing>().Property(c=> c.OperationModeEnum).IsRequired();
        builder.Entity<Thing>().Property(c=> c.MaximumTemperatureThreshold).IsRequired();
        builder.Entity<Thing>().Property(c=> c.MinimumTemperatureThreshold).IsRequired();
        
        
        
        builder.Entity<ThingState>().ToTable("Thing_states");
        builder.Entity<ThingState>().HasKey(c => c.Id);
        builder.Entity<ThingState>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ThingState>().OwnsOne<SerialNumber>(serial => serial.ThingSerialNumber, ex =>
        {
            ex.WithOwner().HasForeignKey("Id");
            ex.Property(serial => serial.Value).HasColumnName("SerialNumber");
        });
        builder.Entity<ThingState>().Property(c => c.CurrentOperationMode).IsRequired();
        builder.Entity<ThingState>().Property(c => c.CurrentTemperature).IsRequired();
        builder.Entity<ThingState>().Property(c => c.CurrentHumidity).IsRequired();
        builder.Entity<ThingState>().Property(c => c.CollectedAt).IsRequired();
        
        
        
   
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}