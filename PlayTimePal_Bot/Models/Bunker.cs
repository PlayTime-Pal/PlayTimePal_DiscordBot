namespace BunkerAPI.Models.Parameters;

public class Bunker
{
    public int Age { get; set; }
    
    public string Description { get; set; }
    
    public string Location { get; set; }
    
    public string Rooms { get; set; }
    
    public int Area { get; set; }
    
    public int MonthsToStay { get; set; }
    
    public int FoodForMonths { get; set; }
    
    public List<string> Items { get; set; }
    
    public int AmountSpots { get; set; }

    public Bunker(int age, string description, string location, string rooms, int area, int monthsToStay,
        int foodForMonths, List<string> items)
    {
        Age = age;
        Description = description;
        Location = location;
        Rooms = rooms;
        Area = area;
        MonthsToStay = monthsToStay;
        FoodForMonths = foodForMonths;
        Items = items;
    }
}