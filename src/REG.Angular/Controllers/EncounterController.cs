using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using REG.Core.Abstractions.Services;
using REG.Core.Abstractions.Services.Models;
using REG.Core.Domain;

namespace REG.Angular.Controllers;

[ApiController]
[EnableCors("default")]
[Route("api/[controller]")]
public class EncounterController(IEncounterService encounterService, ILogger<EncounterController> logger)
    : ControllerBase
{
    private readonly ILogger<EncounterController> _logger = logger;
    private readonly IEncounterService _encounterService = encounterService;

    [HttpPost]
    public async Task<EncounterModel> Generate([FromBody] EncounterOption option)
    {
        return await _encounterService.GenerateAsync(option);
    }

    [HttpGet("monstertypes")]
    public async Task<ICollection<KeyValuePair<string, int>>> GetMonsterTypes()
    {
        return await _encounterService.GetEnumListAsync<MonsterType>();
    }

    [HttpGet("difficulties")]
    public async Task<ICollection<KeyValuePair<string, int>>> GetDifficulties()
    {
        return await _encounterService.GetEnumListAsync<Difficulty>();
    }

    [HttpGet("sizes")]
    public async Task<ICollection<KeyValuePair<string, int>>> GetSizes()
    {
        return await _encounterService.GetEnumListAsync<Size>();
    }
}