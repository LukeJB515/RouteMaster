using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RouteMaster.DomainLayer.Entities;
using Route = RouteMaster.DomainLayer.Entities.Route;

namespace RouteMaster.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<IndividualVehicleEquipment> IndividualVehicleEquipments { get; set; }
    public DbSet<MaterialsToLoad> MaterialsToLoad { get; set; }

    public DbSet<Route> Routes { get; set; }
    public DbSet<RouteAssignment> RouteAssignments { get; set; }
    
    public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }

    public DbSet<RouteAssignmentMaterial> RouteAssignmentMaterials { get; set; }

    public DbSet<Convoy> Convoys { get; set; }
    public DbSet<ConvoyVehicle> ConvoyVehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IndividualVehicleEquipment>()
            .HasOne(e => e.Vehicle)
            .WithMany(v => v.IndividualVehicleEquipments)
            .HasForeignKey(e => e.VehicleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<RouteAssignment>()
            .HasOne(ra => ra.Vehicle)
            .WithMany()
            .HasForeignKey(ra => ra.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<RouteAssignment>()
            .HasOne(ra => ra.Route)
            .WithMany()
            .HasForeignKey(ra => ra.RouteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<MaintenanceRecord>()
            .HasOne(m => m.Vehicle)
            .WithMany(v => v.MaintenanceRecords)
            .HasForeignKey(m => m.VehicleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<RouteAssignmentMaterial>()
            .HasOne(ram => ram.RouteAssignment)
            .WithMany(ra => ra.RouteAssignmentMaterials)
            .HasForeignKey(ram => ram.RouteAssignmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<RouteAssignmentMaterial>()
            .HasOne(ram => ram.MaterialsToLoad)
            .WithMany(m => m.RouteAssignmentMaterials)
            .HasForeignKey(ram => ram.MaterialsToLoadId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<RouteAssignment>()
            .HasOne(ra => ra.Convoy)
            .WithMany()
            .HasForeignKey(ra => ra.ConvoyId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<Convoy>(convoy =>
        {
            convoy.HasKey(c => c.ConvoyId);

            convoy.HasMany<ConvoyVehicle>()
            .WithOne(cv => cv.Convoy)
            .HasForeignKey(cv => cv.ConvoyId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<ConvoyVehicle>(cv =>
        {
            cv.HasKey(x => new { x.ConvoyId, x.VehicleId });

            cv.HasOne(x => x.Vehicle)
            .WithMany()
            .HasForeignKey(x => x.VehicleId);
        });

        //builder.Entity<ConvoyVehicle>()
        //    .HasOne(cv => cv.Vehicle)
        //    .WithMany()
        //    .HasForeignKey(cv => cv.VehicleId)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}
