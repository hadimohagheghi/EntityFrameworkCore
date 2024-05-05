using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEFCoreDataLayer.Entities;
using SimpleEFCoreDataLayer.ValueGenerator;

namespace SimpleEFCoreDataLayer.Configs
{
    public class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members", "PRS");
            builder.HasComment("این جدول برای نگهداری اطلاعات ورزشکاران است");

            //پیش فرض کلید اصلی اتوجنریت هستش و مقادیرش خودش ساخته میشود
            builder.HasKey(k => k.Id)//مشخص کردن کلید اصلی
                .HasName("ID"); //تغییرنام کلید اصلی

            //مقداردهی کلید اصلی از حالت خودکار خارج شود
            //builder.Property(p => p.Id).ValueGeneratedNever();

            builder.HasAlternateKey(AK => AK.NationalCode);
            //کلید ترکیبی
            //چند تا فیلد به عنوان کلید اصلی
           // builder.HasKey(k => new { k.Id, k.NationalCode });



            builder.Property(p => p.Name)
                .HasColumnName("FirstName")
                .HasColumnType("nvarchar(200)")
                .IsRequired();


            builder.Property(p => p.Family)
                .HasColumnName("LastName")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.FatherName)
                //.HasColumnName("FatherName")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.NationalCode)
                //.HasColumnName("NationalCode")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.RegisterDate)
                // .HasDefaultValue(DateTime.Now); //مقدادهی اولیه سمت برنامه
                // .HasDefaultValueSql("2001-02-02")
                .HasDefaultValueSql("GETDATE()");


            builder.Property(p => p.FullName).HasComputedColumnSql("[FirstName] + ' ' + [LastName]",true);

            // یک پراپرتی ترکینگ کد وجود دارد که هر زمانی می خوام که بخوام این انتیتی رو بفرستم سمت دیتابیس باید مقدار دهی کنم
            //ولی اگر دیدی که ترکینگ کد مقدار داره دیگه این مقدار کد جنریتور رو صدا نزن
            builder.Property(p => p.TrackingCode)
                .ValueGeneratedOnAdd()  //چه زمانی مقدار ساخته شود؟
                .HasValueGenerator<TrackingCodeValueGenerator>()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save); //اگر داخل برنامه مقدار داخلش قرار دادم از اتوجنریت استفاده نکن
        }
    }


    public class CoachConfig : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.ToTable("Coaches", "PRS");
            builder.HasComment("این جدول برای نگهداری اطلاعات مربیان است");

        }
    }


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

}
