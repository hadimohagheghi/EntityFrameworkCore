using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEFCoreDataLayer.Entities;

namespace SimpleEFCoreDataLayer.Configs;

public class CoachingCertificateConfig : IEntityTypeConfiguration<CoachingCertificate>
{
    public void Configure(EntityTypeBuilder<CoachingCertificate> builder)
    {
        builder.ToTable("CoachingCertificates", "PRS");
        builder.HasComment("این جدول برای نگهداری اطلاعات مدارک مربیگری است");

        builder.Property(p => p.Title)
            .HasMaxLength(200)
            .IsRequired()
            .HasComment("عنوان مدرک مربیگری");

        builder.Property(p => p.Description)
            // .HasMaxLength(200) => Max Length
            .HasMaxLength(6000)
            .IsRequired(false);

    }
}