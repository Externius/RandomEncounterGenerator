namespace REG.Core.Abstractions.Services.Models.Json;

public class Action
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public int Attack_Bonus { get; set; }
    public string Damage_Dice { get; set; }
    public int? Damage_Bonus { get; set; }
}