using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LanguageLearning.Core.Domain.Languages.Constants;
using LanguageLearning.Core.Domain.Languages.Entities;

namespace LanguageLearning.Infrastructure.Persistence.Configuration;
public sealed class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("Languages");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Name)
            .IsRequired()
            .HasMaxLength(LanguageConstants.NameMaxLength)
            .IsUnicode(false)
            .HasColumnName("Name");

        builder.Property(l => l.Code)
            .IsRequired()
            .HasMaxLength(LanguageConstants.CodeLength)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("Code");


        builder.HasIndex(l => l.Code).IsUnique();
        builder.Property(q => q.RowVersion).IsRowVersion();
    }
}