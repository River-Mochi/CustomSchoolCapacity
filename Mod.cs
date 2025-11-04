// Mod.cs
// Entry point for "Adjust School Capacity [ASC]".

namespace AdjustSchoolCapacity
{
    using Colossal.IO.AssetDatabase;
    using Colossal.Logging;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    public sealed class Mod : IMod
    {
        // ---- Constants ----
        public const string ModName = "Adjust School Capacity [ASC]";
        public const string VersionShort = "1.5.3";

        // ---- Logging ----
        public static readonly ILog Log =
            LogManager.GetLogger("AdjustSchoolCapacity").SetShowsErrorsInUI(false);

        // ---- Settings instance ----
        public static Setting? Setting
        {
            get; private set;
        }

        // ---- Lifecycle ----
        public void OnLoad(UpdateSystem updateSystem)
        {
            Log.Info($"{ModName} v{VersionShort} OnLoad");

            var setting = new Setting(this);
            Setting = setting;

            // Register locales
            var lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
                Log.Warn("LocalizationManager is null; skipping locale registration.");
            }
            else
            {
                lm.AddSource("en-US", new LocaleEN(setting));
                lm.AddSource("es-ES", new LocaleES(setting));
                lm.AddSource("fr-FR", new LocaleFR(setting));
                lm.AddSource("zh-HANS", new LocaleZH_CN(setting));
                lm.AddSource("de-DE", new LocaleDE(setting));
                lm.AddSource("it-IT", new LocaleIT(setting));
                lm.AddSource("ja-JP", new LocaleJA(setting));
                lm.AddSource("ko-KR", new LocaleKO(setting));
                lm.AddSource("zh-HANT", new LocaleZH_HANT(setting));
            }

            // Load saved settings, then show Options UI
            AssetDatabase.global.LoadSettings("AdjustSchoolCapacity", setting, new Setting(this));
            setting.RegisterInOptionsUI();

            // Ensure system runs during prefab phases so prefabs & school extensions scale before placement
            updateSystem.UpdateBefore<AdjustSchoolCapacitySystem>(SystemUpdatePhase.PrefabUpdate);
            updateSystem.UpdateBefore<AdjustSchoolCapacitySystem>(SystemUpdatePhase.PrefabReferences);
        }

        public void OnDispose()
        {
            if (Setting != null)
            {
                Setting.UnregisterInOptionsUI();
                Setting = null;
            }

            Log.Info("OnDispose");
        }
    }
}
