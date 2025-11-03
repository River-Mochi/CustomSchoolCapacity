// Localization/LocaleES.cs
// Spanish strings for "[CSC] Custom School Capacity" - Options UI.

namespace CustomSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleES : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleES(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "[CSC] Capacidad Escolar Personalizada" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.CapacitySection), "Principal" },
                { m_Setting.GetOptionTabLocaleID(Setting.ResetSection),    "Restablecer" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.CapacityGroup),     "Capacidad de estudiantes" },
                { m_Setting.GetOptionGroupLocaleID(Setting.OtherOptionsGroup), "Opciones adicionales" },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElementarySlider)), "Escuela primaria" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ElementarySlider)),  "Ajusta la capacidad de las escuelas primarias en relación al valor original." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HighSchoolSlider)), "Escuela secundaria" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.HighSchoolSlider)),  "Ajusta la capacidad de las escuelas secundarias en relación al valor original." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CollegeSlider)), "Instituto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CollegeSlider)),  "Ajusta la capacidad de los institutos en relación al valor original." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UniversitySlider)), "Universidad" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UniversitySlider)),  "Ajusta la capacidad de las universidades en relación al valor original." },

                // Toggle
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ScaleUpkeepWithCapacity)), "Ajustar mantenimiento con capacidad" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ScaleUpkeepWithCapacity)),  "Si está activado, el mantenimiento también se multiplicará según la capacidad elegida." },

                // Buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Restablecer a valores originales" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),  "Restablece todas las capacidades al 100 %." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefault)), "Restablecer a valores CSC" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefault)),  "Aplica los valores recomendados del mod (200 / 120 / 125 / 125)." },
            };
        }

        public void Unload()
        {
        }
    }
}
