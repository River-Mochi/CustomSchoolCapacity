// Mod.cs
// Entry point for "Adjust School Capacity [ASC]".

namespace AdjustSchoolCapacity
{
    using System.Reflection;
    using Colossal.IO.AssetDatabase;
    using Colossal.Logging;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    public sealed class Mod : IMod
    {
        // ---- PUBLIC CONSTANTS / METADATA ----
        public const string ModName = "Adjust School Capacity";
        public const string ModId = "AdjustSchoolCapacity";
        public const string ModTag = "[ASC]";

        // ---- PRIVATE STATE ----
        private static bool s_BannerLogged;

        /// <summary>
        /// Read &lt;Version&gt; from .csproj (3-part).
        /// </summary>
        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        // ---- Logging ----
        public static readonly ILog s_Log =
            LogManager.GetLogger("AdjustSchoolCapacity").SetShowsErrorsInUI(false);

        // ---- Settings instance ----
        public static Setting? Setting
        {
            get; private set;
        }

        // ---- Lifecycle ----
        public void OnLoad(UpdateSystem updateSystem)
        {
            // Metadata banner (once per session).
            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                s_Log.Info($"{ModName} {ModTag} v{ModVersion} OnLoad");
            }

            Setting setting = new Setting(this);
            Setting = setting;

            // Register locales
            if (GameManager.instance?.localizationManager == null)
            {
                s_Log.Warn("LocalizationManager is null; skipping locale registration.");
            }
            else
            {
                GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(setting));
                GameManager.instance.localizationManager.AddSource("es-ES", new LocaleES(setting));
                GameManager.instance.localizationManager.AddSource("fr-FR", new LocaleFR(setting));
                GameManager.instance.localizationManager.AddSource("de-DE", new LocaleDE(setting));
                GameManager.instance.localizationManager.AddSource("it-IT", new LocaleIT(setting));
                GameManager.instance.localizationManager.AddSource("ja-JP", new LocaleJA(setting));
                GameManager.instance.localizationManager.AddSource("ko-KR", new LocaleKO(setting));
                GameManager.instance.localizationManager.AddSource("pl-PL", new LocalePL(setting));
                GameManager.instance.localizationManager.AddSource("pt-BR", new LocalePT_BR(setting));
                GameManager.instance.localizationManager.AddSource("pt-PT", new LocalePT_PT(setting));
                GameManager.instance.localizationManager.AddSource("zh-HANS", new LocaleZH_CN(setting));
                GameManager.instance.localizationManager.AddSource("zh-HANT", new LocaleZH_HANT(setting));
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

            s_Log.Info("OnDispose");
        }
    }
}
