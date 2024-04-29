using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
            
        }

    }
}
