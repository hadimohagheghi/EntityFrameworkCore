using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEFCoreDataLayer.Entities;

namespace SimpleEFCoreDataLayer.Configs
{
    public class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members", "PRS");
            builder.HasComment("این جدول برای نگهداری اطلاعات ورزشکاران است");


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
