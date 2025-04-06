using REG.Core.Abstractions.Services.Models.Json;
using Action = REG.Core.Abstractions.Services.Models.Json.Action;

namespace REG.Core.Abstractions.Services.Models;

public class EncounterDetail
{
    public int Xp { get; set; }
    public int Count { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string Difficulty { get; set; }
    public required string ChallengeRating { get; set; }
    public required string Size { get; set; }
    public required string Alignment { get; set; }
    public int Hp { get; set; }
    public int Ac { get; set; }
    public required string HitDice { get; set; }
    public required string Speed { get; set; }
    public required string Senses { get; set; }
    public required string Languages { get; set; }
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
    public string? DamageVulnerabilities { get; set; }
    public string? DamageResistances { get; set; }
    public string? DamageImmunities { get; set; }
    public string? ConditionImmunities { get; set; }
    public List<SpecialAbility> SpecialAbilities { get; set; } = [];
    public List<Action> Actions { get; set; } = [];
    public List<LegendaryAction> LegendaryActions { get; set; } = [];
    public List<Reaction> Reactions { get; set; } = [];
}