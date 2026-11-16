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

            //Nothing else other than exiting lol
            this.Close();
        }

        private void ChkBox_Easy_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBox_Easy.Checked)
            {
                ChkBox_Medium.Checked = false;
                ChkBox_Hard.Checked = false;
                GlobalConfig.CurrentDifficulty = GlobalConfig.DifficultyLevel.Easy;
                GlobalConfig.SnakeMovementInterval = (int)GlobalConfig.CurrentDifficulty;
            }
        }

        private void ChkBox_Medium_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBox_Medium.Checked)
            {
                ChkBox_Easy.Checked = false;
                ChkBox_Hard.Checked = false;
                GlobalConfig.CurrentDifficulty = GlobalConfig.DifficultyLevel.Medium;
                GlobalConfig.SnakeMovementInterval = (int)GlobalConfig.CurrentDifficulty;
            }
        }

        private void ChkBox_Hard_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBox_Hard.Checked)
            {
                ChkBox_Easy.Checked = false;
                ChkBox_Medium.Checked = false;
                GlobalConfig.CurrentDifficulty = GlobalConfig.DifficultyLevel.Hard;
                GlobalConfig.SnakeMovementInterval = (int)GlobalConfig.CurrentDifficulty;
            }
        }

        private void DifficultyForm_Load(object sender, EventArgs e)
        {
            ChkBox_Easy.Checked = GlobalConfig.CurrentDifficulty == GlobalConfig.DifficultyLevel.Easy;
            ChkBox_Medium.Checked = GlobalConfig.CurrentDifficulty == GlobalConfig.DifficultyLevel.Medium;
            ChkBox_Hard.Checked = GlobalConfig.CurrentDifficulty == GlobalConfig.DifficultyLevel.Hard;
        }
    }
}
