using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
        public List<GymCoach> GymCoaches { get; set; }
        public List<CoachCertificate> CoachCertificates { get; set; }
    }

    public class Member : Person
    {
        public DateTime RegisterDate { get; set; }


        public List<GymSessionMember> GymSessionMembers { get; set; }
    }

    public class Employee : Person
    {

        //Navigation Property
        public Gym Gym { get; set; }
        public Guid GymId { get; set; }

        //Gym (Parent , Master , Reference) -> Employee (Child, Detail ,Collection)
    }

    public class SportType : BaseEntity<int>
    {
        public string Title { get; set; }
        public AgeRange AgeRange { get; set; }

        //Collection Navigation Property
        public List<Gym> Gyms { get; set; }
    }




    public class Gym : BaseEntity<Guid>
    {
        public string Title { get; set; }

        //Navigation Property : Access to : A number of employees
        public List<Employee> Employees { get; set; }
        public List<Session> Sessions { get; set; }


        public List<GymCoach> GymCoaches { get; set; }

        //Reference Navigation Property
        public SportType SportType { get; set; } //Reference Navigation Property
        public int SportTypeId { get; set; }

    }

    public class Session : BaseEntity<int>
    {
        public Time StarTime { get; set; }
        public Time EndTime { get; set; }
        public Gender Gender { get; set; }

        //Regerence Navigation Property
        public Guid GymId { get; set; }
        public Gym Gym { get; set; }//Navigation Property



        public List<GymSessionMember> GymSessionMembers { get; set; }

    }

    public class CoachingCertificate : BaseEntity<Guid>
    {
        /// <summary>
        /// مثلاً : مربیگری درجه یک پرورش اندام ....
        /// </summary>
        public string Title { get; set; }


        public List<CoachCertificate> CoachCertificates { get; set; }
    }

    /// <summary>
    /// ارتباط بین باشگاه و مربی
    /// رابطه چند به چند
    /// </summary>
    public class GymCoach : BaseEntity<int>
    {
        public Gym Gym { get; set; }
        public Guid GymId { get; set; }

        public Coach Coach { get; set; }
        public int CoachId { get; set; }

    }

    public class CoachCertificate
    {
        public CoachingCertificate CoachingCertificate { get; set; }
        public int CoachingCertificateId { get; set; }

        public Coach Coach { get; set; }
        public int CoachId { get; set; }
    }

    public class GymSessionMember
    {
        public Session Session { get; set; }
        public int SessionId { get; set; }

        public Member Member { get; set; }
        //? public int MemberId { get; set; }
    }

}
