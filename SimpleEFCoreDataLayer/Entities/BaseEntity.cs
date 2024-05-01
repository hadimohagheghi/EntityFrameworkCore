using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using SimpleEFCoreDataLayer.Enums;
using SimpleEFCoreDataLayer.ValueObjects;

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
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class Coach : Person
    {

    }

    public class Member : Person
    {
        public DateTime RegisterDate { get; set; }
    }

    public class Employee : Person
    {

        //Navigation Property
        public Gym Gym { get; set; }   
        public Guid GymId { get; set; }

        //Gym (Parent , Reference) -> Employee (Child,Collection)
    }

    public class SportType : BaseEntity<int>
    {
        public string Title { get; set; }
        public AgeRange AgeRange { get; set; }
    }




    public class Gym : BaseEntity<Guid>
    {
        public string Title { get; set; }

        //Navigation Property : Access to : A number of employees
        public List<Employee> Employees { get; set; }
        public List<Session> Sessions { get; set; }

    }

    public class Session : BaseEntity<int>
    {
        public Time StarTime { get; set; }
        public Time EndTime { get; set; }
        public Gender Gender { get; set; }

        //Navigation Property
        public Guid GymId { get; set; }
        public Gym Gym { get; set; }//Navigation Property

    }

    class CoachingCertificate:BaseEntity<Guid>
    {
        /// <summary>
        /// مثلاً : مربیگری درجه یک پرورش اندام ....
        /// </summary>
        public string Title { get; set; }
    }

}
