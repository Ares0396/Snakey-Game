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
            Dgv_Scoreboard.DataSource = GlobalConfig.UserScores
                .OrderByDescending(user => user.Score)
                .Select(user => new
                {
                    PlayerName = user.PlayerName,
                    Score = user.Score,
                    Difficulty = user.Difficulty.ToString()
                })
                .ToList();
        }
    }
}
