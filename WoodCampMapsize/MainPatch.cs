using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;
using Verse;

namespace WoodCampMapsize
{
    public class MainPatch
    {
        [UsedImplicitly]
        [StaticConstructorOnStartup]
        public class PatchMain
        {
            static PatchMain()
            {
                Harmony harmony = new Harmony("WoodCampMapsize_HarmonyPatch");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
        }
    }
}