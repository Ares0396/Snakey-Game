using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Snakey_Game.Tool
{
    public class ProgressManager
    {
        readonly RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SnakeyGame");

        public ProgressManager() { }

        public void SaveToRegistry()
        {
            // Save the user data to the registry
            foreach (var userData in GlobalConfig.UserScores)
            {
                key.SetValue(userData.PlayerName, $"{userData.Score} - {userData.Difficulty}");
            }
        }

        public void LoadFromRegistry()
        {
            // Load the user data from the registry
            foreach (var valueName in key.GetValueNames())
            {
                var value = key.GetValue(valueName).ToString();
                var parts = value.Split(new[] { " - " }, StringSplitOptions.None);
                if (parts.Length == 2 && int.TryParse(parts[0], out int score))
                {
                    GlobalConfig.UserScores.Add(new UserData
                    {
                        PlayerName = valueName,
                        Score = score,
                        Difficulty = ConvertStringToDifficulty(parts[1])
                    });
                }
            }
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
