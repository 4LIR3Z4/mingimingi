using LanguageLearning.Core.Domain.LearningJourney.Entities;
using LanguageLearning.Core.Domain.UserProfiles.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguageLearning.Infrastructure.Persistence.Configuration;
public sealed class LanguageProficiencyConfiguration : IEntityTypeConfiguration<LanguageProficiency>
{
    public void Configure(EntityTypeBuilder<LanguageProficiency> builder)
    {
        builder.ToTable("LanguageProficiencies");

        builder.HasKey(lp => lp.Id);

        builder.HasOne(lp => lp.Language)
            .WithMany()
            .HasForeignKey("LanguageId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(lp => lp.ReadingProficiency);


        builder.Property(lp => lp.WritingProficiency);


        builder.Property(lp => lp.ListeningProficiency);

        builder.Property(lp => lp.SpeakingProficiency);

        builder.Property(lp=>lp.AddedDate);

        builder.Property(lp => lp.AdditionMethod);
        builder.Property(q => q.RowVersion).IsRowVersion();
    }
}