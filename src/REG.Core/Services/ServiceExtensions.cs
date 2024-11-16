using System;
using System.Collections.Generic;
using System.Resources;

namespace REG.Core.Services;

public static class ThreadSafeRandom
{
    [ThreadStatic] private static Random _local;

    public static Random ThisThreadsRandom
    {
        get
        {
            return _local ??= new Random(unchecked(Environment.TickCount * 31 + Environment.CurrentManagedThreadId));
        }
    }
}

public static class ServiceExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }

    public static string GetName(this Enum value, ResourceManager resourceManager, string defaultValue = null)
    {
        if (value is null)
            return string.Empty;

        if (resourceManager is null)
            return value.ToString();

        var resourceKey = $"{value.GetType().Name}_{value}";
        return resourceManager.GetString(resourceKey) ?? defaultValue ?? value.ToString();
    }
}