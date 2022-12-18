using REG.Core.Abstractions.Services.Models.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace REG.Core.Helpers;

public sealed class MonsterLoader
{
    public static MonsterLoader Instance { get; } = new();
    static MonsterLoader()
    {
    }
    private MonsterLoader()
    {
        MonsterList = DeseraliazerJson<Monster>("5e-SRD-Monsters.json");
    }
    public List<Monster> MonsterList { get; }
    public List<T> DeseraliazerJson<T>(string fileName)
    {
        var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/Jsons/" + fileName);
        return JsonSerializer.Deserialize<List<T>>(json);
    }
}