namespace BunkerAPI.Models.Parameters;

public class Health
{
    public string Status { get; set; }
    
    public string? Stage { get; set; }

    public Health(string status, string? stage)
    {
        Status = status;
        Stage = stage;
    }
}