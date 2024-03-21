namespace BunkerAPI.Models.Parameters;

public class Hobby
{
    public string Name { get; set; }

    public string Experience { get; set; }
    
    public Hobby(string name, string experience)
    {
        Name = name;
        Experience = experience;
    }
}