namespace SimpleEFCoreDataLayer.Entities;

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