// Localization/LocaleEN.cs
// English strings for "Custom School Capacity [CSC] " - Options UI.

namespace CustomSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod root in Options
                { m_Setting.GetSettingsLocaleID(), "Custom School Capacity [CSC]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "About"   },

                // Groups (Actions)
                { m_Setting.GetOptionGroupLocaleID(Setting.CapacityGroup), "Student Capacity" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PresetGroup),   "Presets" },
                { m_Setting.GetOptionGroupLocaleID(Setting.OptionsGroup),  "Options" },

                // Groups (About)
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),  "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Support Links" },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElementarySlider)), "Elementary" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ElementarySlider)),  "Set elementary school capacity relative to vanilla (10–500%)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HighSchoolSlider)), "High School" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.HighSchoolSlider)),  "Set high school capacity relative to vanilla (10–500%)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CollegeSlider)), "College" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CollegeSlider)),  "Set college capacity relative to vanilla (10–500%)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UniversitySlider)), "University" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UniversitySlider)),  "Set university capacity relative to vanilla (10–500%)." },

                // Checkbox
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ScaleUpkeepWithCapacity)), "Scale upkeep with capacity" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ScaleUpkeepWithCapacity)),
                  "If enabled, maintenance / upkeep is multiplied by the same % as capacity.\n" +
                  "Example: 50% capacity → ~50% upkeep. 200% capacity → ~200% upkeep." },

                // Preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Reset to Vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),  "Bring all capacity sliders back to 100% (game default)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefault)), "Reset to CSC defaults" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefault)),  "Set to CSC recommended values: 200 / 130 / 120 / 120." },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),     "Display name of this mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),  "Current mod version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "Open the Paradox Mods page in your browser." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)),     "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),      "Open the modding Discord in your browser." },
            };
        }

        public void Unload()
        {
        }
    }
}
