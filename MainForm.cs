using Snakey_Game.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snakey_Game
{
    public partial class MainForm : Form
    {
        Panel applePanel;
        Model snakeModel;
        List<Panel> snakeSegmentPanels;
        bool isPaused = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.White, 5);
            Point[] points = new Point[]
            {
                new Point(GlobalConfig.MinX-1, GlobalConfig.MinY-1),
                new Point(GlobalConfig.MaxX, GlobalConfig.MinY-1),
                new Point(GlobalConfig.MaxX, GlobalConfig.MaxY),
                new Point(GlobalConfig.MinX-1, GlobalConfig.MaxY),
                new Point(GlobalConfig.MinX-1, GlobalConfig.MinY-1)
            };
            e.Graphics.DrawPolygon(pen, points);
            pen.Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Define the apple panel (which represents the apple itself)
            applePanel = new Panel
            {
                Size = new Size(GlobalConfig.FoodSize, GlobalConfig.FoodSize),
                BackColor = Color.Red,
                Location = Coordinates.GenerateRandomCoordinates(GlobalConfig.SnakeBody.ToArray())
            };
            snakeSegmentPanels = new List<Panel>();

            //Set highest score label
            Lb_HighestScore.Text = $"Highest Score: {GlobalConfig.HighestScore}";
        }

        private void Btn_StartPlaying_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBox_PlayerName.Text))
            {
                MessageBox.Show("Please enter your name before starting the game.", "Name Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Not implemented yet, but this is where the player name will be stored for future use
            InitializeGameGraphics();

            GlobalConfig.SnakeMovementInterval = (int)GlobalConfig.CurrentDifficulty; // Update the interval based on the selected difficulty level
            Tmr_Animation.Interval = GlobalConfig.SnakeMovementInterval; //Set the interval based on the difficulty level
            Tmr_Animation.Enabled = true;
            Tmr_Animation.Start();

            Btn_StartPlaying.Enabled = false;
            TxtBox_PlayerName.Enabled = false;

            Lb_Status.Text = "Status: Playing";
            Lb_Status.ForeColor = Color.Lime;
        }

        private void InitializeGameGraphics()
        {
            //Initialize the model for the snake's body (logic part)
            snakeModel = new Model();
            GlobalConfig.DirectionQueue.Clear();
            GlobalConfig.DirectionQueue.Add(GlobalConfig.Direction.Right); // Reset the direction to right when starting a new game

            // Add the apple panel to the form
            if (!this.Controls.Contains(applePanel))
            {
                this.Controls.Add(applePanel);
            }
            snakeModel.GenerateAndSetAppleCoordinates(applePanel);

            // Add the snake body panels to the form
            foreach (Panel snakeSegmentPanel in snakeSegmentPanels)
            {
                this.Controls.Remove(snakeSegmentPanel);
                snakeSegmentPanel.Dispose();
            }
            snakeSegmentPanels.Clear();

            foreach (var segment in GlobalConfig.SnakeBody)
            {
                Panel snakeSegmentPanel = new Panel
                {
                    Size = new Size(GlobalConfig.SnakeSize, GlobalConfig.SnakeSize),
                    BackColor = Color.Green,
                    Location = segment
                };
                this.Controls.Add(snakeSegmentPanel);
                snakeSegmentPanels.Add(snakeSegmentPanel);
            }

            // Refresh the form to ensure all graphics are drawn
            // Also, from now on, we will refer to the body (logic part) via models in Model.cs, and the graphics part via panels in MainForm.cs. The two will be synchronized in the Tmr_Animation_Tick event.
            this.Refresh();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (GlobalConfig.DirectionQueue[0] != GlobalConfig.Direction.Down) GlobalConfig.DirectionQueue.Add(GlobalConfig.Direction.Up);
                    break;
                case Keys.A:
                    if (GlobalConfig.DirectionQueue[0] != GlobalConfig.Direction.Right) GlobalConfig.DirectionQueue.Add(GlobalConfig.Direction.Left);
                    break;
                case Keys.S:
                    if (GlobalConfig.DirectionQueue[0] != GlobalConfig.Direction.Up) GlobalConfig.DirectionQueue.Add(GlobalConfig.Direction.Down);
                    break;
                case Keys.D:
                    if (GlobalConfig.DirectionQueue[0] != GlobalConfig.Direction.Left) GlobalConfig.DirectionQueue.Add(GlobalConfig.Direction.Right);
                    break;
                case Keys.Space:
                    if (isPaused)
                    {
                        Tmr_Animation.Start();
                        isPaused = false;
                        Lb_Status.Text = "Status: Playing";
                        Lb_Status.ForeColor = Color.Lime;
                    }
                    else
                    {
                        Tmr_Animation.Stop();
                        isPaused = true;
                        Lb_Status.Text = "Status: Paused";
                        Lb_Status.ForeColor = Color.Yellow;
                    }
                    break;

                default:
                    break;
            }
        }

        private void Tmr_Animation_Tick(object sender, EventArgs e)
        {
            //Build the next model based on the current direction and current model
            snakeModel.BuildNextModel(applePanel);

            //Check for collision
            if (snakeModel.CheckCollision())
            {
                EndGame();
                return;
            }

            //Update the current model to the next model
            snakeModel.UpdateModel();

            //(TEST): New way to update snake segment panels
            Panel newHead = new Panel()
            {
                Size = new Size(GlobalConfig.SnakeSize, GlobalConfig.SnakeSize),
                BackColor = Color.Green,
                Location = snakeModel.CurrentModel[0]
            };
            this.Controls.Add(newHead);
            snakeSegmentPanels.Insert(0, newHead);

            if (snakeModel.CurrentModel.Count < snakeSegmentPanels.Count)
            {
                Panel tail = snakeSegmentPanels.Last();
                snakeSegmentPanels.Remove(tail);
                tail.Dispose();
            }

            // Update the score display
            // Also update the highest score if the current score exceeds it
            Lb_Score.Text = $"Score: {snakeModel.Score}";
            int highestScore = int.Parse(Lb_HighestScore.Text.Split(':')[1].Trim());
            if (snakeModel.Score > highestScore)
            {
                Lb_HighestScore.Text = $"Highest Score: {snakeModel.Score}";
            }
        }
        private void EndGame()
        {
            Tmr_Animation.Stop();

            EndGameForm endGameForm = new EndGameForm();
            endGameForm.Show(); //Let it show while we continue the postgame work here (shows for 5 seconds, then closes automatically)

            // Store the player's score and difficulty level
            GlobalConfig.HighestScore = Math.Max(GlobalConfig.HighestScore, snakeModel.Score);
            GlobalConfig.UserScores.Add(new UserData
            {
                PlayerName = TxtBox_PlayerName.Text,
                Score = snakeModel.Score,
                Difficulty = GlobalConfig.CurrentDifficulty
            });
            GlobalConfig.ProgressManager.SaveToRegistry(); // Save the user data to the registry


            Btn_StartPlaying.Enabled = true;
            Tmr_Animation.Enabled = false;
            TxtBox_PlayerName.Enabled = true;

            Lb_Status.Text = "Status: GAME OVER!";
            Lb_Status.ForeColor = Color.Red;

            //Shut down the computer if High Risk Mode is enabled
            if (GlobalConfig.IsHighRiskModeEnabled)
            {
                ShutdownMechanism.ShutdownComputer();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tmr_Animation.Stop();
            snakeModel?.Dispose();
        }
    }
}
