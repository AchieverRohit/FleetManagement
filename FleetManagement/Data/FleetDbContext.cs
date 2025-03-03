using FleetManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Data
{
    public class FleetDbContext : IdentityDbContext<ApplicationUser>
    {
        public FleetDbContext(DbContextOptions<FleetDbContext> options) : base(options) { }

        // DbSets
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<VehicleInfo> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<DriverInfo> Drivers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripLeg> TripLegs { get; set; }
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DbSet<VehicleMaintenance> VehicleMaintenances { get; set; }
        public DbSet<FuelLog> FuelLogs { get; set; }
        public DbSet<DriverVehicleAssignment> DriverAssignments { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Permit> Permits { get; set; }
        public DbSet<FleetAccount> FleetAccounts { get; set; }
        public DbSet<FleetBranch> FleetBranches { get; set; }
        public DbSet<UserFleetBranch> UserFleetBranches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // FleetAccount & FleetBranch
            modelBuilder.Entity<FleetBranch>()
                .HasOne(fb => fb.FleetAccount)
                .WithMany(fa => fa.Branches)
                .HasForeignKey(fb => fb.FleetAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            // ApplicationUser (One-to-Many with FleetAccount)
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.FleetAccount)
                .WithMany()
                .HasForeignKey(u => u.FleetAccountId)
                .OnDelete(DeleteBehavior.SetNull);

            // Many-to-Many: UserFleetBranch
            modelBuilder.Entity<UserFleetBranch>()
                .HasKey(ufb => new { ufb.UserId, ufb.FleetBranchId });

            modelBuilder.Entity<UserFleetBranch>()
                .HasOne(ufb => ufb.User)
                .WithMany(u => u.UserFleetBranches)
                .HasForeignKey(ufb => ufb.UserId);

            modelBuilder.Entity<UserFleetBranch>()
                .HasOne(ufb => ufb.FleetBranch)
                .WithMany()
                .HasForeignKey(ufb => ufb.FleetBranchId);

            // Trip & TripLeg
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.FleetBranch)
                .WithMany()
                .HasForeignKey(t => t.FleetBranchId);

            modelBuilder.Entity<TripLeg>()
                .HasOne(tl => tl.Trip)
                .WithMany(t => t.TripLegs)
                .HasForeignKey(tl => tl.TripId);

            // Vehicle & VehicleType
            modelBuilder.Entity<VehicleInfo>()
                .HasOne(v => v.VehicleType)
                .WithMany(vt => vt.Vehicles)
                .HasForeignKey(v => v.VehicleTypeId);

            // Driver & Vehicle Assignment
            modelBuilder.Entity<DriverVehicleAssignment>()
                .HasOne(da => da.Driver)
                .WithMany(d => d.VehicleAssignments)
                .HasForeignKey(da => da.DriverInfoId);

            modelBuilder.Entity<DriverVehicleAssignment>()
                .HasOne(da => da.Vehicle)
                .WithMany(v => v.VehicleAssignments)
                .HasForeignKey(da => da.VehicleInfoId);

            // Trip Relationships
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Vehicle)
                .WithMany(v => v.Trips)
                .HasForeignKey(t => t.VehicleInfoId);

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Driver)
                .WithMany(d => d.Trips)
                .HasForeignKey(t => t.DriverInfoId);

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Customer)
                .WithMany(c => c.Trips)
                .HasForeignKey(t => t.CustomerInfoId);

            // Invoice & Customer
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CustomerInfoId);

            // FleetAccount & Customer
            modelBuilder.Entity<CustomerInfo>()
                .HasOne(c => c.FleetAccount)
                .WithMany()
                .HasForeignKey(c => c.FleetAccountId);
        }
    }
}
