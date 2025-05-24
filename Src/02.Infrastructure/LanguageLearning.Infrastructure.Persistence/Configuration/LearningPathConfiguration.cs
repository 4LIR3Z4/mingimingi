using LanguageLearning.Core.Domain.LearningJourneys.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguageLearning.Infrastructure.Persistence.Configuration;
public sealed class LearningPathConfiguration : IEntityTypeConfiguration<LearningPath>
{
    public void Configure(EntityTypeBuilder<LearningPath> builder)
    {
        builder.ToTable("LearningGoals");

        builder.HasKey(lg => lg.Id);

        builder.Property(lg => lg.CreatedDate)
            .IsRequired();

        builder.Property(lg => lg.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(lg => lg.TotalSessions)
            .IsRequired();

        builder.Property(lg => lg.RowVersion)
            .IsRowVersion();

        builder.Ignore(lg => lg.CompletedSessions);
        builder.Ignore(lg => lg.Sessions);
        builder.Ignore(lg => lg.IsCompleted);

        builder
            .HasMany<LearningSession>("_sessions")
            .WithOne()
            .HasForeignKey("LearningPathId")
            .OnDelete(DeleteBehavior.Cascade);

    }
}