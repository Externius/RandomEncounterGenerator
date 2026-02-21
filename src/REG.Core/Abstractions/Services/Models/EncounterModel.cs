namespace REG.Core.Abstractions.Services.Models;

public record EncounterModel
(
    EncounterDetail[] Encounters,
    int SumXp
);