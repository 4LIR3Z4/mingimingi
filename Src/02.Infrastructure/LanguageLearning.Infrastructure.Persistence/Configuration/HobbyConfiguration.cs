using LanguageLearning.Core.Domain.UserProfiles.Constants;
using LanguageLearning.Core.Domain.UserProfiles.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LanguageLearning.Infrastructure.Persistence.Configuration;
public sealed class HobbyConfiguration : IEntityTypeConfiguration<Hobby>
{
    public void Configure(EntityTypeBuilder<Hobby> builder)
    {
        // Table Name
        builder.ToTable("Hobbies");

        // Primary Key
        builder.HasKey(h => h.Id);

        // Properties
        builder.Property(h => h.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(HobbyConstants.NameMaxLength)
            .HasColumnName("Name")
            .HasComment("The name of the hobby.");
        builder.Property(q => q.RowVersion).IsRowVersion();
    }
}