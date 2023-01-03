using REG.Core.Abstractions.Services;
using REG.Core.Abstractions.Services.Exceptions;
using REG.Core.Abstractions.Services.Models;
using REG.Core.Abstractions.Services.Models.Json;
using REG.Core.Domain;
using REG.Core.Services;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace REG.Core.Tests.GeneratorServiceTests;

public class Generate
{
    [Fact]
    public async Task CanGenerate()
    {
        using var env = new TestEnvironment();
        var service = env.GetService<IEncounterService>();

        var option = new EncounterOption
        {
            PartyLevel = 1,
            PartySize = 5
        };

        var result = await service.GenerateAsync(option);

        result.ShouldNotBeNull();
        result.Encounters.Count.ShouldBe(option.Count);
    }

    [Theory]
    [MemberData(nameof(EncounterOptionData.Data), MemberType = typeof(EncounterOptionData))]
    public async Task CanFilter(EncounterOption option)
    {
        using var env = new TestEnvironment();
        var service = env.GetService<IEncounterService>();
        var encounterModel = await service.GenerateAsync(option);

        encounterModel.ShouldNotBeNull();
        encounterModel.Encounters.ShouldNotBeNull();
        var resultMonsterTypes = encounterModel.Encounters.Select(ed => ed.Type.ToLower()).Distinct();
        var resultMonsterSizes = encounterModel.Encounters.Select(ed => ed.Size.ToLower()).Distinct();
        var optionMonsterTypes = option.MonsterTypes.Select(m => m.GetName(Resources.Enum.ResourceManager).ToLower());
        var optionMonsterSizes = option.Sizes.Select(m => m.GetName(Resources.Enum.ResourceManager).ToLower());
        resultMonsterTypes.Except(optionMonsterTypes).Count().ShouldBe(0);
        resultMonsterSizes.Except(optionMonsterSizes).Count().ShouldBe(0);
    }

    [Theory]
    [MemberData(nameof(EncounterOptionData.FilterWithDifficultyData), MemberType = typeof(EncounterOptionData))]
    public async Task CanFilterWithDifficulty(Difficulty difficulty, int partyLevel, int partySize)
    {
        using var env = new TestEnvironment();
        var service = env.GetService<IEncounterService>();

        var option = new EncounterOption
        {
            PartyLevel = partyLevel,
            MonsterTypes = new List<MonsterType> { MonsterType.Beast, MonsterType.Humanoid, MonsterType.SwarmOfTinyBeasts },
            PartySize = partySize,
            Difficulty = difficulty
        };

        var encounterModel = await service.GenerateAsync(option);

        encounterModel.ShouldNotBeNull();
        encounterModel.Encounters.ShouldNotBeNull();
        encounterModel.Encounters.All(e => e.Difficulty.Equals(difficulty.ToString())).ShouldBeTrue();
    }

    [Fact]
    public async Task CanThrowException()
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

        await Should.ThrowAsync<ServiceException>(async () =>
        {
            await service.GenerateAsync(option);
        });
    }

    [Fact]
    public void CanDeserializeJson()
    {
        using var env = new TestEnvironment();
        var service = env.GetService<IEncounterService>();

        var result = service.DeserializeJson<Monster>();

        result.ShouldNotBeNull();
        result.Count.ShouldBeGreaterThan(0);
    }
}