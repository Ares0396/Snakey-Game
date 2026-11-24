using Snakey_Game.Tool.Manager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Snakey_Game.Tool
{
    public class Model
    {
        public List<Point> CurrentModel;
        public List<Point> NextModel;
        public int Score { get; set; } = 0;

        bool isDisposed = false;

        public Model()
        {
            CurrentModel = new List<Point>(GlobalConfig.StartingSnakeBody);
            NextModel = new List<Point>(GlobalConfig.StartingSnakeBody);
        }

        public void UpdateModel()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Model has been disposed.");
            }

            // Update the current model to the next model
            CurrentModel.Clear();
            CurrentModel.AddRange(NextModel);
        }

        public void BuildNextModel()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Model has been disposed.");
            }
            if (GlobalConfig.DirectionQueue.Count == 0)
            {
                return;
            }

            // Calculate the new head position based on the current direction
            Point currentHead = CurrentModel[0];
            Point directionVector = Coordinates.ConvertDirectionToCoordinates(GlobalConfig.DirectionQueue[0]);
            Point newHead = new Point(currentHead.X + directionVector.X, currentHead.Y + directionVector.Y);

            // Create the next model by adding the new head and removing the tail
            NextModel.Clear();
            NextModel.Add(newHead);

            if (GlobalConfig.DirectionQueue.Count > 1)
            {
                GlobalConfig.DirectionQueue.RemoveAt(0);
            }

            //Determine whether the snake is eating an apple or not. If it is, we don't remove the tail, otherwise we do.
            int indexUpperBound = CurrentModel.Count - 1;
            if (newHead == GlobalConfig.ApplePosition)
            {
                indexUpperBound = CurrentModel.Count; // Keep the tail if eating an apple
                SetAppleCoordinates();

                // Increase score when eating an apple
                if (SettingManager.IsHighRiskModeEnabled)
                {
                    Score += 10; // 10 points in high-risk mode
                }
                else
                {
                    Score += 1; // Normal point increment
                }
            }
            for (int i = 0; i < indexUpperBound; i++)
                {
                    NextModel.Add(CurrentModel[i]);
                }
        }
        
        public bool CheckCollision()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Model has been disposed.");
            }

            Point newHead = NextModel[0];

            // Check for collision with walls
            if (newHead.X < GlobalConfig.MinX || newHead.X > GlobalConfig.MaxX || newHead.Y < GlobalConfig.MinY || newHead.Y > GlobalConfig.MaxY)
            {
                return true;
            }

            // Check for collision with itself
            if (CurrentModel.Contains(newHead) && newHead != CurrentModel.Last())
            {
                return true;
            }
            return false;
        }

        public void SetAppleCoordinates()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Model has been disposed.");
            }

            Point applePosition = Coordinates.GenerateRandomCoordinates(CurrentModel.ToArray());
            GlobalConfig.ApplePosition = applePosition;
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                CurrentModel.Clear();
                NextModel.Clear();
                CurrentModel = null;
                NextModel = null;
                isDisposed = true;
            }
        }
    }
}
