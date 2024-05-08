using SimpleEFCoreDataLayer.Enums;

namespace SimpleEFCoreDataLayer.Entities;

public class Person : BaseEntity<int>
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string FatherName { get; set; }
    public string NationalCode { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
}