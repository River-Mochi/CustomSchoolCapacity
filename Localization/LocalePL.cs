// Localization/LocalePL.cs
// Polish (pl-PL) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocalePL : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePL(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "Dostosuj Pojemność Szkół [ASC]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Opcje" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "O modzie" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(Setting.CapacityGroup), "Pojemność uczniów" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PresetGroup),   "Presety" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),  "Informacje" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Linki wsparcia" },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElementarySlider)), "Szkoła podstawowa" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElementarySlider)),
                    "**Szkoła podstawowa** – dostosuj pojemność od 10% do 500% suwakiem.\n" +
                    "100% = domyślna pojemność gry."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HighSchoolSlider)), "Liceum" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HighSchoolSlider)),
                    "**Liceum** – dostosuj pojemność od 10% do 500% suwakiem.\n" +
                    "100% = domyślna pojemność gry."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CollegeSlider)), "Kolegium" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CollegeSlider)),
                    "**Kolegium** – dostosuj pojemność od 10% do 500% suwakiem.\n" +
                    "100% = domyślna pojemność gry."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UniversitySlider)), "Uniwersytet" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UniversitySlider)),
                    "**Uniwersytet** – dostosuj pojemność od 10% do 500% suwakiem.\n" +
                    "100% = domyślna pojemność gry."
                },

                // Preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Przywróć domyślne" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Ustaw wszystkie suwaki pojemności z powrotem na 100% (domyślne wartości gry)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefault)), "Ustaw domyślne ASC" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefault)),
                    "Ustaw wartości startowe ASC:\n" +
                    "**200 / 150 / 120 / 120**"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),     "Nazwa tego moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),  "Aktualna wersja moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "Otwórz ten mod na stronie Paradox Mods w przeglądarce." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),  "Otwórz społeczność Discord w przeglądarce." },
            };
        }

        public void Unload()
        {
        }
    }
}
