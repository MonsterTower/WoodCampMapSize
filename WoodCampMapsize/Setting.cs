using RimWorld;
using Verse;
// ReSharper disable InconsistentNaming

namespace WoodCampMapsize
{
    public class Setting : ModSettings
    {
        public       int mapSize     = 200;
        public const int mapSize_min = 50;
        public const int mapSize_max = 300;

        public bool disableRaid = false;
        
        public       IntRange notifyDelayRange     = new IntRange(notifyDelayRange_min, notifyDelayRange_max);
        public const int      hour                 = 2500;
        public const int      notifyDelayRange_min = 60000 / hour;
        public const int      notifyDelayRange_max = 60000 / hour;
        public       IntRange raidDelayRange       = new IntRange(raidDelayRange_min, raidDelayRange_max);
        public const int      raidDelayRange_min   = 240000 / hour;
        public const int      raidDelayRange_max   = 240000 / hour;

        private static int?       compInitSize = 200;
           
        public void ResetValues()
        {
            mapSize = compInitSize.Value;
            disableRaid = false;
            notifyDelayRange = new IntRange(notifyDelayRange_min, notifyDelayRange_max);
            raidDelayRange = new IntRange(raidDelayRange_min, raidDelayRange_max);
        }
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref mapSize, "mapSize", 200);
            Scribe_Values.Look(ref disableRaid,"disableRaid",false);
            Scribe_Values.Look(ref notifyDelayRange, "wrningDelayRange", new IntRange(notifyDelayRange_min, notifyDelayRange_max));
            Scribe_Values.Look(ref raidDelayRange, "raidDelayRange", new IntRange(raidDelayRange_min, raidDelayRange_max));
        }
        public void ChangeValuesOfGame()
        {
            var camp = DefDatabase<WorldObjectDef>.GetNamed("Camp");
            if (compInitSize == null)
            {
                compInitSize = camp.overrideMapSize.Value.x;
            }
            camp.overrideMapSize = new IntVec3(mapSize, 1, mapSize);
        }
    }
}