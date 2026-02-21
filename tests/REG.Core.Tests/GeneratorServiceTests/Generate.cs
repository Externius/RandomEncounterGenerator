using REG.Core.Abstractions.Services;
using REG.Core.Abstractions.Services.Exceptions;
using REG.Core.Abstractions.Services.Models;
using REG.Core.Abstractions.Services.Models.Json;
using REG.Core.Domain;
using REG.Core.Services;
using Shouldly;
using Xunit;

namespace REG.Core.Tests.GeneratorServiceTests;

public class Generate(TestFixture fixture) : IClassFixture<TestFixture>
{
    private readonly IEncounterService _encounterService = fixture.EncounterService;

    [Fact]
    public async Task CanGenerate()
    {
        var option = new EncounterOption
        (
            1,
            5,
            null,
            [],
            [],
            15
        );

        var result = await _encounterService.GenerateAsync(option);

        result.ShouldNotBeNull();
        result.Encounters.Length.ShouldBe(option.Count);
    }

    [Theory]
    [MemberData(nameof(EncounterOptionData.Data), MemberType = typeof(EncounterOptionData))]
    public async Task CanFilter(EncounterOption option)
    {
        var encounterModel = await _encounterService.GenerateAsync(option);

        encounterModel.ShouldNotBeNull();
        encounterModel.Encounters.ShouldNotBeEmpty();
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
        var option = new EncounterOption
        (
            partyLevel,
            partySize,
            difficulty,
            [MonsterType.Beast, MonsterType.Humanoid, MonsterType.SwarmOfTinyBeasts],
            []
        );

        var encounterModel = await _encounterService.GenerateAsync(option);

        encounterModel.ShouldNotBeNull();
        encounterModel.Encounters.ShouldNotBeEmpty();
        encounterModel.Encounters.ShouldAllBe(e => e.Difficulty.Equals(difficulty.ToString()));
    }

    [Fact]
    public async Task CanThrowException()
    {
        var option = new EncounterOption
        (
            1,
            1,
            Difficulty.Easy,
            [MonsterType.Dragon],
            []
        );

        await Should.ThrowAsync<ServiceException>(async () => { await _encounterService.GenerateAsync(option); });
    }

    [Fact]
    public void CanDeserializeJson()
    {
        var result = _encounterService.DeserializeJson<Monster>();

        result.ShouldNotBeNull();
        result.Count.ShouldBeGreaterThan(0);
    }
}