using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using SimpleEFCoreDataLayer.Enums;

namespace SimpleEFCoreDataLayer.Entities
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public Gender Gender { get; set; }
    }
}
