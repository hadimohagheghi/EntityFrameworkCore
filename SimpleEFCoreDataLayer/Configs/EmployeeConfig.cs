using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees", "PRS");
            builder.HasComment("این جدول برای نگهداری اطلاعات کارکنان است");

            //پیش فرض کلید اصلی اتوجنریت هستش و مقادیرش خودش ساخته میشود
            builder.HasKey(k => k.Id)//مشخص کردن کلید اصلی
                .HasName("ID"); //تغییرنام کلید اصلی

          
            builder.Property(p => p.Name)
                .HasColumnName("FirstName")
                .HasColumnType("nvarchar(200)")
                .IsRequired();


            builder.Property(p => p.Family)
                .HasColumnName("LastName")
                .HasMaxLength(200)
                .IsRequired();


            builder.Property(p => p.FatherName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.NationalCode)
                .HasMaxLength(10)
                .IsRequired();

           builder.Property(p => p.RowVersion).IsRowVersion(); //RowVersion

            //ShadowProperty
            builder.Property<DateTime>("CreateDate") 
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            builder.Property<DateTime>("ModifiedDate")
                .HasColumnType("datetime2")
                .ValueGeneratedOnUpdate()
                .HasValueGenerator<DateTimeValueGenerator>();


            builder.HasOne(employee => employee.Gym)
                .WithMany(gym => gym.Employees)
                .HasForeignKey(f=>f.GymId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

