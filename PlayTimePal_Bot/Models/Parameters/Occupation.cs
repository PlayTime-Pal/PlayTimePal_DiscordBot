using System.Text.Json.Serialization;

namespace BunkerAPI.Models.Parameters;

public class Occupation
{
    public string Job { get; set; }

    public string Experience { get; set; }
    
    public string Description { get; set; }

    [JsonConstructor]
    public Occupation(string job, string description)
    {
        Job = job;
        Description = description;
    }
    
    public Occupation(string job, string experience, string description)
    {
        Job = job;
        Experience = experience;
        Description = description;
    }
}