using LanguageLearning.Core.Domain.UserProfiles.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LanguageLearning.Core.Domain.UserProfiles.Constants;
using LanguageLearning.Core.Domain.UserProfiles.Enums;
using LanguageLearning.Core.Domain.UserProfiles.ValueObjects;

namespace LanguageLearning.Infrastructure.Persistence.Configuration;
public sealed class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.Ignore(e => e.DomainEvents);
        // Table Name
        builder.ToTable("UserProfiles");

        // Primary Key
        builder.HasKey(up => up.Id);

        // Properties
        builder.Property(up => up.Id)
            .ValueGeneratedNever() // Id is provided during creation
            .HasColumnName("Id");


        //builder.OwnsOne<LastName>(nameof(LastName), q =>
        //{
        //    q.Property(w => w.Value)
        //    .IsRequired()
        //    .HasColumnName(nameof(LastName))
        //    .HasMaxLength(UserProfileConstant.LastNameMaxLength)
        //    .IsUnicode(false);

        //});

        //builder.OwnsOne<FirstName>(nameof(FirstName), q =>
        //{
        //    q.Property(w => w.Value)
        //    .IsRequired()
        //    .HasColumnName(nameof(FirstName))
        //    .HasMaxLength(UserProfileConstant.FirstNameMaxLength)
        //    .IsUnicode(false);

        //});
        //builder.OwnsOne<Age>(nameof(Age), q =>
        //{
        //    q.Property(w => w.Value)
        //    .IsRequired()
        //    .HasColumnName(nameof(Age));
        //});

        builder.ComplexProperty(w => w.Birthdate).IsRequired()
            .Property(q => q.Value)
            .HasColumnName("Birthdate");
            
        builder.ComplexProperty(w => w.FirstName).IsRequired()
            .Property(q => q.Value)
            .HasColumnName("FirstName")
            .IsUnicode(false)
            .HasMaxLength(UserProfileConstant.FirstNameMaxLength);
        builder.ComplexProperty(w => w.LastName).IsRequired()
            .Property(q=>q.Value)
            .HasColumnName("LastName")
            .IsUnicode(false)
            .HasMaxLength(UserProfileConstant.LastNameMaxLength);

        builder.Property(up => up.Gender)
            .IsRequired();

        //builder.HasOne(up => up.NativeLanguage)
        //    .WithMany()
        //    .HasForeignKey("NativeLanguageId")
        //    .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(up => up.CountryOfOrigin)
            .WithMany()
            .HasForeignKey("CountryOfOriginId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(up => up.CurrentCountry)
            .WithMany()
            .HasForeignKey("CurrentCountryId")
            .OnDelete(DeleteBehavior.Restrict);

        // Collections
        //builder.HasMany(up => up.UserHobbies)
        //    .WithOne()
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.HasMany(up => up.UserInterests)
        //    .WithOne()
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.HasMany(up => up.LanguageProficiencies)
        //    .WithOne()
        //    .HasForeignKey("UserProfileId")
        //    .OnDelete(DeleteBehavior.Cascade);

        builder.Property(q => q.RowVersion).IsRowVersion();
    }
}