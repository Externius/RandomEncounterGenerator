using REG.Core.Domain;

namespace REG.Core.Abstractions.Services.Models;

public class EncounterOption
{
    public int PartyLevel { get; set; }
    public int PartySize { get; set; }
    public Difficulty? Difficulty { get; set; }
    public IEnumerable<MonsterType> MonsterTypes { get; set; } = [];
    public IEnumerable<Size> Sizes { get; set; } = [];
    public int Count { get; set; } = 10;
}