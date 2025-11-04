// Localization/LocalePT_BR.cs
// Portuguese (pt-BR) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocalePT_BR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePT_BR(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "Ajustar Capacidade Escolar [ASC]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Ações" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Sobre" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(Setting.CapacityGroup), "Capacidade de Alunos" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PresetGroup),   "Predefinições" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),  "Informações" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Links de Suporte" },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElementarySlider)), "Escola Primária" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElementarySlider)),
                    "**Escola primária** – ajuste a capacidade entre 10% e 500% usando o controle deslizante.\n" +
                    "100% = capacidade padrão do jogo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HighSchoolSlider)), "Ensino Médio" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HighSchoolSlider)),
                    "**Ensino médio** – ajuste a capacidade entre 10% e 500% usando o controle deslizante.\n" +
                    "100% = capacidade padrão do jogo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CollegeSlider)), "Faculdade" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CollegeSlider)),
                    "**Faculdade** – ajuste a capacidade entre 10% e 500% usando o controle deslizante.\n" +
                    "100% = capacidade padrão do jogo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UniversitySlider)), "Universidade" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UniversitySlider)),
                    "**Universidade** – ajuste a capacidade entre 10% e 500% usando o controle deslizante.\n" +
                    "100% = capacidade padrão do jogo."
                },

                // Preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Redefinir para Padrão" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Leva todos os controles deslizantes de capacidade de volta a 100% (valores padrão do jogo)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefault)), "Redefinir para Padrões ASC" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefault)),
                    "Define os valores iniciais do ASC:\n" +
                    "**200 / 150 / 120 / 120**"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),     "Nome deste mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),  "Versão atual do mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "Abra este mod no site Paradox Mods em um navegador." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),  "Abra a comunidade no Discord em um navegador." },
            };
        }

        public void Unload()
        {
        }
    }
}
