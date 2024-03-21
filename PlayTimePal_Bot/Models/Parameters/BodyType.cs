namespace BunkerAPI.Models.Parameters;

public class BodyType
{
    public string Status { get; set; }
    
    public int Height { get; set; }

    public BodyType(string status, int height)
    {
        Status = status;
        Height = height;
    }
}
