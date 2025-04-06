namespace REG.Core.Abstractions.Services.Models;

public class EncounterModel
{
    public int SumXp { get; set; }
    public List<EncounterDetail> Encounters { get; set; } = [];
}