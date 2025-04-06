using REG.Core.Abstractions.Services.Models;
using REG.Core.Domain;
using Xunit;

namespace REG.Core.Tests.GeneratorServiceTests;

public class EncounterOptionData
{
    public static TheoryData<EncounterOption> Data =>
    [
        new EncounterOption
        {
            PartyLevel = 4,
            MonsterTypes = [MonsterType.Aberration],
            Sizes = [Size.Small, Size.Medium],
            PartySize = 3
        },
        new EncounterOption
        {
            PartyLevel = 3,
            MonsterTypes = [MonsterType.Ooze, MonsterType.Fey],
            Sizes = [Size.Tiny, Size.Small, Size.Medium],
            PartySize = 4
        },
        new EncounterOption
        {
            PartyLevel = 4,
            MonsterTypes =
                [MonsterType.Elemental, MonsterType.Giant, MonsterType.Fiend],
            Sizes = [Size.Small, Size.Medium, Size.Large],
            PartySize = 5
        },
        new EncounterOption
        {
            PartyLevel = 8,
            MonsterTypes = [MonsterType.Beast, MonsterType.Humanoid, MonsterType.Celestial, MonsterType.Dragon],
            Sizes = [Size.Medium, Size.Large, Size.Huge],
            PartySize = 4
        },
        new EncounterOption
        {
            PartyLevel = 12,
            MonsterTypes =
            [
                MonsterType.SwarmOfTinyBeasts, MonsterType.Undead, MonsterType.Construct,
                MonsterType.Plant, MonsterType.Monstrosity
            ],
            Sizes = [Size.Medium, Size.Large, Size.Huge, Size.Gargantuan],
            PartySize = 3
        }
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