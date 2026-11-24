using Snakey_Game.Tool;
using Snakey_Game.Tool.Manager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Snakey_Game
{
    public class GlobalConfig
    {
        #region Constant fields
        // These are the boundaries of the game area
        public static int MinX { get; set; } = 300;
        public static int MaxX { get; set; } = 1185;
        public static int MinY { get; set; } = 0;
        public static int MaxY { get; set; } = 630;

        // Snake and food properties
        public static int SnakeSpeed { get; } = 15;
        public static int SnakeSize { get; } = 14;
        public static int FoodSize { get; } = 14;

        // Game state properties
        public static List<Point> StartingSnakeBody { get; set; } = new List<Point>
        {
            new Point(735, 315),
            new Point(735, 315),
            new Point(735, 315)
        };
        public static Point ApplePosition { get; set; } = Coordinates.GenerateRandomCoordinates(StartingSnakeBody.ToArray());

        // Direction vectors for snake movement
        public static Point Direction_Right { get; } = new Point(15, 0);
        public static Point Direction_Left { get; } = new Point(-15, 0);
        public static Point Direction_Up { get; } = new Point(0, -15);
        public static Point Direction_Down { get; } = new Point(0, 15);

        // Enums for difficulty levels and directions
        public enum DifficultyLevel
        {
            Easy = 100, // Snake moves every 100 milliseconds
            Medium = 40, // Snake moves every 40 milliseconds
            Hard = 10 // Snake moves every 10 milliseconds
        }
        public enum Direction
        {
            Left,
            Up,
            Down,
            Right
        }
        #endregion

        // Customizable settings
        public static int HighestScore { get; set; } = 0;
        public static int SnakeMovementInterval { get; set; } = (int)SettingManager.CurrentDifficulty; // in milliseconds; Can be modified based on difficulty level (Easy, Medium, Hard)

        public static List<UserData> UserScores { get; set; } = new List<UserData>();
        public static List<Direction> DirectionQueue { get; set; } = new List<Direction>();

        public static UserDataManager UserDataManager { get; set; } = new UserDataManager();
        public static SoundPlayer SoundPlayer { get; set; } = new SoundPlayer();

        // Setting configs
        // These are initialized in the SettingManager class
    }

    public class UserData
    {
        public int Index { get; set; }
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public GlobalConfig.DifficultyLevel Difficulty { get; set; }
    }
}
