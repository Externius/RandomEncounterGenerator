using REG.Core.Domain;
using System.Collections.Generic;

namespace REG.Core.Test.GeneratorServiceTests;

public class MonsterData
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new List<MonsterType> { MonsterType.Aberration, MonsterType.Ooze, MonsterType.Fey } },
            new object[] { new List<MonsterType> { MonsterType.Beast, MonsterType.Humanoid, MonsterType.Celestial } },
            new object[] { new List<MonsterType> { MonsterType.Elemental, MonsterType.Giant, MonsterType.Fiend } },
            new object[] { new List<MonsterType> { MonsterType.SwarmOfTinyBeasts, MonsterType.Undead, MonsterType.Construct } },
            new object[] { new List<MonsterType> { MonsterType.Plant, MonsterType.Dragon, MonsterType.Monstrosity } }
        };
}