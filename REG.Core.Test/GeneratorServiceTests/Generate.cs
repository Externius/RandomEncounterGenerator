using REG.Core.Abstractions.Services;
using REG.Core.Abstractions.Services.Exceptions;
using REG.Core.Abstractions.Services.Models;
using REG.Core.Domain;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace REG.Core.Test.GeneratorServiceTests;

public class Generate
{
    [Fact]
    public void CanGenerate()
    {
        using var env = new TestEnvironment();
        var service = env.GetService<IEncounterService>();

        var option = new EncounterOption
        {
            PartyLevel = 1,
            PartySize = 5
        };

        var result = service.GenerateAsync(option).Result;

        result.ShouldNotBeNull();
    }

    [Fact]
    public void CanFilterWithMonsterTypes()
    {
        using var env = new TestEnvironment();
        var service = env.GetService<IEncounterService>();

        var option = new EncounterOption
        {
            PartyLevel = 4,
            MonsterTypes = new List<MonsterType> { MonsterType.Beast, MonsterType.Humanoid },
            PartySize = 5
        };

        var result = service.GenerateAsync(option).Result;

        result.ShouldNotBeNull();
        result.Encounters.ShouldNotBeNull();
        result.Encounters.Any(e => !option.MonsterTypes.Select(m => m.ToString().ToLower()).Any(e.Type.ToLower().Equals)).ShouldBeFalse();
    }

    [Fact]
    public void CanThrowException()
    {
        using var env = new TestEnvironment();
        var service = env.GetService<IEncounterService>();

        var option = new EncounterOption
        {
            PartyLevel = 1,
            PartySize = 1,
            MonsterTypes = new List<MonsterType> { MonsterType.Dragon },
            Difficulty = Difficulty.Easy
        };

        Should.Throw<ServiceException>(async () =>
        {
            await service.GenerateAsync(option);
        });
    }
}