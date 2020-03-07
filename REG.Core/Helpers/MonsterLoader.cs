using REG.Core.Abstractions.Services.Models.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace REG.Core.Helpers
{
    public sealed class MonsterLoader
    {
        public static MonsterLoader Instance { get; } = new MonsterLoader();
        static MonsterLoader()
        {
        }
        private MonsterLoader()
        {
            MonsterList = DeseraliazerJSON<Monster>("5e-SRD-Monsters.json");
        }
        public List<Monster> MonsterList { get; }
        public List<T> DeseraliazerJSON<T>(string fileName)
        {
            string json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/Jsons/" + fileName);
            return JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }
    }
}
