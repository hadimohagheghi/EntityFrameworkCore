namespace SimpleEFCoreDataLayer.Entities;

public class Coach : Person
{
    public List<GymCoach> GymCoaches { get; set; }
    public List<CoachCertificate> CoachCertificates { get; set; }
}