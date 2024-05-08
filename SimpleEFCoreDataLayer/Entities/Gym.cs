namespace SimpleEFCoreDataLayer.Entities;

public class Gym : BaseEntity<Guid>
{
    public string Title { get; set; }
    public int MemberCount { get; set; }

    //Navigation Property : Access to : A number of employees
    public List<Employee> Employees { get; set; }
    public List<Session> Sessions { get; set; }


    public List<GymCoach> GymCoaches { get; set; }
    //Relation Gym and Coach
    public List<Coach> Coaches { get; set; }//ByPass :  the interface entity


    //Reference Navigation Property
    public SportType SportType { get; set; } //Reference Navigation Property
    public int SportTypeId { get; set; }

}