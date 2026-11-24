using Microsoft.Win32;
using System;
using System.Linq;

namespace Snakey_Game.Tool.Manager
{
    public class UserDataManager
    {
        readonly RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SnakeyGame\UserData");

        public UserDataManager() { }
        // New update: Now the new registry format is: KEY: Index, VALUE: PlayerName - Score - Difficulty

        public void SaveToRegistry()
        {
            if (GlobalConfig.UserScores.Count == 0) return;

            // Save the user data to the registry
            for (int i = 0; i < GlobalConfig.UserScores.Count; i++)
            {
                var userData = GlobalConfig.UserScores[i];
                string valueName = userData.Index.ToString();
                string valueData = $"{userData.PlayerName} - {userData.Score} - {userData.Difficulty}";

                if (key.GetValueNames().Contains(valueName)) continue;

                key.SetValue(valueName, valueData);
            }
        }

        public void LoadFromRegistry()
        {
            // Load the user data from the registry
            string[] valueNames = key.GetValueNames();

            // If the names contain anything besides index, then we consider them invalid and delete them. This is to prevent any issues with other registry entries that may be present.
            // When settings are implemented, they'll be stored inside a single subkey called Settings. We'll ignore them as they'll be handled by the settings manager. We only want to load user data, which is in the format of an index number.
            // Other entries that are not in the index format will be deleted, and the user data will be loaded from the remaining valid entries.

            foreach (string valueName in valueNames)
            {
                if (!int.TryParse(valueName, out var index)) // No need to worry about settings because it's in a different subkey. We only want to load user data, which is in the format of an index number.
                {
                    key.DeleteValue(valueName);
                }
            }

            if (valueNames.Length == 0) return;
            // We no longer use .snakedata in the registry. Since we have deleted any invalid entries, we can now safely load the data.
            // Fix the loading of the user data to handle the new registry format. The value names are now just the index, and the value data is in the format "PlayerName - Score - Difficulty".
            foreach (string valueNameReg in valueNames)
            {
                int index = int.Parse(valueNameReg);
                string value = (string)key.GetValue(valueNameReg);

                if (string.IsNullOrEmpty(value)) key.DeleteValue(valueNameReg); // Delete the value if the value is null or empty because it's invalid

                var parts = value.Split(new[] { " - " }, StringSplitOptions.None);
                if (parts.Length == 3 && int.TryParse(parts[1], out int score)) // Score is parts[1]
                {
                    GlobalConfig.UserScores.Add(new UserData
                    {
                        PlayerName = parts[0],
                        Score = score,
                        Difficulty = ConvertStringToDifficulty(parts[2]),
                        Index = index
                    });

                    // Update the highest score
                    if (score > GlobalConfig.HighestScore)
                    {
                        GlobalConfig.HighestScore = score;
                    }
                }
            }

            //Sort the user data
            GlobalConfig.UserScores.OrderByDescending(p => p.Index);
            GlobalConfig.UserScores.Reverse();
        }

        private GlobalConfig.DifficultyLevel ConvertStringToDifficulty(string difficultyString)
        {
            switch (difficultyString)
            {
                case "Easy":
                    return GlobalConfig.DifficultyLevel.Easy;
                case "Medium":
                    return GlobalConfig.DifficultyLevel.Medium;
                case "Hard":
                    return GlobalConfig.DifficultyLevel.Hard;
                default:
                    throw new ArgumentException("Invalid difficulty string");
            }
        }

        public void ClearRegistry()
        {
            // Clear the user data from the registry
            foreach (var valueName in key.GetValueNames())
            {
                key.DeleteValue(valueName);
            }
        }

        public void Dispose()
        {
            key.Close();
        }
    }
}
