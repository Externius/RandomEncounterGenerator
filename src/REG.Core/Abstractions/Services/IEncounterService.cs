using REG.Core.Abstractions.Services.Models;

namespace REG.Core.Abstractions.Services;

public interface IEncounterService
{
    Task<EncounterModel> GenerateAsync(EncounterOption option);
    Task<ICollection<KeyValuePair<string, int>>> GetEnumListAsync<T>() where T : struct;
    ICollection<T> DeserializeJson<T>(string? jsonFilePath = null);
}