namespace BunkerAPI.Models;

public class Parameter<T>
{
    public T Characteristic { get; set; }
    
    public bool IsVisible { get; set; }

    public Parameter(T characteristic, bool isVisible = false)
    {
        Characteristic = characteristic;
        IsVisible = isVisible;
    }
}