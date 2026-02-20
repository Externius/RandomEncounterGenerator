using System.Text.Json.Serialization;

namespace REG.Core.Abstractions.Services.Models.Json;

public record SpecialAbility(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("desc")] string? Desc,
    [property: JsonPropertyName("attack_bonus")]
    int? AttackBonus,
    [property: JsonPropertyName("damage_dice")]
    string? DamageDice
);