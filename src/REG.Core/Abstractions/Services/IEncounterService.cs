using REG.Core.Abstractions.Services.Models;

namespace REG.Core.Abstractions.Services;

public interface IEncounterService
{
    Task<EncounterModel> GenerateAsync(EncounterOption option);
    Task<KeyValuePair<string, int>[]> GetEnumListAsync<T>() where T : struct;
    List<T> DeserializeJson<T>(string? jsonFilePath = null);
}