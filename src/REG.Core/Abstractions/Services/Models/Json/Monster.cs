using System.Text.Json.Serialization;

namespace REG.Core.Abstractions.Services.Models.Json;

public class Monster
{
    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("size")] public required string Size { get; set; }

    [JsonPropertyName("type")] public required string Type { get; set; }

    [JsonPropertyName("subtype")] public string? Subtype { get; set; }

    [JsonPropertyName("alignment")] public string? Alignment { get; set; }

    [JsonPropertyName("armor_class")] public int? ArmorClass { get; set; }

    [JsonPropertyName("hit_points")] public int? HitPoints { get; set; }

    [JsonPropertyName("hit_dice")] public string? HitDice { get; set; }

    [JsonPropertyName("speed")] public string? Speed { get; set; }

    [JsonPropertyName("strength")] public int? Strength { get; set; }

    [JsonPropertyName("dexterity")] public int? Dexterity { get; set; }

    [JsonPropertyName("constitution")] public int? Constitution { get; set; }

    [JsonPropertyName("intelligence")] public int? Intelligence { get; set; }

    [JsonPropertyName("wisdom")] public int? Wisdom { get; set; }

    [JsonPropertyName("charisma")] public int? Charisma { get; set; }

    [JsonPropertyName("constitution_save")]
    public int? ConstitutionSave { get; set; }

    [JsonPropertyName("intelligence_save")]
    public int? IntelligenceSave { get; set; }

    [JsonPropertyName("wisdom_save")] public int? WisdomSave { get; set; }

    [JsonPropertyName("history")] public int? History { get; set; }

    [JsonPropertyName("perception")] public int? Perception { get; set; }

    [JsonPropertyName("damage_vulnerabilities")]
    public string? DamageVulnerabilities { get; set; }

    [JsonPropertyName("damage_resistances")]
    public string? DamageResistances { get; set; }

    [JsonPropertyName("damage_immunities")]
    public string? DamageImmunities { get; set; }

    [JsonPropertyName("condition_immunities")]
    public string? ConditionImmunities { get; set; }

    [JsonPropertyName("senses")] public string? Senses { get; set; }

    [JsonPropertyName("languages")] public string? Languages { get; set; }

    [JsonPropertyName("challenge_rating")] public required string ChallengeRating { get; set; }

    [JsonPropertyName("special_abilities")]
    public List<SpecialAbility> SpecialAbilities { get; set; } = [];

    [JsonPropertyName("actions")] public List<Action> Actions { get; set; } = [];

    [JsonPropertyName("legendary_actions")]
    public List<LegendaryAction> LegendaryActions { get; set; } = [];

    [JsonPropertyName("medicine")] public int? Medicine { get; set; }

    [JsonPropertyName("religion")] public int? Religion { get; set; }

    [JsonPropertyName("dexterity_save")] public int? DexteritySave { get; set; }

    [JsonPropertyName("charisma_save")] public int? CharismaSave { get; set; }

    [JsonPropertyName("stealth")] public int? Stealth { get; set; }

    [JsonPropertyName("persuasion")] public int? Persuasion { get; set; }

    [JsonPropertyName("insight")] public int? Insight { get; set; }

    [JsonPropertyName("deception")] public int? Deception { get; set; }

    [JsonPropertyName("arcana")] public int? Arcana { get; set; }

    [JsonPropertyName("athletics")] public int? Athletics { get; set; }

    [JsonPropertyName("acrobatics")] public int? Acrobatics { get; set; }

    [JsonPropertyName("strength_save")] public int? StrengthSave { get; set; }

    [JsonPropertyName("reactions")] public List<Reaction> Reactions { get; set; } = [];

    [JsonPropertyName("survival")] public int? Survival { get; set; }

    [JsonPropertyName("investigation")] public int? Investigation { get; set; }

    [JsonPropertyName("nature")] public int? Nature { get; set; }

    [JsonPropertyName("intimidation")] public int? Intimidation { get; set; }

    [JsonPropertyName("performance")] public int? Performance { get; set; }
}