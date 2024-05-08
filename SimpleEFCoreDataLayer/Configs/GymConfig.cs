using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEFCoreDataLayer.Entities;
using SimpleEFCoreDataLayer.ValueGenerator;

namespace SimpleEFCoreDataLayer.Configs;

public class GymConfig : IEntityTypeConfiguration<Gym>
{
    public void Configure(EntityTypeBuilder<Gym> builder)
    {
        builder.ToTable("Gyms", "PRS");
        builder.HasComment("این جدول برای نگهداری اطلاعات باشگاه ها است");


        //پیش فرض کلید اصلی اتوجنریت هستش و مقادیرش خودش ساخته میشود
        builder.HasKey(k => k.Id)//مشخص کردن کلید اصلی
            .HasName("ID"); //تغییرنام کلید اصلی

        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(200)
            .HasComment("نام باشگاه");

        builder.Property(g => g.RowVersion).IsRowVersion();

        //ShadowProperty
        builder.Property<DateTime>("CreateDate")
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()");

        builder.Property<DateTime>("ModifiedDate")
            .HasColumnType("datetime2")
            .ValueGeneratedOnUpdate()
            .HasValueGenerator<DateTimeValueGenerator>();

        //معرفی به DBContext
        //رابطه فقط سمت پرنت ایجاد می شود
        builder.HasMany(gym => gym.Sessions)
            .WithOne(session => session.Gym)
            .HasForeignKey(seession => seession.GymId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasMany(c => c.Coaches)
            .WithMany(c => c.Gyms)
            .UsingEntity<GymCoach>(e => //موجودیت واسط
                    e.HasOne(gc => gc.Coach).WithMany(nc => nc.GymCoaches).HasForeignKey(fgc => fgc.CoachId),
                g => g.HasOne(gc => gc.Gym).WithMany(nc => nc.GymCoaches).HasForeignKey(fgc => fgc.GymId),
                gymCoach => { gymCoach.HasKey(c => c.Id);
                    gymCoach.Property(p => p.DateofStart).HasDefaultValueSql("GETDATE()");
                }
            );

    }
}