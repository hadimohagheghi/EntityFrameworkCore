using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEFCoreDataLayer.Entities;

namespace SimpleEFCoreDataLayer.Configs;

public class SessionConfig : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.ToTable("Sessions", "PRS");
        builder.HasComment("این جدول برای نگهداری اطلاعات جلسات و سانس های باشگاه ها است");

        builder.Property(p => p.Fee)
            .HasPrecision(14, 3) //whole : 14 digit .and 4 digits should be decimal
            ;

    }
}