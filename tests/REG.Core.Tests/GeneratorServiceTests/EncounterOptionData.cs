using REG.Core.Abstractions.Services.Models;
using REG.Core.Domain;
using System.Collections.Generic;

namespace REG.Core.Tests.GeneratorServiceTests;

public class EncounterOptionData
{
    public static IEnumerable<object[]> FilterWithMonsterTypesData =>
        new List<object[]>
        {
            new object[] { new EncounterOption
            {
                PartyLevel = 4,
                MonsterTypes = new List<MonsterType> { MonsterType.Aberration },
                PartySize = 3
            }},
            new object[] { new EncounterOption
            {
                PartyLevel = 3,
                MonsterTypes = new List<MonsterType> { MonsterType.Ooze, MonsterType.Fey },
                PartySize = 4
            }},
            new object[] { new EncounterOption
            {
                PartyLevel = 4,
                MonsterTypes = new List<MonsterType> { MonsterType.Elemental, MonsterType.Giant, MonsterType.Fiend },
                PartySize = 5
            }},
            new object[] { new EncounterOption
            {
                PartyLevel = 8,
                MonsterTypes = new List<MonsterType> {  MonsterType.Beast, MonsterType.Humanoid, MonsterType.Celestial, MonsterType.Dragon },
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