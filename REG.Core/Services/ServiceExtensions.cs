using System;
using System.Collections.Generic;
using System.Resources;
using System.Threading;

namespace REG.Core.Services
{
    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ??= new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)); }
        }
    }
    static class ServiceExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public static string GetName(this Enum value, ResourceManager resourceManager, string defaultValue = null)
        {
            if (value is null)
                return "";

            if (resourceManager == null)
                return value.ToString();

            var resourceKey = string.Format("{0}_{1}", value.GetType().Name, value);
            return resourceManager.GetString(resourceKey) ?? (defaultValue ?? value.ToString());
        }
    }
}
