using BunkerAPI.Models.Parameters;

namespace BunkerAPI.Models;

public class Player
{
    public string Id { get; set; }
    
    public Parameter<Sex> Sex { get; set; }
    
    public Parameter<BodyType> BodyType { get; set; }
    
    public Parameter<List<string>> Trait { get; set; }
    
    public Parameter<Occupation> Occupation { get; set; }

    public Parameter<Health> Health { get; set; }

    public Parameter<List<Hobby>> Hobby { get; set; }
    
    public Parameter<List<string>> Phobia { get; set; }
    
    public Parameter<List<string>> Inventory { get; set; }
    
    public Parameter<List<string>> AdditionalInfo { get; set; }
    
    public Parameter<string> Ability1 { get; set; }
    
    public Parameter<string> Ability2 { get; set; }
    
    public Player(string id, Parameter<Sex> sex, Parameter<BodyType> bodyType, Parameter<List<string>> trait,
                  Parameter<Occupation> occupation, Parameter<Health> health, Parameter<List<Hobby>> hobby,
                  Parameter<List<string>> phobia, Parameter<List<string>> inventory,
                  Parameter<List<string>> additionalInfo, Parameter<string> ability1, Parameter<string> ability2)
    {
        Id = id;
        Sex = sex;
        BodyType = bodyType;
        Trait = trait;
        Occupation = occupation;
        Health = health;
        Hobby = hobby;
        Phobia = phobia;
        Inventory = inventory;
        AdditionalInfo = additionalInfo;
        Ability1 = ability1;
        Ability2 = ability2;
    }
    
    public Player(string id, Sex sex, BodyType bodyType, string trait,
        Occupation occupation, Health health, Hobby hobby,
        string phobia, string inventory,
        string additionalInfo, string ability1, string ability2)
    {
        Id = id;
        Sex = new Parameter<Sex>(sex);
        BodyType = new Parameter<BodyType>(bodyType);
        Trait = new Parameter<List<string>>(new List<string>() {trait});
        Occupation = new Parameter<Occupation>(occupation);
        Health = new Parameter<Health>(health);
        Hobby = new Parameter<List<Hobby>>(new List<Hobby>() {hobby});
        Phobia = new Parameter<List<string>>(new List<string>() {phobia});
        Inventory = new Parameter<List<string>>(new List<string>() {inventory});
        AdditionalInfo = new Parameter<List<string>>(new List<string>() {additionalInfo});
        Ability1 = new Parameter<string>(ability1);
        Ability2 = new Parameter<string>(ability2);
    }

    public Player()
    {
        
    }
}