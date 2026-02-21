using System.Text.Json.Serialization;

namespace REG.Core.Abstractions.Services.Models.Json;

public record Monster(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("size")] string Size,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("subtype")]
    string? Subtype,
    [property: JsonPropertyName("alignment")]
    string? Alignment,
    [property: JsonPropertyName("armor_class")]
    int? ArmorClass,
    [property: JsonPropertyName("hit_points")]
    int? HitPoints,
    [property: JsonPropertyName("hit_dice")]
    string? HitDice,
    [property: JsonPropertyName("speed")] string? Speed,
    [property: JsonPropertyName("strength")]
    int? Strength,
    [property: JsonPropertyName("dexterity")]
    int? Dexterity,
    [property: JsonPropertyName("constitution")]
    int? Constitution,
    [property: JsonPropertyName("intelligence")]
    int? Intelligence,
    [property: JsonPropertyName("wisdom")] int? Wisdom,
    [property: JsonPropertyName("charisma")]
    int? Charisma,
    [property: JsonPropertyName("constitution_save")]
    int? ConstitutionSave,
    [property: JsonPropertyName("intelligence_save")]
    int? IntelligenceSave,
    [property: JsonPropertyName("wisdom_save")]
    int? WisdomSave,
    [property: JsonPropertyName("history")]
    int? History,
    [property: JsonPropertyName("perception")]
    int? Perception,
    [property: JsonPropertyName("damage_vulnerabilities")]
    string? DamageVulnerabilities,
    [property: JsonPropertyName("damage_resistances")]
    string? DamageResistances,
    [property: JsonPropertyName("damage_immunities")]
    string? DamageImmunities,
    [property: JsonPropertyName("condition_immunities")]
    string? ConditionImmunities,
    [property: JsonPropertyName("senses")] string? Senses,
    [property: JsonPropertyName("languages")]
    string? Languages,
    [property: JsonPropertyName("challenge_rating")]
    string ChallengeRating,
    [property: JsonPropertyName("special_abilities")]
    SpecialAbility[]? SpecialAbilities,
    [property: JsonPropertyName("actions")]
    Action[]? Actions,
    [property: JsonPropertyName("legendary_actions")]
    LegendaryAction[]? LegendaryActions,
    [property: JsonPropertyName("medicine")]
    int? Medicine,
    [property: JsonPropertyName("religion")]
    int? Religion,
    [property: JsonPropertyName("dexterity_save")]
    int? DexteritySave,
    [property: JsonPropertyName("charisma_save")]
    int? CharismaSave,
    [property: JsonPropertyName("stealth")]
    int? Stealth,
    [property: JsonPropertyName("persuasion")]
    int? Persuasion,
    [property: JsonPropertyName("insight")]
    int? Insight,
    [property: JsonPropertyName("deception")]
    int? Deception,
    [property: JsonPropertyName("arcana")] int? Arcana,
    [property: JsonPropertyName("athletics")]
    int? Athletics,
    [property: JsonPropertyName("acrobatics")]
    int? Acrobatics,
    [property: JsonPropertyName("strength_save")]
    int? StrengthSave,
    [property: JsonPropertyName("reactions")]
    Reaction[]? Reactions,
    [property: JsonPropertyName("survival")]
    int? Survival,
    [property: JsonPropertyName("investigation")]
    int? Investigation,
    [property: JsonPropertyName("nature")] int? Nature,
    [property: JsonPropertyName("intimidation")]
    int? Intimidation,
    [property: JsonPropertyName("performance")]
    int? Performance
);