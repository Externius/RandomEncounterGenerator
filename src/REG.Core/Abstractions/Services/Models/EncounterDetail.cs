using REG.Core.Abstractions.Services.Models.Json;
using Action = REG.Core.Abstractions.Services.Models.Json.Action;

namespace REG.Core.Abstractions.Services.Models;

public record EncounterDetail(
    int Xp,
    int Count,
    string Name,
    string Type,
    string Difficulty,
    string ChallengeRating,
    string Size,
    string Alignment,
    int Hp,
    int Ac,
    string HitDice,
    string Speed,
    string Senses,
    string Languages,
    int Strength,
    int Dexterity,
    int Constitution,
    int Intelligence,
    int Wisdom,
    int Charisma,
    int StrengthSave,
    int DexteritySave,
    int ConstitutionSave,
    int IntelligenceSave,
    int WisdomSave,
    int CharismaSave,
    int History,
    int Perception,
    string? DamageVulnerabilities,
    string? DamageResistances,
    string? DamageImmunities,
    string? ConditionImmunities,
    SpecialAbility[] SpecialAbilities,
    Action[] Actions,
    LegendaryAction[] LegendaryActions,
    Reaction[] Reactions
);