namespace SimpleEFCoreDataLayer.Entities;

public class CoachCertificate
{
    public CoachingCertificate CoachingCertificate { get; set; }
    public int CoachingCertificateId { get; set; }

    public Coach Coach { get; set; }
    public int CoachId { get; set; }
}