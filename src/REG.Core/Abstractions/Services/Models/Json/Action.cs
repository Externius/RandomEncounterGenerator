using System.Text.Json.Serialization;

namespace REG.Core.Abstractions.Services.Models.Json;

public class Action
{
    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("desc")] public string? Desc { get; set; }

    [JsonPropertyName("attack_bonus")] public int? AttackBonus { get; set; }

    [JsonPropertyName("damage_dice")] public string? DamageDice { get; set; }

    [JsonPropertyName("damage_bonus")] public int? DamageBonus { get; set; }
}