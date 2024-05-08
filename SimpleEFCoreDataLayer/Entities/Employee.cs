namespace SimpleEFCoreDataLayer.Entities;

public class Employee : Person
{

    //Navigation Property
    public Gym Gym { get; set; }
    public Guid GymId { get; set; }

    //Gym (Parent , Master , Reference) -> Employee (Child, Detail ,Collection)
}