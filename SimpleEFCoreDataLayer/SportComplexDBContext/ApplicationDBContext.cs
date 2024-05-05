using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleEFCoreDataLayer.Configs;
using SimpleEFCoreDataLayer.Entities;

namespace SimpleEFCoreDataLayer.SportComplexDBContext
{
    public class ApplicationDBContext:DbContext
    {
        //log
        //filter
        //Add Entity
        //Tracking
        //...
        public ApplicationDBContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("ConnectionString");
            base.OnConfiguring(optionsBuilder);
        }

        //public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        //{

        //}


        //public DbSet<Member> Members { get; set; }
        //Configuration By Fluent API : The relationship between DBContext and Entities & Mapping to DB : Method A
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*this method is not Best Practice
            //We do not want to create a table equivalent to this entity
            modelBuilder.Ignore<Coach>();
            //We just want to introduce the tables
            modelBuilder.Entity<Member>()
                .ToTable("Members","PRS");  //TableName  , Schema : To group tables 

            //
            modelBuilder.Entity<Employee>(c =>
                {
                    c.ToTable("Employees");
                    c.Property(p => p.Name).HasMaxLength(100);
                    c.HasKey(k => k.Id);
                }
            );
            */

            base.OnModelCreating(modelBuilder);


            var assembly = typeof(CoachConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        }
    }
}
