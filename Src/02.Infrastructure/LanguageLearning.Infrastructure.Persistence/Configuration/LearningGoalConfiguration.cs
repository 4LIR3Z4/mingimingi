using LanguageLearning.Core.Domain.UserProfiles.Constants;
using LanguageLearning.Core.Domain.UserProfiles.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LanguageLearning.Core.Domain.UserProfiles.Enums;

namespace LanguageLearning.Infrastructure.Persistence.Configuration;
public sealed class LearningGoalConfiguration : IEntityTypeConfiguration<LearningGoal>
{
    public void Configure(EntityTypeBuilder<LearningGoal> builder)
    {
        builder.ToTable("LearningGoals");

        builder.HasKey(lg => lg.Id);

        builder.Property(lg => lg.Skill)
            .HasColumnName("Skill")
            .HasConversion(
                v => v.ToString(),
                v => (SkillType)Enum.Parse(typeof(SkillType), v))
            .HasMaxLength(50);

        builder.Property(lg => lg.PracticePerDayMinutes)
            .HasColumnName("PracticePerDayMinutes");
        builder.Property(q => q.RowVersion).IsRowVersion();

    }
}