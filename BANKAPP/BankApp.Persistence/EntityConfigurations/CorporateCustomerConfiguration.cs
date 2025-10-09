using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.EntityConfigurations
{
    public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
    {
        public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
        {
            builder.Property(c => c.CompanyName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.TaxNumber).IsRequired().HasMaxLength(10);
            builder.Property(c => c.TaxOffice).IsRequired().HasMaxLength(50);
            builder.Property(c => c.CompanyType).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Sector).IsRequired().HasMaxLength(50);
            builder.Property(c => c.AnnualRevenue).IsRequired().HasPrecision(18, 2);
            builder.Property(c => c.EmployeeCount).IsRequired();
            builder.Property(c => c.AuthorizedPersonName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.AuthorizedPersonTitle).IsRequired().HasMaxLength(50);
            builder.HasIndex(c => c.TaxNumber).IsUnique();
        }
    }
} 