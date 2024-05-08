using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEFCoreDataLayer.Entities;

namespace SimpleEFCoreDataLayer.Configs;

public class CoachConfig : IEntityTypeConfiguration<Coach>
{
    public void Configure(EntityTypeBuilder<Coach> builder)
    {
        builder.ToTable("Coaches", "PRS");
        builder.HasComment("این جدول برای نگهداری اطلاعات مربیان است");

    }
}