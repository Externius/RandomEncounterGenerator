using REG.Core.Abstractions.Services.Models;
using REG.Core.Domain;
using System.Collections.Generic;
using Xunit;

namespace REG.Core.Tests.GeneratorServiceTests;

public class EncounterOptionData
{
    public static TheoryData<EncounterOption> Data =>
    [
        new()
        {
            PartyLevel = 4,
            MonsterTypes = new List<MonsterType> { MonsterType.Aberration },
            Sizes = new List<Size> { Size.Small, Size.Medium },
            PartySize = 3
        },
        new()
        {
            PartyLevel = 3,
            MonsterTypes = new List<MonsterType> { MonsterType.Ooze, MonsterType.Fey },
            Sizes = new List<Size> { Size.Tiny, Size.Small, Size.Medium },
            PartySize = 4
        },
        new()
        {
            PartyLevel = 4,
            MonsterTypes =
                new List<MonsterType> { MonsterType.Elemental, MonsterType.Giant, MonsterType.Fiend },
            Sizes = new List<Size> { Size.Small, Size.Medium, Size.Large },
            PartySize = 5
        },
        new()
        {
            PartyLevel = 8,
            MonsterTypes = new List<MonsterType>
                { MonsterType.Beast, MonsterType.Humanoid, MonsterType.Celestial, MonsterType.Dragon },
            Sizes = new List<Size> { Size.Medium, Size.Large, Size.Huge },
            PartySize = 4
        },
        new()
        {
            PartyLevel = 12,
            MonsterTypes = new List<MonsterType>
            {
                MonsterType.SwarmOfTinyBeasts, MonsterType.Undead, MonsterType.Construct,
                MonsterType.Plant, MonsterType.Monstrosity
            },
            Sizes = new List<Size> { Size.Medium, Size.Large, Size.Huge, Size.Gargantuan },
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