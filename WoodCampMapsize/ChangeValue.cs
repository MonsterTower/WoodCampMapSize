using Verse;

namespace WoodCampMapsize
{
    [StaticConstructorOnStartup]
    public static class ChangeValue
    {
        static ChangeValue()
        {
            Main.Instance.settings.ChangeValuesOfGame();
        }
    }
}