using SimpleEFCoreDataLayer.Enums;
using SimpleEFCoreDataLayer.ValueObjects;

namespace SimpleEFCoreDataLayer.Entities;

public class Session : BaseEntity<int>
{
    public Time StarTime { get; set; }
    public Time EndTime { get; set; }
    public Gender Gender { get; set; }
    public decimal Fee { get; set; } //بعضی باشگاه ها هزینه صبح ارزانتر از بعدازظهر هستش


    //Regerence Navigation Property
    public Guid GymId { get; set; }
    public Gym Gym { get; set; }//Navigation Property



    public List<GymSessionMember> GymSessionMembers { get; set; }

}