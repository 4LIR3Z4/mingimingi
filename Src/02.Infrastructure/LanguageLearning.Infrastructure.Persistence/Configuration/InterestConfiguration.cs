using LanguageLearning.Core.Domain.UserProfiles.Constants;
using LanguageLearning.Core.Domain.UserProfiles.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LanguageLearning.Infrastructure.Persistence.Configuration;
public sealed class InterestConfiguration : IEntityTypeConfiguration<Interest>
{
    public void Configure(EntityTypeBuilder<Interest> builder)
    {
        // Table Name
        builder.ToTable("Interests");

        // Primary Key
        builder.HasKey(i => i.Id);

        // Properties
        builder.Property(i => i.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(InterestConstants.NameMaxLength)
            .HasColumnName("Name")
            .HasComment("The name of the interest.");
        builder.Property(q => q.RowVersion).IsRowVersion();
    }
}