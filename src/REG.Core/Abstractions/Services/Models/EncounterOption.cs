using REG.Core.Domain;
using System.Collections.Generic;

namespace REG.Core.Abstractions.Services.Models;

public class EncounterOption
{
    public int PartyLevel { get; set; }
    public int PartySize { get; set; }
    public Difficulty? Difficulty { get; set; }
    public IEnumerable<MonsterType> MonsterTypes { get; set; }
    public int Count { get; set; } = 10;
    public EncounterOption()
    {
        MonsterTypes = new List<MonsterType>();
    }
}