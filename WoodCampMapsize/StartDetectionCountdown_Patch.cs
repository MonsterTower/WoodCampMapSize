using HarmonyLib;
using RimWorld.Planet;
using Verse;

namespace WoodCampMapsize
{
    [StaticConstructorOnStartup]
    public class StartDetectionCountdown_Patch
    {
        [HarmonyPatch(typeof(TimedDetectionRaids), "StartDetectionCountdown")]
        private static class Fix
        {
            [HarmonyPrefix]
            public static void Prefix(TimedDetectionRaids __instance,ref int ticks,ref int notifyTicks)
            {
                if (__instance.parent.def.defName == "Camp")
                {
                    var settings = Main.Instance.settings;
                    if (settings.disableRaid)
                    {
                        ticks = -1;
                        notifyTicks = -1;
                    }
                    else
                    {
                        var raid = settings.raidDelayRange;
                        ticks = Rand.RangeInclusive(raid.min,raid.max) * Setting.hour;
                        var notify = settings.notifyDelayRange;
                        notifyTicks = Rand.RangeInclusive(notify.min, notify.max) * Setting.hour;
                    }
                }
            }
        }
    }
}