using REG.Core.Abstractions.Services.Models;
using REG.Core.Domain;
using System.Collections.Generic;

namespace REG.Core.Tests.GeneratorServiceTests;

public class EncounterOptionData
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new EncounterOption
            {
                PartyLevel = 4,
                MonsterTypes = new List<MonsterType> { MonsterType.Aberration },
                Sizes = new List<Size> { Size.Small, Size.Medium },
                PartySize = 3
            }},
            new object[] { new EncounterOption
            {
                PartyLevel = 3,
                MonsterTypes = new List<MonsterType> { MonsterType.Ooze, MonsterType.Fey },
                Sizes = new List<Size> { Size.Tiny, Size.Small, Size.Medium },
                PartySize = 4
            }},
            new object[] { new EncounterOption
            {
                PartyLevel = 4,
                MonsterTypes = new List<MonsterType> { MonsterType.Elemental, MonsterType.Giant, MonsterType.Fiend },
                Sizes = new List<Size> { Size.Small, Size.Medium, Size.Large },
                PartySize = 5
            }},
            new object[] { new EncounterOption
            {
                PartyLevel = 8,
                MonsterTypes = new List<MonsterType> {  MonsterType.Beast, MonsterType.Humanoid, MonsterType.Celestial, MonsterType.Dragon },
                Sizes = new List<Size> { Size.Medium, Size.Large, Size.Huge },
                PartySize = 4
            }},
            new object[] { new EncounterOption
            {
                PartyLevel = 12,
                MonsterTypes = new List<MonsterType>
                {
                    MonsterType.SwarmOfTinyBeasts, MonsterType.Undead, MonsterType.Construct,
                    MonsterType.Plant, MonsterType.Monstrosity
                },
                Sizes = new List<Size> { Size.Medium, Size.Large, Size.Huge, Size.Gargantuan },
                PartySize = 3
            }}
        };
    public static IEnumerable<object[]> FilterWithDifficultyData =>
        new List<object[]>
        {
            new object[] { Difficulty.Easy, 1, 4 },
            new object[] { Difficulty.Medium, 2, 3},
            new object[] { Difficulty.Hard, 4, 5 },
            new object[] { Difficulty.Deadly, 7, 3 }
        };
}