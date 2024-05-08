using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace SimpleEFCoreDataLayer.Entities
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public bool IsDeleted { get; set; }

        public byte[] RowVersion { get; set; }
    }


    //Configuration By Fluent API (Config on Separated Entities) : The relationship between DBContext and Entities & Mapping to DB
    //Don't Use DataAnnotation!
}
