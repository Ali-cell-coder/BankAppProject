using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Persistence.Contexts
{
    public class BankAppDbContext : DbContext
    {
        public BankAppDbContext(DbContextOptions<BankAppDbContext> options) : base(options)
        {
        }

        public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
        public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
        public DbSet<CreditType> CreditTypes { get; set; }
        public DbSet<CreditApplication> CreditApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TPT yapılandırması
            modelBuilder.Entity<IndividualCustomer>()
                .ToTable("IndividualCustomers");
            
            modelBuilder.Entity<CorporateCustomer>()
                .ToTable("CorporateCustomers");

            // CreditType configurations
            modelBuilder.Entity<CreditType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.MinAmount).HasPrecision(18, 2);
                entity.Property(e => e.MaxAmount).HasPrecision(18, 2);
                entity.Property(e => e.InterestRate).HasPrecision(5, 2);
            });

            // CreditApplication configurations
            modelBuilder.Entity<CreditApplication>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RequestedAmount).HasPrecision(18, 2);
                entity.Property(e => e.Purpose).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Status).IsRequired().HasMaxLength(20);
                entity.Property(e => e.RejectionReason).HasMaxLength(500);

                // Relationships
                // entity.HasOne(e => e.Customer)
                //     .WithMany()
                //     .HasForeignKey(e => e.CustomerId)
                //     .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.CreditType)
                    .WithMany()
                    .HasForeignKey(e => e.CreditTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
