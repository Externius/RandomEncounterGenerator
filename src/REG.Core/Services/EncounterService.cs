using Microsoft.Extensions.Logging;
using REG.Core.Abstractions.Services;
using REG.Core.Abstractions.Services.Exceptions;
using REG.Core.Abstractions.Services.Models;
using REG.Core.Abstractions.Services.Models.Json;
using REG.Core.Domain;
using System.Text.Json;

namespace REG.Core.Services;

public class EncounterService(ILogger<EncounterService> logger) : IEncounterService
{
    private readonly ILogger _logger = logger;

    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private const string MonstersFileName = "5e-SRD-Monsters.json";

    private static readonly int[] ChallengeRatingXp =
    [
        10,
        25,
        50,
        100,
        200,
        450,
        700,
        1100,
        1800,
        2300,
        2900,
        3900,
        5000,
        5900,
        7200,
        8400,
        10000,
        11500,
        13000,
        15000,
        18000,
        20000,
        22000,
        25000,
        33000,
        41000,
        50000,
        62000,
        75000,
        90000,
        105000,
        120000,
        135000,
        155000
    ];

    private static readonly double[,] Multipliers =
    {
        { 1, 1 },
        { 2, 1.5 },
        { 3, 2 },
        { 7, 2.5 },
        { 11, 3 },
        { 15, 4 }
    };

    private static readonly List<string> ChallengeRating =
    [
        "0", "1/8", "1/4", "1/2", "1", "2", "3", "4", "5",
        "6", "7", "8", "9", "10", "11", "12", "13", "14", "15",
        "16", "17", "18", "19", "20", "21", "22", "23", "24", "25",
        "26", "27", "28", "29", "30"
    ];

    private static readonly int[,] Thresholds =
    {
        { 0, 0, 0, 0 },
        { 25, 50, 75, 100 },
        { 50, 100, 150, 200 },
        { 75, 150, 225, 400 },
        { 125, 250, 375, 500 },
        { 250, 500, 750, 1100 },
        { 300, 600, 900, 1400 },
        { 350, 750, 1100, 1700 },
        { 450, 900, 1400, 2100 },
        { 550, 1100, 1600, 2400 },
        { 600, 1200, 1900, 2800 },
        { 800, 1600, 2400, 3600 },
        { 1000, 2000, 3000, 4500 },
        { 1100, 2200, 3400, 5100 },
        { 1250, 2500, 3800, 5700 },
        { 1400, 2800, 4300, 6400 },
        { 1600, 3200, 4800, 7200 },
        { 2000, 3900, 5900, 8800 },
        { 2100, 4200, 6300, 9500 },
        { 2400, 4900, 7300, 10900 },
        { 2800, 5700, 8500, 12700 }
    };

    private ICollection<Monster> _monsters = [];
    private int _partyLevel;
    private int _partySize;
    private ICollection<KeyValuePair<Difficulty, int>> _xpList = [];

    public async Task<ICollection<KeyValuePair<string, int>>> GetEnumListAsync<T>() where T : struct
    {
        if (!typeof(T).IsEnum)
            throw new InvalidOperationException("Type parameter must be Enum.");

        return await Task.Run(() =>
            (from object e in Enum.GetValues(typeof(T))
                select new KeyValuePair<string, int>((e as Enum)
                    .GetName(Resources.Enum.ResourceManager), (int)e))
            .ToList());
    }

    public ICollection<T> DeserializeJson<T>(string? jsonFilePath = null)
    {
        var json = jsonFilePath is not null
            ? File.ReadAllText(jsonFilePath)
            : File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/Jsons/" + MonstersFileName);
        return JsonSerializer.Deserialize<List<T>>(json, _jsonSerializerOptions) ?? [];
    }

    public async Task<EncounterModel> GenerateAsync(EncounterOption option)
    {
        ValidateOption(option);
        _partyLevel = option.PartyLevel;
        _partySize = option.PartySize;
        _xpList =
        [
            new KeyValuePair<Difficulty, int>(Difficulty.Easy, Thresholds[_partyLevel, 0] * _partySize),
            new KeyValuePair<Difficulty, int>(Difficulty.Medium, Thresholds[_partyLevel, 1] * _partySize),
            new KeyValuePair<Difficulty, int>(Difficulty.Hard, Thresholds[_partyLevel, 2] * _partySize),
            new KeyValuePair<Difficulty, int>(Difficulty.Deadly, Thresholds[_partyLevel, 3] * _partySize)
        ];
        try
        {
            _monsters = DeserializeJson<Monster>();
            var sumXp = CalcSumXp((int)Difficulty.Deadly);
            var monsterXps = new SortedSet<int>();

            if (option.MonsterTypes.Any())
            {
                var selectedMonsters = option.MonsterTypes.Select(m => m.ToString().ToLower());
                _monsters = [.. _monsters.Where(m => selectedMonsters.Any(m.Type.ToLower().Equals))];
            }

            if (option.Sizes.Any())
            {
                var selectedSizes = option.Sizes.Select(s => s.ToString().ToLower());
                _monsters = [.. _monsters.Where(m => selectedSizes.Any(m.Size.ToLower().Equals))];
            }

            if (option.Difficulty.HasValue)
                sumXp = Thresholds[option.PartyLevel, (int)option.Difficulty.Value] * option.PartySize;

            foreach (var monster in _monsters)
            {
                monsterXps.Add(ChallengeRatingXp[ChallengeRating.IndexOf(monster.ChallengeRating)]);
            }

            CheckPossible(sumXp, monsterXps);

            var result = new EncounterModel();
            var maxTryNumber = 5000;
            await Task.Run(() =>
            {
                while (result.Encounters.Count < option.Count && maxTryNumber > 0)
                {
                    try
                    {
                        var monster = GetMonster(option.Difficulty);
                        if (monster is not null)
                            result.Encounters.Add(monster);
                        maxTryNumber--;
                    }
                    catch (ServiceException)
                    {
                        maxTryNumber--;
                    }
                }
            });

            result.SumXp = result.Encounters.Sum(ed => ed.Xp);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Generate encounter failed.");
            throw new ServiceException(ex.Message, ex);
        }
    }

    private int CalcSumXp(int difficulty)
    {
        return Thresholds[_partyLevel, difficulty] * _partySize;
    }

    private static void ValidateOption(EncounterOption? option)
    {
        var exceptions = new List<ServiceException>();

        if (option is null)
            exceptions.Add(new ServiceException(ServiceException.EntityNotFoundException));
        if (option?.PartyLevel == 0)
            exceptions.Add(new ServiceException(ServiceException.RequiredValidation, "partyLevel"));
        if (option?.PartySize == 0)
            exceptions.Add(new ServiceException(ServiceException.RequiredValidation, "partySize"));

        if (exceptions.Count != 0)
            throw new ServiceAggregateException(exceptions);
    }

    private static void CheckPossible(int sumXp, IReadOnlyCollection<int> monsterXps)
    {
        if (monsterXps.Count != 0 && sumXp > monsterXps.First())
            return;
        throw new ServiceException(ServiceException.EncounterNotPossible);
    }

    private static int GetMonsterXp(Monster monster)
    {
        return ChallengeRatingXp[ChallengeRating.IndexOf(monster.ChallengeRating)];
    }

    private static int GetRandomInt(int min, int max)
    {
        if (max != min)
            return ThreadSafeRandom.ThisThreadsRandom.Next(max - min) + min;
        return max;
    }

    private EncounterDetail? GetMonster(Difficulty? difficulty = null)
    {
        var monsterCount = _monsters.Count;
        var monster = 0;
        var indexes = new List<int>(Enumerable.Range(0, Multipliers.GetLength(0)));

        while (monster < monsterCount)
        {
            var currentMonster = _monsters.ElementAt(GetRandomInt(0, _monsters.Count));
            _monsters.Remove(currentMonster);
            var monsterXp = GetMonsterXp(currentMonster);
            indexes.Shuffle();

            if (difficulty.HasValue)
            {
                var difficultyXp = _xpList.First(l => l.Key == difficulty.Value).Value;
                foreach (var i in indexes)
                {
                    var count = (int)Multipliers[i, 0];
                    var allXp = monsterXp * count * Multipliers[i, 1];
                    if (allXp < difficultyXp ||
                        _xpList.OrderByDescending(l => l.Value).First(l => allXp >= l.Value).Key != difficulty)
                        continue;

                    return GetEncounterDetail(difficulty.Value, currentMonster, (int)allXp, count);
                }
            }
            else
            {
                foreach (var i in indexes)
                {
                    var count = (int)Multipliers[i, 0];
                    var allXp = monsterXp * count * Multipliers[i, 1];
                    var difficulties = _xpList.Where(xp => allXp <= xp.Value).Select(xp => xp.Key).AsQueryable();
                    if (difficulties.Any())
                        return GetEncounterDetail(difficulties.First(), currentMonster, (int)allXp, count);
                }
            }

            monster++;
        }

        return null;
    }

    private static EncounterDetail GetEncounterDetail(Difficulty difficulty, Monster currentMonster, int allXp,
        int count)
    {
        var encounterDetail = new EncounterDetail
        {
            Xp = allXp,
            Count = count,
            Difficulty = difficulty.GetName(Resources.Enum.ResourceManager),
            Size = Enum.Parse<Size>(currentMonster.Size).GetName(Resources.Enum.ResourceManager),
            Name = currentMonster.Name,
            Type = currentMonster.Type,
            ChallengeRating = currentMonster.ChallengeRating,
            Alignment = currentMonster.Alignment ?? string.Empty,
            HitDice = currentMonster.HitDice ?? string.Empty,
            Speed = currentMonster.Speed ?? string.Empty,
            Senses = currentMonster.Senses ?? string.Empty,
            Languages = currentMonster.Languages ?? string.Empty,
            Ac = currentMonster.ArmorClass ?? 0,
            Actions = currentMonster.Actions,
            Charisma = currentMonster.Charisma ?? 0,
            CharismaSave = currentMonster.CharismaSave ?? 0,
            ConditionImmunities = currentMonster.ConditionImmunities,
            Constitution = currentMonster.Constitution ?? 0,
            ConstitutionSave = currentMonster.ConstitutionSave ?? 0,
            DamageImmunities = currentMonster.DamageImmunities,
            DamageResistances = currentMonster.DamageResistances,
            DamageVulnerabilities = currentMonster.DamageVulnerabilities,
            Dexterity = currentMonster.Dexterity ?? 0,
            DexteritySave = currentMonster.DexteritySave ?? 0,
            History = currentMonster.History ?? 0,
            Hp = currentMonster.HitPoints ?? 0,
            Intelligence = currentMonster.Intelligence ?? 0,
            IntelligenceSave = currentMonster.IntelligenceSave ?? 0,
            LegendaryActions = currentMonster.LegendaryActions,
            Perception = currentMonster.Perception ?? 0,
            Reactions = currentMonster.Reactions,
            SpecialAbilities = currentMonster.SpecialAbilities,
            Strength = currentMonster.Strength ?? 0,
            StrengthSave = currentMonster.StrengthSave ?? 0,
            Wisdom = currentMonster.Wisdom ?? 0,
            WisdomSave = currentMonster.WisdomSave ?? 0
        };

        if (Enum.TryParse(encounterDetail.Type, out MonsterType type))
            encounterDetail.Type = type.GetName(Resources.Enum.ResourceManager);

        return encounterDetail;
    }
}