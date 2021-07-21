using HarmonyLib;

namespace Fast_Asleep
{
    public class Patches
    {
        [HarmonyPatch(typeof(Sleepable), "OnStartWork")]
        public class Sleepable_OnStartWork_Patch
        {
            public static void Prefix(Sleepable __instance)
            {
                FastAsleepMonitor.OnSleepStarted(__instance);
            }
        }

        [HarmonyPatch(typeof(Sleepable), "OnStopWork")]
        public class Sleepable_OnFinishWork_Patch
        {
            public static void Prefix(Sleepable __instance)
            {
                FastAsleepMonitor.OnSleepFinished(__instance);
            }
        }
    }
}
