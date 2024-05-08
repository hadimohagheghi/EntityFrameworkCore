using SimpleEFCoreDataLayer.ValueObjects;

namespace SimpleEFCoreDataLayer.Entities;

public class SportType : BaseEntity<int>
{
    public string Title { get; set; }
    public AgeRange AgeRange { get; set; }

    //Collection Navigation Property
    public List<Gym> Gyms { get; set; }
}