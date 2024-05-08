namespace SimpleEFCoreDataLayer.Entities;

public class Coach : Person
{
    public List<GymCoach> GymCoaches { get; set; }
    //Relation Gym and Coach
    public List<Gym> Gyms { get; set; }//ByPass :  the interface entity


    public List<CoachCertificate> CoachCertificates { get; set; }

    public List<CoachCertificate> Certificates { get; set; }
}