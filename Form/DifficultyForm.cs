using Snakey_Game.Tool;
using Snakey_Game.Tool.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snakey_Game
{
    public partial class DifficultyForm : Form
    {
        public DifficultyForm()
        {
            InitializeComponent();
        }

        private void Btn_Done_Click(object sender, EventArgs e)
        {
            if (!ChkBox_Easy.Checked && !ChkBox_Medium.Checked && !ChkBox_Hard.Checked)
            {
                MessageBox.Show("Please select a difficulty level before proceeding.", "Difficulty Level Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SettingManager.SaveSettingsToRegistry(); // Only difficulty level is affected since only difficulty is changed here, but we can save all settings for consistency.
            this.Close();
        }

        private void ChkBox_Easy_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBox_Easy.Checked)
            {
                ChkBox_Medium.Checked = false;
                ChkBox_Hard.Checked = false;
                SettingManager.CurrentDifficulty = GlobalConfig.DifficultyLevel.Easy;
                GlobalConfig.SnakeMovementInterval = (int)SettingManager.CurrentDifficulty;
            }
        }

        private void ChkBox_Medium_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBox_Medium.Checked)
            {
                ChkBox_Easy.Checked = false;
                ChkBox_Hard.Checked = false;
                SettingManager.CurrentDifficulty = GlobalConfig.DifficultyLevel.Medium;
                GlobalConfig.SnakeMovementInterval = (int)SettingManager.CurrentDifficulty;
            }
        }

        private void ChkBox_Hard_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBox_Hard.Checked)
            {
                ChkBox_Easy.Checked = false;
                ChkBox_Medium.Checked = false;
                SettingManager.CurrentDifficulty = GlobalConfig.DifficultyLevel.Hard;
                GlobalConfig.SnakeMovementInterval = (int)SettingManager.CurrentDifficulty;
            }
        }

        private void DifficultyForm_Load(object sender, EventArgs e)
        {
            BackColor = SettingManager.BackgroundColor;
            ForeColor = SettingManager.ForegroundColor;
            foreach (Control control in this.Controls)
            {
                if (control is Label) control.BackColor = BackColor;
            }

            ChkBox_Easy.Checked = SettingManager.CurrentDifficulty == GlobalConfig.DifficultyLevel.Easy;
            ChkBox_Medium.Checked = SettingManager.CurrentDifficulty == GlobalConfig.DifficultyLevel.Medium;
            ChkBox_Hard.Checked = SettingManager.CurrentDifficulty == GlobalConfig.DifficultyLevel.Hard;
        }

        private void ChkBox_HighRisk_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBox_HighRisk.Checked)
            {
                if (MessageBox.Show("Are you sure you want to enable High Risk Mode? This will shut the computer down when the snake dies.", "Confirm Enable High Risk Mode", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    ChkBox_HighRisk.Checked = false; // Re-disable the checkbox if the user cancels
                    return;
                }
            }
            SettingManager.IsHighRiskModeEnabled = ChkBox_HighRisk.Checked;
        }
    }
}
