using REG.Core.Abstractions.Services.Models.Json;
using System.Collections.Generic;

namespace REG.Core.Abstractions.Services.Models;

public class EncounterDetail
{
    public int Xp { get; set; }
    public int Count { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Difficulty { get; set; }
    public string ChallengeRating { get; set; }
    public string Size { get; set; }
    public string Alignment { get; set; }
    public int Hp { get; set; }
    public int Ac { get; set; }
    public string HitDice { get; set; }
    public string Speed { get; set; }
    public string Senses { get; set; }
    public string Languages { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }
    public int StrengthSave { get; set; }
    public int DexteritySave { get; set; }
    public int ConstitutionSave { get; set; }
    public int IntelligenceSave { get; set; }
    public int WisdomSave { get; set; }
    public int CharismaSave { get; set; }
    public int History { get; set; }
    public int Perception { get; set; }
    public string DamageVulnerabilities { get; set; }
    public string DamageResistances { get; set; }
    public string DamageImmunities { get; set; }
    public string ConditionImmunities { get; set; }
    public List<SpecialAbility> SpecialAbilities { get; set; }
    public List<Action> Actions { get; set; }
    public List<LegendaryAction> LegendaryActions { get; set; }
    public List<Reaction> Reactions { get; set; }
    public EncounterDetail()
    {
        SpecialAbilities = new List<SpecialAbility>();
        Actions = new List<Action>();
        LegendaryActions = new List<LegendaryAction>();
        Reactions = new List<Reaction>();
    }
}