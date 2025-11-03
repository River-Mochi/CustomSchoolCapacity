// Settings/Setting.cs
// Options UI for "[CSC] Custom School Capacity".
// Tabs: Actions + About
// Actions = sliders (10% steps) + 2 preset buttons (side-by-side) + checkbox
// About   = mod name + version + 2 support-link buttons (side-by-side)

namespace CustomSchoolCapacity
{
    using System;
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.Settings;
    using Game.UI;
    using Unity.Entities;
    using UnityEngine;

    [FileLocation("ModsSettings/CustomSchoolCapacity/CustomSchoolCapacity")]
    [SettingsUIGroupOrder(
        CapacityGroup,
        PresetGroup,
        OptionsGroup,
        AboutInfoGroup,
        AboutLinksGroup
    )]
    [SettingsUIShowGroupName(
        CapacityGroup,
        PresetGroup,
        OptionsGroup,
        AboutLinksGroup
    )]
    public sealed class Setting : ModSetting
    {
        // ===== Tabs =====
        public const string ActionsTab = "Actions";
        public const string AboutTab = "About";

        // ===== Groups (Actions tab) =====
        public const string CapacityGroup = "Student Capacity";
        public const string PresetGroup = "Presets";
        public const string OptionsGroup = "Options";

        // ===== Groups (About tab) =====
        public const string AboutInfoGroup = "Info";
        public const string AboutLinksGroup = "Support Links";

        // URLs for About
        private const string UrlParadox = "https://mods.paradoxplaza.com/uploaded?orderBy=desc&sortBy=best&time=alltime";
        private const string UrlDiscord = "https://discord.gg/HTav7ARPs2";

        private bool m_ScaleUpkeepWithCapacity = true;

        public Setting(IMod mod)
            : base(mod)
        {
            // fresh install → seed defaults
            if (ElementarySlider == 0)
            {
                SetDefaults();
            }
        }

        public override void Apply()
        {
            base.Apply();

            var world = World.DefaultGameObjectInjectionWorld;
            if (world == null)
            {
                return;
            }

            var system = world.GetExistingSystemManaged<CustomSchoolCapacitySystem>();
            if (system != null)
            {
                system.RequestReapplyFromSettings();
            }
        }

        // ===== Sliders (10–500%, step 10%) =====

        [SettingsUISlider(min = 10, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, CapacityGroup)]
        public int ElementarySlider
        {
            get; set;
        }

        [SettingsUISlider(min = 10, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, CapacityGroup)]
        public int HighSchoolSlider
        {
            get; set;
        }

        [SettingsUISlider(min = 10, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, CapacityGroup)]
        public int CollegeSlider
        {
            get; set;
        }

        [SettingsUISlider(min = 10, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, CapacityGroup)]
        public int UniversitySlider
        {
            get; set;
        }

        // ===== Preset buttons (side-by-side) =====

        [SettingsUIButtonGroup(PresetGroup)]
        [SettingsUIButton]
        [SettingsUISection(ActionsTab, PresetGroup)]
        public bool ResetToVanilla
        {
            set
            {
                if (!value)
                    return;
                SetToVanilla();
                Apply();
            }
        }

        [SettingsUIButtonGroup(PresetGroup)]
        [SettingsUIButton]
        [SettingsUISection(ActionsTab, PresetGroup)]
        public bool ResetToModDefault
        {
            set
            {
                if (!value)
                    return;
                SetDefaults();
                Apply();
            }
        }

        // ===== Options (checkbox) =====

        [SettingsUISection(ActionsTab, OptionsGroup)]
        public bool ScaleUpkeepWithCapacity
        {
            get => m_ScaleUpkeepWithCapacity;
            set
            {
                m_ScaleUpkeepWithCapacity = value;
                Extraneous = !value; // same trick from original
            }
        }

        // hidden helper flag
        [SettingsUIHidden]
        public bool Extraneous
        {
            get; set;
        }

        // ===== About tab =====

        [SettingsUISection(AboutTab, AboutInfoGroup)]
        public string NameDisplay => Mod.ModName;

        [SettingsUISection(AboutTab, AboutInfoGroup)]
        public string VersionDisplay => Mod.VersionShort;

        [SettingsUIButtonGroup(AboutLinksGroup)]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, AboutLinksGroup)]
        public bool OpenParadoxMods
        {
            set
            {
                if (!value)
                    return;
                try
                {
                    Application.OpenURL(UrlParadox);
                }
                catch (Exception) { }
            }
        }

        [SettingsUIButtonGroup(AboutLinksGroup)]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, AboutLinksGroup)]
        public bool OpenDiscord
        {
            set
            {
                if (!value)
                    return;
                try
                {
                    Application.OpenURL(UrlDiscord);
                }
                catch (Exception) { }
            }
        }

        // ===== Presets =====

        public override void SetDefaults()
        {
            // your CSC defaults
            ElementarySlider = 200;
            HighSchoolSlider = 130;
            CollegeSlider = 120;
            UniversitySlider = 120;
            ScaleUpkeepWithCapacity = true;
            Extraneous = false;
        }

        public void SetToVanilla()
        {
            ElementarySlider = 100;
            HighSchoolSlider = 100;
            CollegeSlider = 100;
            UniversitySlider = 100;
            ScaleUpkeepWithCapacity = true;
        }
    }
}
