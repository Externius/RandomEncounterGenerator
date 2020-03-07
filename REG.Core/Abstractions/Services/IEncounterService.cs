using REG.Core.Abstractions.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace REG.Core.Abstractions.Services
{
    public interface IEncounterService
    {
        Task<EncounterModel> GenerateAsync(EncounterOption option);
        Task<List<KeyValuePair<string, int>>> GetEnumListAsync<T>() where T : struct;
    }
}
