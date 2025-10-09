using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.EntityConfigurations
{
    public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
    {
        public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
        {
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.IdentityNumber).IsRequired().HasMaxLength(11);
            builder.Property(c => c.DateOfBirth).IsRequired();
            builder.Property(c => c.Nationality).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Occupation).IsRequired().HasMaxLength(100);
            builder.Property(c => c.MonthlyIncome).IsRequired().HasPrecision(18, 2);
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Address).IsRequired().HasMaxLength(200);
            builder.HasIndex(c => c.IdentityNumber).IsUnique();
        }
    }
} 