using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LanguageLearning.Core.Domain.SharedKernel.Entities;
using LanguageLearning.Core.Domain.SharedKernel.Constants;

namespace LanguageLearning.Infrastructure.Persistence.Configuration;
public sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        // Table Name
        builder.ToTable("Countries");

        // Primary Key
        builder.HasKey(c => c.Id);

        // Properties
        builder.Property(c => c.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(CountryConstants.NameMaxLength)
            .HasColumnName("Name")
            .HasComment("The full name of the country.");

        builder.Property(c => c.IsoCode)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(CountryConstants.IsoCodeLength)
            .IsFixedLength() // ISO codes are fixed-length strings
            .HasColumnName("IsoCode")
            .HasComment("The two-letter ISO code of the country.");

        // Indexes
        builder.HasIndex(c => c.IsoCode).IsUnique(); // Ensure ISO codes are unique
        builder.Property(q => q.RowVersion).IsRowVersion();
    }
}
