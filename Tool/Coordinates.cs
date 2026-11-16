using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey_Game.Tool
{
    public class Coordinates
    {
        public static Point GenerateRandomCoordinates(Point[] exceptionPoints)
        {
            Random random = new Random();
            int x = random.Next(GlobalConfig.MinX, GlobalConfig.MaxX);
            int y = random.Next(GlobalConfig.MinY, GlobalConfig.MaxY);
            // Ensure the coordinates are multiples of 10
            x = (x / 10) * 10;
            y = (y / 10) * 10;

            // Check if the generated coordinates are in the exception points
            while (exceptionPoints.Any(p => p.X == x && p.Y == y))
            {
                x = random.Next(GlobalConfig.MinX, GlobalConfig.MaxX);
                y = random.Next(GlobalConfig.MinY, GlobalConfig.MaxY);
                x = (x / 10) * 10;
                y = (y / 10) * 10;
            }

            return new Point(x, y);
        }
        public static Point ConvertDirectionToCoordinates(GlobalConfig.Direction direction)
        {
            switch (direction)
            {
                case GlobalConfig.Direction.Left:
                    return GlobalConfig.Direction_Left;
                case GlobalConfig.Direction.Up:
                    return GlobalConfig.Direction_Up;
                case GlobalConfig.Direction.Down:
                    return GlobalConfig.Direction_Down;
                case GlobalConfig.Direction.Right:
                    return GlobalConfig.Direction_Right;
                default:
                    throw new Exception();
            }
        }
    }
}
