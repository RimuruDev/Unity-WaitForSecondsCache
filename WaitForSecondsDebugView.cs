// ReSharper disable InvertIf
// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Global

using UnityEngine;
using System.Collections.Generic;
using AbyssMoth.Internal.Codebase.Runtime._MainMenuModule.User;

namespace AbyssMoth
{
    // NOTE: Dependency (https://github.com/RimuruDev/MonoSingleton.git)
    public class WaitForSecondsDebugView : MonoSingleton<WaitForSecondsDebugView>
    {
#if UNITY_EDITOR
        [SerializeField] private bool enableDebugView = true;
        [SerializeField] private List<float> cachedTimes = new();

        public void AddEntry(float time)
        {
            if (!cachedTimes.Contains(time))
            {
                cachedTimes.Add(time);
                cachedTimes.Sort();
            }
        }

        public void RemoveEntry(float time) =>
            cachedTimes.Remove(time);

        private void OnGUI()
        {
            if (!enableDebugView)
                return;

            GUILayout.BeginArea(new Rect(10, 10, 300, 500));
            GUILayout.Label("WaitForSeconds Cache Debug View:");

            foreach (var time in cachedTimes)
                GUILayout.Label($"Time: {time} seconds");

            GUILayout.EndArea();
        }
#endif
    }
}
