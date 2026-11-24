using Snakey_Game.Tool;
using Snakey_Game.Tool.Manager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snakey_Game
{
    public partial class GameForm : Form
    {
        Panel applePanel;
        Model snakeModel;
        UI snakeUI;
        List<Panel> snakeSegmentPanels;
        bool isPaused = false;

        readonly Random random = new Random();

        public GameForm()
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
            UI.ApplySettingToForm(this);

            //Define the apple panel (which represents the apple itself)
            applePanel = new Panel
            {
                Size = new Size(GlobalConfig.FoodSize, GlobalConfig.FoodSize),
                BackColor = SettingManager.AppleColor,
                Location = Coordinates.GenerateRandomCoordinates(GlobalConfig.StartingSnakeBody.ToArray())
            };
            snakeSegmentPanels = new List<Panel>();

            //Set highest score label
            Lb_HighestScore.Text = $"Highest Score: {GlobalConfig.HighestScore}";

            if (SettingManager.TurnOnDeathSoundEffect)
            {
                GlobalConfig.SoundPlayer.Stream = random.Next() % 2 == 0 ? Properties.Resources.Sonic_exe_tails_scream : Properties.Resources.slendytubby_scream_made_with_Voicemod; // Set the sound effect file path
                GlobalConfig.SoundPlayer.Load(); // Load the sound effect into memory when the main form loads
            }
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

            GlobalConfig.SnakeMovementInterval = (int)SettingManager.CurrentDifficulty; // Update the interval based on the selected difficulty level
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
            // Initialize the snake model and UI
            snakeModel = new Model();
            snakeUI = new UI(applePanel, snakeSegmentPanels, snakeModel, this);

            GlobalConfig.DirectionQueue.Clear();

            // Add the apple panel to the form
            if (!this.Controls.Contains(applePanel))
            {
                this.Controls.Add(applePanel);
            }
            snakeUI.GenerateApple(); // Set the apple's initial position

            // Add the snake body panels to the form
            foreach (Panel snakeSegmentPanel in snakeSegmentPanels)
            {
                this.Controls.Remove(snakeSegmentPanel);
                snakeSegmentPanel.Dispose();
            }
            snakeSegmentPanels.Clear();

            foreach (var segment in GlobalConfig.StartingSnakeBody)
            {
                Panel snakeSegmentPanel = new Panel
                {
                    Size = new Size(GlobalConfig.SnakeSize, GlobalConfig.SnakeSize),
                    BackColor = SettingManager.SnakeColor,
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
                    if (isPaused) return; // If the game is paused, ignore direction changes
                    if (GlobalConfig.DirectionQueue.Count == 0 || GlobalConfig.DirectionQueue[0] != GlobalConfig.Direction.Down) GlobalConfig.DirectionQueue.Add(GlobalConfig.Direction.Up);
                    break;
                case Keys.A:
                    if (isPaused) return; // If the game is paused, ignore direction changes
                    if (GlobalConfig.DirectionQueue.Count == 0 || GlobalConfig.DirectionQueue[0] != GlobalConfig.Direction.Right) GlobalConfig.DirectionQueue.Add(GlobalConfig.Direction.Left);
                    break;
                case Keys.S:
                    if (isPaused) return; // If the game is paused, ignore direction changes
                    if (GlobalConfig.DirectionQueue.Count == 0 || GlobalConfig.DirectionQueue[0] != GlobalConfig.Direction.Up) GlobalConfig.DirectionQueue.Add(GlobalConfig.Direction.Down);
                    break;
                case Keys.D:
                    if (isPaused) return; // If the game is paused, ignore direction changes
                    if (GlobalConfig.DirectionQueue.Count == 0 || GlobalConfig.DirectionQueue[0] != GlobalConfig.Direction.Left) GlobalConfig.DirectionQueue.Add(GlobalConfig.Direction.Right);
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

            // Prevent the default behavior of the keys (like scrolling, or making a beep sound)
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void Tmr_Animation_Tick(object sender, EventArgs e)
        {
            //Build the next model based on the current direction and current model
            snakeModel.BuildNextModel();

            //Check for collision
            if (snakeModel.CheckCollision())
            {
                EndGame();
                return;
            }

            //Update the current model to the next model
            snakeModel.UpdateModel();
            snakeUI.UpdateUI();

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
            if (SettingManager.TurnOnDeathSoundEffect)
            {
                GlobalConfig.SoundPlayer.Play(); // Play the sound effect when the game ends
            }

            EndGameForm endGameForm = new EndGameForm();
            endGameForm.Show(); //Let it show while we continue the postgame work here (shows for 5 seconds, then closes automatically)

            // Store the player's score and difficulty level
            GlobalConfig.HighestScore = Math.Max(GlobalConfig.HighestScore, snakeModel.Score);
            GlobalConfig.UserScores.Add(new UserData
            {
                PlayerName = TxtBox_PlayerName.Text,
                Score = snakeModel.Score,
                Difficulty = SettingManager.CurrentDifficulty,
                Index = GlobalConfig.UserScores.Count // Use the current count as the index for the new entry
            });
            GlobalConfig.UserDataManager.SaveToRegistry(); // Save the user data to the registry


            Btn_StartPlaying.Enabled = true;
            Tmr_Animation.Enabled = false;
            TxtBox_PlayerName.Enabled = true;

            Lb_Status.Text = "Status: GAME OVER!";
            Lb_Status.ForeColor = Color.Red;

            //Shut down the computer if High Risk Mode is enabled
            if (SettingManager.IsHighRiskModeEnabled)
            {
                ShutdownMechanism.ShutdownComputer();
            }

            if (SettingManager.TurnOnDeathSoundEffect)
            {
                GlobalConfig.SoundPlayer.Stream = random.Next(1,10) % 2 == 0 ? Properties.Resources.Sonic_exe_tails_scream : Properties.Resources.slendytubby_scream_made_with_Voicemod; // Set the sound effect file path
                GlobalConfig.SoundPlayer.Load(); // Load the sound effect into memory when the main form loads
            }

            snakeModel.Dispose(); // Dispose of the model to free resources
            snakeUI.Dispose();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tmr_Animation.Stop();
            snakeUI?.Dispose();
            snakeModel?.Dispose();
        }
    }
}
