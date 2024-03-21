using BunkerAPI.Models.Parameters;

namespace BunkerAPI.Models;

public class Room
{
    public ulong Id { get; set; }
    
    public List<Player> Players { get; set; }
    
    public Bunker Bunker { get; set; }
    
    public Catastrophe Catastrophe { get; set; }

    public Room(ulong id, List<Player> players, Bunker bunker, Catastrophe catastrophe)
    {
        Id = id;
        Players = players;
        Bunker = bunker;
        Catastrophe = catastrophe;
    }
}