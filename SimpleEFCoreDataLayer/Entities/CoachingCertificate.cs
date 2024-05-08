namespace SimpleEFCoreDataLayer.Entities;

public class CoachingCertificate : BaseEntity<Guid>
{
    /// <summary>
    /// مثلاً : مربیگری درجه یک پرورش اندام ....
    /// </summary>
    public string Title { get; set; }
    public string Description { get; set; }


    public List<CoachCertificate> CoachCertificates { get; set; }
}