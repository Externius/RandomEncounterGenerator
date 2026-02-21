using REG.Core.Abstractions.Services.Models;
using REG.Core.Domain;
using Xunit;

namespace REG.Core.Tests.GeneratorServiceTests;

public class EncounterOptionData
{
    public static TheoryData<EncounterOption> Data =>
    [
        new EncounterOption
        (
            4,
            3,
            null,
            [MonsterType.Aberration],
            [Size.Small, Size.Medium]
        ),
        new EncounterOption
        (
            3,
            4,
            null,
            [MonsterType.Ooze, MonsterType.Fey],
            [Size.Tiny, Size.Small, Size.Medium]
        ),
        new EncounterOption
        (
            4,
            5,
            null,
            [MonsterType.Elemental, MonsterType.Giant, MonsterType.Fiend],
            [Size.Small, Size.Medium, Size.Large]
        ),
        new EncounterOption
        (
            8,
            4,
            null,
            [MonsterType.Beast, MonsterType.Humanoid, MonsterType.Celestial, MonsterType.Dragon],
            [Size.Medium, Size.Large, Size.Huge]
        ),
        new EncounterOption
        (
            12,
            3,
            null,
            [
                MonsterType.SwarmOfTinyBeasts, MonsterType.Undead, MonsterType.Construct,
                MonsterType.Plant, MonsterType.Monstrosity
            ],
            [Size.Medium, Size.Large, Size.Huge, Size.Gargantuan]
        )
    ];

    public static TheoryData<Difficulty, int, int> FilterWithDifficultyData =>
        new()
        {
            { Difficulty.Easy, 1, 4 },
            { Difficulty.Medium, 2, 3 },
            { Difficulty.Hard, 4, 5 },
            { Difficulty.Deadly, 7, 3 }
        };
}