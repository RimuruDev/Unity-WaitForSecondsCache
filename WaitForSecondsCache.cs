// ReSharper disable InvertIf
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

using UnityEngine;
using System.Collections.Generic;

namespace AbyssMoth
{
    public static class WaitForSecondsCache
    {
        private static readonly Dictionary<float, WaitForSeconds> cache = new();

        public static IReadOnlyDictionary<float, WaitForSeconds> GetCache() => cache;

        public static WaitForSeconds Get(float time)
        {
            if (!cache.TryGetValue(time, out var waitForSeconds))
            {
                waitForSeconds = new WaitForSeconds(time);
                cache[time] = waitForSeconds;

#if UNITY_EDITOR
                // NOTE: Exclusively for displaying the contents of the storage on the screen.
                // Dependency: MonoSingleton (https://github.com/RimuruDev/MonoSingleton.git)
                WaitForSecondsDebugView.Instance?.AddEntry(time);
#endif
            }

            return waitForSeconds;
        }

        public static void Reset() => cache.Clear();
    }
}
