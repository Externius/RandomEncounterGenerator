using System.Collections.Generic;

namespace REG.Core.Abstractions.Services.Models.Json
{
    public class Monster
    {
    public string Name { get; set; }
    public string Size { get; set; }
    public string Type { get; set; }
    public string Subtype { get; set; }
    public string Alignment { get; set; }
    public int Armor_Class { get; set; }
    public int Hit_Points { get; set; }
    public string Hit_Dice { get; set; }
    public string Speed { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }
    public int Constitution_Save { get; set; }
    public int Intelligence_Save { get; set; }
    public int Wisdom_Save { get; set; }
    public int History { get; set; }
    public int Perception { get; set; }
    public string Damage_Vulnerabilities { get; set; }
    public string Damage_Resistances { get; set; }
    public string Damage_Immunities { get; set; }
    public string Condition_Immunities { get; set; }
    public string Senses { get; set; }
    public string Languages { get; set; }
    public string Challenge_Rating { get; set; }
    public List<SpecialAbility> Special_Abilities { get; set; }
    public List<Action> Actions { get; set; }
    public List<LegendaryAction> Legendary_Actions { get; set; }
    public int? Dedicine { get; set; }
    public int? Religion { get; set; }
    public int? Dexterity_Save { get; set; }
    public int? Charisma_Save { get; set; }
    public int? Stealth { get; set; }
    public int? Persuasion { get; set; }
    public int? Insight { get; set; }
    public int? Deception { get; set; }
    public int? Arcana { get; set; }
    public int? Athletics { get; set; }
    public int? Acrobatics { get; set; }
    public int? Strength_Save { get; set; }
    public List<Reaction> Reactions { get; set; }
    public int? Survival { get; set; }
    public int? Investigation { get; set; }
    public int? Nature { get; set; }
    public int? Intimidation { get; set; }
    public int? Performance { get; set; }
    }
}