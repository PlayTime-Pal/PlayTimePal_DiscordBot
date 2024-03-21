namespace BunkerAPI.Models;

public class Catastrophe
{
    public string Description { get; set; }
    
    public int AmountPeople { get; set; }

    public Catastrophe(string description, int amountPeople)
    {
        Description = description;
        AmountPeople = amountPeople;
    }
}