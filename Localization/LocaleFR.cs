// Localization/LocaleFR.cs
// French strings for "[CSC] Custom School Capacity" - Options UI.

namespace CustomSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleFR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleFR(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "[CSC] Capacité Scolaire Personnalisée" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.CapacitySection), "Principal" },
                { m_Setting.GetOptionTabLocaleID(Setting.ResetSection),    "Réinitialiser" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.CapacityGroup),     "Capacité des étudiants" },
                { m_Setting.GetOptionGroupLocaleID(Setting.OtherOptionsGroup), "Options supplémentaires" },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElementarySlider)), "École primaire" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ElementarySlider)),  "Définit la capacité des écoles primaires par rapport au jeu de base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HighSchoolSlider)), "Lycée" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.HighSchoolSlider)),  "Définit la capacité des lycées par rapport au jeu de base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CollegeSlider)), "Collège" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CollegeSlider)),  "Définit la capacité des collèges par rapport au jeu de base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UniversitySlider)), "Université" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UniversitySlider)),  "Définit la capacité des universités par rapport au jeu de base." },

                // Toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ScaleUpkeepWithCapacity)), "Ajuster l’entretien selon la capacité" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ScaleUpkeepWithCapacity)),  "Si activé, les coûts d’entretien seront également multipliés par la capacité choisie." },

                // Buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Réinitialiser aux valeurs de base" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),  "Ramène toutes les capacités à 100 %." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefault)), "Réinitialiser aux valeurs CSC" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefault)),  "Applique les valeurs recommandées du mod (200 / 120 / 125 / 125)." },
            };
        }

        public void Unload()
        {
        }
    }
}
