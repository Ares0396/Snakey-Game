using Microsoft.Win32;
using System;
using System.Drawing;
using static Snakey_Game.GlobalConfig;

namespace Snakey_Game.Tool.Manager
{
    public class SettingManager
    {
        // We'll work with the settings here
        // Registry key format: "Setting_[SettingName]" for the value name, and the value data will be the setting value.
        public static readonly RegistryKey settingsRegistryKey = Registry.CurrentUser.CreateSubKey(@"Software\SnakeyGame\Settings");

        // DEFAULT setting fields, cannot be changed
        public static bool Default_TurnOnDeathSoundEffect { get; } = false; //default
        public static DifficultyLevel Default_CurrentDifficulty { get; } = DifficultyLevel.Easy; //Default is easy
        public static bool Default_IsHighRiskModeEnabled { get; } = false; // Default is false
        public static Color Default_BackgroundColor { get; } = Color.FromArgb(40, 40, 40); // Default background color is black-gray
        public static Color Default_ForegroundColor { get; } = Color.White;
        public static Color Default_SnakeColor { get; } = Color.Green;
        public static Color Default_AppleColor { get; } = Color.Red;

        // Setting fields
        public static bool TurnOnDeathSoundEffect { get; set; } = false; //default
        public static DifficultyLevel CurrentDifficulty { get; set; } = DifficultyLevel.Easy; //Default is easy
        public static bool IsHighRiskModeEnabled { get; set; } = false; // Default is false
        public static Color BackgroundColor { get; set; } = Color.FromArgb(40, 40, 40); // Default background color is black-gray
        public static Color ForegroundColor { get; set; } = Color.White;
        public static Color SnakeColor { get; set; } = Color.Green;
        public static Color AppleColor { get; set; } = Color.Red;

        // Method to load settings from the registry
        public static void LoadSettingsFromRegistry()
        {
            // Load settings from the registry
            foreach (string valueName in settingsRegistryKey.GetValueNames())
            {
                string settingValue = settingsRegistryKey.GetValue(valueName)?.ToString();
                switch (valueName)
                {
                    case "Setting_TurnOnDeathSoundEffect":
                        TurnOnDeathSoundEffect = settingValue == "True";
                        break;
                    case "Setting_CurrentDifficulty":
                        if (Enum.TryParse(settingValue, out DifficultyLevel difficulty))
                        {
                            CurrentDifficulty = difficulty;
                        }
                        break;
                    case "Setting_IsHighRiskModeEnabled":
                        IsHighRiskModeEnabled = settingValue == "True";
                        break;
                    case "Setting_BackgroundColor":
                        string[] parts = settingValue.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        if (int.TryParse(parts[0], out int R) && int.TryParse(parts[1], out int G) && int.TryParse(parts[2], out int B)) BackgroundColor = Color.FromArgb(R, G, B);
                        break;
                    case "Setting_ForegroundColor":
                        string[] parts_Fore = settingValue.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        if (int.TryParse(parts_Fore[0], out int R_Fore) && int.TryParse(parts_Fore[1], out int G_Fore) && int.TryParse(parts_Fore[2], out int B_Fore)) ForegroundColor = Color.FromArgb(R_Fore, G_Fore, B_Fore);
                        break;
                    case "Setting_SnakeColor":
                        string[] parts_Snake = settingValue.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        if (int.TryParse(parts_Snake[0], out int R_Snake) && int.TryParse(parts_Snake[1], out int G_Snake) && int.TryParse(parts_Snake[2], out int B_Snake)) SnakeColor = Color.FromArgb(R_Snake, G_Snake, B_Snake);
                        break;
                    case "Setting_AppleColor":
                        string[] parts_Apple = settingValue.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        if (int.TryParse(parts_Apple[0], out int R_Apple) && int.TryParse(parts_Apple[1], out int G_Apple) && int.TryParse(parts_Apple[2], out int B_Apple)) AppleColor = Color.FromArgb(R_Apple, G_Apple, B_Apple);
                        break;
                }
            }
        }
        public static void SaveSettingsToRegistry()
        {
            // Save settings to the registry
            settingsRegistryKey.SetValue("Setting_TurnOnDeathSoundEffect", TurnOnDeathSoundEffect.ToString());
            settingsRegistryKey.SetValue("Setting_CurrentDifficulty", CurrentDifficulty.ToString());
            settingsRegistryKey.SetValue("Setting_IsHighRiskModeEnabled", IsHighRiskModeEnabled.ToString());

            settingsRegistryKey.SetValue("Setting_BackgroundColor", $"{BackgroundColor.R} - {BackgroundColor.G} - {BackgroundColor.B}");
            settingsRegistryKey.SetValue("Setting_ForegroundColor", $"{ForegroundColor.R} - {ForegroundColor.G} - {ForegroundColor.B}");
            settingsRegistryKey.SetValue("Setting_SnakeColor", $"{SnakeColor.R} - {SnakeColor.G} - {SnakeColor.B}");
            settingsRegistryKey.SetValue("Setting_AppleColor", $"{AppleColor.R} - {AppleColor.G} - {AppleColor.B}");
            // Later for other colors
        }

        public static void RevertToDefault(bool save)
        {
            TurnOnDeathSoundEffect = Default_TurnOnDeathSoundEffect;
            CurrentDifficulty = Default_CurrentDifficulty;
            IsHighRiskModeEnabled = Default_IsHighRiskModeEnabled;
            BackgroundColor = Default_BackgroundColor;
            ForegroundColor = Default_ForegroundColor;
            SnakeColor = Default_SnakeColor;
            AppleColor = Default_AppleColor;

            if (save) SaveSettingsToRegistry();
        }
    }
}
