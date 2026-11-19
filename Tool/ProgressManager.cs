using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Snakey_Game.Tool
{
    public class ProgressManager
    {
        readonly RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SnakeyGame");

        public ProgressManager() { }

        public void SaveToRegistry()
        {
            // Save the user data to the registry
            for (int i = 0; i < GlobalConfig.UserScores.Count; i++)
            {
                var userData = GlobalConfig.UserScores[i];
                string valueName = userData.PlayerName + ".snakedata" + userData.Index;
                string valueData = $"{userData.Score} - {userData.Difficulty}";

                if (key.GetSubKeyNames().Contains(valueName)) continue;

                key.SetValue(valueName, valueData);
            }
        }

        public void LoadFromRegistry()
        {
            // Load the user data from the registry
            string[] valueNames = key.GetValueNames();
            if (valueNames.Length == 0) return;

            foreach (string valueNameReg in valueNames)
            {
                string valueName = Parser.ParseNameFromRegData(valueNameReg);
                int index = int.Parse(valueNameReg.Substring(valueNameReg.LastIndexOf(".snakedata") + ".snakedata".Length));

                string value = (string)key.GetValue(valueNameReg);

                if (string.IsNullOrEmpty(value)) return;

                var parts = value.Split(new[] { " - " }, StringSplitOptions.None);
                if (parts.Length == 2 && int.TryParse(parts[0], out int score))
                {
                    GlobalConfig.UserScores.Add(new UserData
                    {
                        PlayerName = valueName,
                        Score = score,
                        Difficulty = ConvertStringToDifficulty(parts[1]),
                        Index = index
                    });
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
