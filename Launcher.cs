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
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
        }

        private void Btn_Play_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            this.Show();
        }

        private void Btn_SetDifficulty_Click(object sender, EventArgs e)
        {
            DifficultyForm difficultyForm = new DifficultyForm();
            difficultyForm.ShowDialog();
        }

        private void Btn_Scoreboard_Click(object sender, EventArgs e)
        {
            ScoreboardForm scoreboardForm = new ScoreboardForm();
            scoreboardForm.ShowDialog();
        }

        private void Btn_AuthorInfo_Click(object sender, EventArgs e)
        {
            AboutAuthorForm aboutAuthorForm = new AboutAuthorForm();
            aboutAuthorForm.ShowDialog();
        }
    }
}
