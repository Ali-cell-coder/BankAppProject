using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.Configurations
{
    public class CreditTypeConfiguration : IEntityTypeConfiguration<CreditType>
    {
        public void Configure(EntityTypeBuilder<CreditType> builder)
        {
            builder.ToTable("CreditTypes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.MinAmount)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.MaxAmount)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.MinTerm)
                .IsRequired();

            builder.Property(x => x.MaxTerm)
                .IsRequired();

            builder.Property(x => x.BaseInterestRate)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(x => x.CreditTypeCategory)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasDiscriminator<string>("CreditTypeDiscriminator")
                .HasValue<CreditType>("Base")
                .HasValue<IndividualCreditType>("Individual")
                .HasValue<CorporateCreditType>("Corporate");
        }
    }
} 