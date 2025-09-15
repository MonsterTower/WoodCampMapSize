using UnityEngine;
using Verse;

namespace WoodCampMapsize
{
    public class Main : Mod
    {
        public Main(ModContentPack content) : base(content)
        {
            settings = GetSettings<Setting>();
            Instance = this;
        }
        public Setting settings;
        public static Main Instance { get; private set; }
        public override string SettingsCategory() => "Wood Camp Map size";
        public override void WriteSettings()
        {
            base.WriteSettings();
            settings.ChangeValuesOfGame();
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard ls = new Listing_Standard();
            ls.Begin(inRect);
            ls.GapLine(20f);
            Text.Font = GameFont.Medium;
            if (ls.ButtonTextLabeledPct("RestoreToDefaultSettingsLabel".Translate(), "RestoreToDefaultSettings".Translate(), 0.6f, TextAnchor.MiddleLeft))
            {
                settings.ResetValues();
            }
            ls.GapLine(10f);
            int val = settings.mapSize;
            settings.mapSize = Mathf.RoundToInt(ls.SliderLabeled("Camp地图尺寸:{0}".Translate(val.ToString()), val, Setting.mapSize_min, Setting.mapSize_max));
            
            ls.CheckboxLabeled("禁用营地袭击",ref settings.disableRaid);
            if (!settings.disableRaid)
            {
                ls.Label("袭击警告推迟范围");
                ls.IntRange(ref settings.notifyDelayRange, Setting.notifyDelayRange_min / 4, Setting.notifyDelayRange_max * 20);
                ls.Label("袭击触发推迟范围");
                ls.IntRange(ref settings.raidDelayRange, Setting.raidDelayRange_min / 4, Setting.raidDelayRange_max * 20);
            }
            Text.Font = GameFont.Small;
            ls.End();
        }
    }
}