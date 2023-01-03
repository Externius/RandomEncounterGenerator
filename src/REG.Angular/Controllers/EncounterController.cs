using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using REG.Core.Abstractions.Services;
using REG.Core.Abstractions.Services.Models;
using REG.Core.Domain;

namespace REG.Angular.Controllers;

[ApiController]
[EnableCors("default")]
[Route("api/[controller]")]
public class EncounterController : ControllerBase
{
    private readonly ILogger<EncounterController> _logger;
    private readonly IEncounterService _encounterService;
    public EncounterController(IEncounterService encounterService, ILogger<EncounterController> logger)
    {
        _logger = logger;
        _encounterService = encounterService;
    }

    [HttpPost]
    public async Task<EncounterModel> Generate([FromBody] EncounterOption option)
    {
        return await _encounterService.GenerateAsync(option);
    }

    [HttpGet("monstertypes")]
    public async Task<List<KeyValuePair<string, int>>> GetMonsterTypes()
    {
        return await _encounterService.GetEnumListAsync<MonsterType>();
    }

    [HttpGet("difficulties")]
    public async Task<List<KeyValuePair<string, int>>> GetDifficulties()
    {
        return await _encounterService.GetEnumListAsync<Difficulty>();
    }

    [HttpGet("sizes")]
    public async Task<List<KeyValuePair<string, int>>> GetSizes()
    {
        return await _encounterService.GetEnumListAsync<Size>();
    }
}