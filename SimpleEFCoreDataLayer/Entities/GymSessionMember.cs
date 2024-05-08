namespace SimpleEFCoreDataLayer.Entities;

public class GymSessionMember
{
    public Session Session { get; set; }
    public int SessionId { get; set; }

    public Member Member { get; set; }
    //? public int MemberId { get; set; }
}