using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.Configurations
{
    public class CorporateCreditTypeConfiguration : IEntityTypeConfiguration<CorporateCreditType>
    {
        public void Configure(EntityTypeBuilder<CorporateCreditType> builder)
        {
            builder.Property(x => x.MinAnnualRevenue)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.MinYearsInBusiness)
                .IsRequired();

            builder.Property(x => x.RequiresFinancialStatements)
                .IsRequired();

            builder.Property(x => x.BusinessType)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.RequiresGuarantee)
                .IsRequired();
        }
    }
} 