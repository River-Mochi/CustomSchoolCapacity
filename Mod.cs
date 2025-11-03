// Mod.cs
// Entry point for "Custom School Capacity [CSC]".

namespace CustomSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;
    using Colossal.IO.AssetDatabase;
    using Colossal.Logging;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    public sealed class Mod : IMod
    {
        public const string ModName = "Custom School Capacity [CSC]";
        public const string VersionShort = "1.3.0";

        public static readonly ILog Log =
            LogManager.GetLogger("CustomSchoolCapacity").SetShowsErrorsInUI(false);

        public static Setting? Setting
        {
            get; private set;
        }

        // guards so we don't add the same locale twice
        private static readonly HashSet<string> s_InstalledLocales = new();

        public void OnLoad(UpdateSystem updateSystem)
        {
            Log.Info($"{ModName} v{VersionShort} OnLoad");

            // 1) create settings
            var setting = new Setting(this);
            Setting = setting;

            // 2) add ONLY English for now
            AddLocale("en-US", new LocaleEN(setting));
            // (we'll re-enable FR/ES/ZH later)

            // 3) load saved values
            AssetDatabase.global.LoadSettings("CustomSchoolCapacity", setting, new Setting(this));

            // 4) show in Options UI
            setting.RegisterInOptionsUI();

            // 5) make sure our system runs in prefab phases (same pattern as original)
            updateSystem.UpdateBefore<CustomSchoolCapacitySystem>(SystemUpdatePhase.PrefabUpdate);
            updateSystem.UpdateBefore<CustomSchoolCapacitySystem>(SystemUpdatePhase.PrefabReferences);

            // 6) listen for locale changes
            var lm = GameManager.instance?.localizationManager;
            if (lm != null)
            {
                lm.onActiveDictionaryChanged -= OnLocaleChanged;
                lm.onActiveDictionaryChanged += OnLocaleChanged;
            }
        }

        public void OnDispose()
        {
            var lm = GameManager.instance?.localizationManager;
            if (lm != null)
            {
                lm.onActiveDictionaryChanged -= OnLocaleChanged;
            }

            if (Setting != null)
            {
                Setting.UnregisterInOptionsUI();
                Setting = null;
            }

            Log.Info("OnDispose");
        }

        private void OnLocaleChanged()
        {
            var lm = GameManager.instance?.localizationManager;
            var active = lm?.activeLocaleId;
            if (string.IsNullOrEmpty(active))
            {
                return;
            }

            EnsureLocaleInstalled(active!);

            // keep options refreshed
            Setting?.RegisterInOptionsUI();
#if DEBUG
            Log.Info($"[CSC] Locale changed → {active}");
#endif
        }

        private static void AddLocale(string localeId, IDictionarySource source)
        {
            var lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
                Log.Warn("No LocalizationManager; cannot add locale source.");
                return;
            }

            if (!s_InstalledLocales.Add(localeId))
            {
                return; // already added
            }

            lm.AddSource(localeId, source);
        }

        private static void EnsureLocaleInstalled(string localeId)
        {
            // right now EN is the only active one
            // later,  un-comment zh-HANS in Mod.cs, can add here
        }
    }
}
