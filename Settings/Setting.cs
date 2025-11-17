// Settings/Setting.cs
// Options UI for "Adjust School Capacity [ASC]".

namespace AdjustSchoolCapacity
{
    using System;
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.Settings;
    using Game.UI;
    using Unity.Entities;
    using UnityEngine;

    [FileLocation("ModsSettings/AdjustSchoolCapacity/AdjustSchoolCapacity")]    // Saved settings path
    [SettingsUIGroupOrder(
        CapacityGroup,
        PresetGroup,
        AboutInfoGroup,
        AboutLinksGroup
    )]
    [SettingsUIShowGroupName(
        CapacityGroup,
        PresetGroup,
        AboutLinksGroup
    )]
    public sealed class Setting : ModSetting
    {
        // ---- Tabs ----
        public const string ActionsTab = "Actions";
        public const string AboutTab = "About";

        // ---- Groups Actions tab ----
        public const string CapacityGroup = "Student Capacity";
        public const string PresetGroup = "Presets";

        // ---- Groups About tab ----
        public const string AboutInfoGroup = "Info";
        public const string AboutLinksGroup = "Support Links";

        // ---- External links ----
        private const string UrlParadox = "https://mods.paradoxplaza.com/uploaded?orderBy=desc&sortBy=best&time=alltime";
        private const string UrlDiscord = "https://discord.gg/HTav7ARPs2";

        public Setting(IMod mod) : base(mod)
        {
            // Fresh install → seed defaults
            if (ElementarySlider == 0)
            {
                SetDefaults();
            }
        }

        public override void Apply()
        {
            base.Apply();

            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null)
            {    return; }

            AdjustSchoolCapacitySystem system =
                world.GetExistingSystemManaged<AdjustSchoolCapacitySystem>();

            system.RequestReapplyFromSettings();
        }

        // ---- Sliders (10–500%, step 10%) ----

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

        // ---- Preset buttons, same group → side-by-side ----

        [SettingsUIButtonGroup(PresetGroup)]
        [SettingsUIButton]
        [SettingsUISection(ActionsTab, PresetGroup)]
        public bool ResetToVanilla
        {
            set
            {
                if (!value)
                { return; }

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
                {    return; }

                SetDefaults();
                Apply();
            }
        }

        // ---- About tab ----

        [SettingsUISection(AboutTab, AboutInfoGroup)]
        public string NameDisplay => Mod.ModName;

        [SettingsUISection(AboutTab, AboutInfoGroup)]
        public string VersionDisplay => Mod.ModVersion;

        [SettingsUIButtonGroup(AboutLinksGroup)]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, AboutLinksGroup)]
        public bool OpenParadoxMods
        {
            set
            {
                if (!value)
                {     return;  }

                try
                {
                    Application.OpenURL(UrlParadox);
                }
                catch (Exception)
                {
                }
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
                {   return; }

                try
                {
                    Application.OpenURL(UrlDiscord);
                }
                catch (Exception)
                {
                }
            }
        }

        // ---- Presets ----

        public override void SetDefaults()
        {
            // ASC defaults
            ElementarySlider = 200;
            HighSchoolSlider = 150;
            CollegeSlider = 120;
            UniversitySlider = 120;
        }

        public void SetToVanilla()
        {
            ElementarySlider = 100;
            HighSchoolSlider = 100;
            CollegeSlider = 100;
            UniversitySlider = 100;
        }
    }
}
