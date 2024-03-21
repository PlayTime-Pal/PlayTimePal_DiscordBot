namespace BunkerAPI.Models.Parameters;

public class Sex
{
    public string Gender { get; set; }
    
    public int Age { get; set; }
    
    public bool IsChildFree { get; set; }

    public Sex(string gender, int age, bool isChildFree)
    {
        Gender = gender;
        Age = age;
        IsChildFree = isChildFree;
    }
}