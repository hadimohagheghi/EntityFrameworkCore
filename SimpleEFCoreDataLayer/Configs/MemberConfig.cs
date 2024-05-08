using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
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
                //.IsConcurrencyToken() //ConcurrencyToken
                .HasColumnType("nvarchar(200)")
                .IsRequired();


            builder.Property(p => p.Family)
                .HasColumnName("LastName")
                .HasMaxLength(200)
                .IsRequired();
                //.IsConcurrencyToken();

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


            builder.Property(p => p.RowVersion).IsRowVersion(); //RowVersion

            //ShadowProperty
            builder.Property<DateTime>("CreateDate") 
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            builder.Property<DateTime>("ModifiedDate")
                .HasColumnType("datetime2")
                .ValueGeneratedOnUpdate()
                .HasValueGenerator<DateTimeValueGenerator>();

            builder.HasOne(p => p.MemberImage)
                .WithOne(ch => ch.Member)
                .HasForeignKey<MemberImage>(f => f.MemberId);

        }
    }
}

