using REG.Core.Domain;

namespace REG.Core.Abstractions.Services.Models;

public record EncounterOption(
    int PartyLevel,
    int PartySize,
    Difficulty? Difficulty,
    MonsterType[] MonsterTypes,
    Size[] Sizes,
    int Count = 10
);