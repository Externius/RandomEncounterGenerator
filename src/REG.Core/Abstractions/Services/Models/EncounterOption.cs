using REG.Core.Domain;
using System.Collections.Generic;

namespace REG.Core.Abstractions.Services.Models;

public class EncounterOption
{
    public int PartyLevel { get; set; }
    public int PartySize { get; set; }
    public Difficulty? Difficulty { get; set; }
    public IEnumerable<MonsterType> MonsterTypes { get; set; } = new List<MonsterType>();
    public IEnumerable<Size> Sizes { get; set; } = new List<Size>();
    public int Count { get; set; } = 10;
}