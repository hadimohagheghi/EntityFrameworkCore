namespace SimpleEFCoreDataLayer.Entities;

public class Member : Person
{
    public string FullName { get; set; }
    public DateTime RegisterDate { get; set; }
    public string TrackingCode { get; set; }

    public List<GymSessionMember> GymSessionMembers { get; set; }
}