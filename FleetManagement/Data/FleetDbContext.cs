using FleetManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FleetManagement.Data
{
    public class FleetDbContext : IdentityDbContext<ApplicationUser>
    {
        public FleetDbContext(DbContextOptions<FleetDbContext> options) : base(options)
        {
        }

        // DbSets for tables
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<CustomerDetail> CustomerDetails { get; set; }
        public DbSet<VehicleMaintenance> VehicleMaintenances { get; set; }
        public DbSet<FuelLog> FuelLogs { get; set; }
        public DbSet<DriverAssignment> DriverAssignments { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Permit> Permits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships

            // Trip
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Vehicle)
                .WithMany(v => v.Trips)
                .HasForeignKey(t => t.VehicleID);

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Driver)
                .WithMany(d => d.Trips)
                .HasForeignKey(t => t.DriverID);

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Customer)
                .WithMany(c => c.Trips)
                .HasForeignKey(t => t.CustomerID);

            // Vehicle
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleType)
                .WithMany(vt => vt.Vehicles)
                .HasForeignKey(v => v.VehicleTypeID);

            // DriverAssignment
            modelBuilder.Entity<DriverAssignment>()
                .HasOne(da => da.Driver)
                .WithMany(d => d.DriverAssignments)
                .HasForeignKey(da => da.DriverID);

            modelBuilder.Entity<DriverAssignment>()
                .HasOne(da => da.Vehicle)
                .WithMany(v => v.DriverAssignments)
                .HasForeignKey(da => da.VehicleID);

            // Document
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Driver)
                .WithMany(dr => dr.Documents)
                .HasForeignKey(d => d.EntityID)
                .OnDelete(DeleteBehavior.Restrict); // Optional: Prevent cascading delete

            // Invoice
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CustomerID);

            // VehicleMaintenance
            modelBuilder.Entity<VehicleMaintenance>()
                .HasOne(vm => vm.Vehicle)
                .WithMany(v => v.VehicleMaintenances)
                .HasForeignKey(vm => vm.VehicleID);

            // FuelLog
            modelBuilder.Entity<FuelLog>()
                .HasOne(fl => fl.Vehicle)
                .WithMany(v => v.FuelLogs)
                .HasForeignKey(fl => fl.VehicleID);

            // LoginLog
            modelBuilder.Entity<LoginLog>()
                .HasOne(ll => ll.User)
                .WithMany(u => u.LoginLogs)
                .HasForeignKey(ll => ll.UserID);
        }
    }
}
