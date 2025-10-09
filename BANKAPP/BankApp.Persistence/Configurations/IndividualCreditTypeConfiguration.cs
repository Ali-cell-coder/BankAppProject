using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.Configurations
{
    public class IndividualCreditTypeConfiguration : IEntityTypeConfiguration<IndividualCreditType>
    {
        public void Configure(EntityTypeBuilder<IndividualCreditType> builder)
        {
            builder.Property(x => x.MaxMonthlyIncome)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.MinCreditScore)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(x => x.RequiresCollateral)
                .IsRequired();

            builder.Property(x => x.CollateralType)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
} 