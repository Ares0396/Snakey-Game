using Snakey_Game.Tool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey_Game
{
    public class GlobalConfig
    {
        public static int MinX { get; set; } = 300;
        public static int MaxX { get; set; } = 1185;
        public static int MinY { get; set; } = 0;
        public static int MaxY { get; set; } = 630;

        public static int SnakeSpeed { get; } = 15;
        public static int SnakeMovementInterval { get; set; } = (int)CurrentDifficulty; // in milliseconds; Can be modified based on difficulty level (Easy, Medium, Hard)
        public static int SnakeSize { get; } = 14;
        public static int FoodSize { get; } = 14;

        public static List<Point> SnakeBody { get; set; } = new List<Point>
        {
            new Point(735, 315),
            new Point(720, 315),
            new Point(705, 315)
        };
        public static Point ApplePosition { get; set; } = Coordinates.GenerateRandomCoordinates(SnakeBody.ToArray());

        public static Point Direction_Right { get; } = new Point(15, 0);
        public static Point Direction_Left { get; } = new Point(-15, 0);
        public static Point Direction_Up { get; } = new Point(0, -15);
        public static Point Direction_Down { get; } = new Point(0, 15);

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

        public static DifficultyLevel CurrentDifficulty { get; set; } = DifficultyLevel.Easy; //Default is easy
        public static bool IsHighRiskModeEnabled { get; set; } = false; // Default is false

        public static int HighestScore { get; set; } = 0;

        public static List<UserData> UserScores { get; set; } = new List<UserData>();
        public static List<Direction> DirectionQueue { get; set; } = new List<Direction>();

        public static ProgressManager ProgressManager { get; set; } = new ProgressManager();
    }

    public class UserData
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public GlobalConfig.DifficultyLevel Difficulty { get; set; }
    }
}
