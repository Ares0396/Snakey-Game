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
    public partial class ScoreboardForm : Form
    {
        public ScoreboardForm()
        {
            InitializeComponent();
        }

        private void ScoreboardForm_Load(object sender, EventArgs e)
        {
            UI.ApplySettingToForm(this);
            Dgv_Scoreboard.BackgroundColor = SettingManager.BackgroundColor;
            Dgv_Scoreboard.ForeColor = SettingManager.ForegroundColor;

            Dgv_Scoreboard.DefaultCellStyle.BackColor = SettingManager.BackgroundColor;
            Dgv_Scoreboard.DefaultCellStyle.ForeColor = SettingManager.ForegroundColor;

            Dgv_Scoreboard.ColumnHeadersDefaultCellStyle.BackColor = SettingManager.BackgroundColor;
            Dgv_Scoreboard.ColumnHeadersDefaultCellStyle.ForeColor = SettingManager.ForegroundColor;

            Dgv_Scoreboard.DataSource = GlobalConfig.UserScores
                .OrderByDescending(user => user.Score)
                .Select(user => new
                {
                    user.PlayerName,
                    user.Score,
                    Difficulty = user.Difficulty.ToString()
                })
                .ToList();
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            if (GlobalConfig.UserScores.Count == 0)
            {
                MessageBox.Show("The scoreboard is already empty.", "No Scores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to reset the scoreboard? This action cannot be undone.", "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                GlobalConfig.UserScores.Clear();
                GlobalConfig.UserDataManager.ClearRegistry(); // Clear the registry
                Dgv_Scoreboard.Refresh(); // Refresh the DataGridView to reflect the changes
            }
        }
    }
}
