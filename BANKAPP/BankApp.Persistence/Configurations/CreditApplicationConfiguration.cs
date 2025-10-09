using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.Configurations
{
    public class CreditApplicationConfiguration : IEntityTypeConfiguration<CreditApplication>
    {
        public void Configure(EntityTypeBuilder<CreditApplication> builder)
        {
            builder.ToTable("CreditApplications");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.RequestedAmount)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.Term)
                .IsRequired();

            builder.Property(x => x.Purpose)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.RejectionReason)
                .HasMaxLength(500);

            builder.HasOne(x => x.CreditType)
                .WithMany()
                .HasForeignKey(x => x.CreditTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 