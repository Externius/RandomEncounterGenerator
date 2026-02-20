using System.Text.Json.Serialization;

namespace REG.Core.Abstractions.Services.Models.Json;

public record Reaction(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("desc")] string? Desc,
    [property: JsonPropertyName("attack_bonus")]
    int? AttackBonus
);