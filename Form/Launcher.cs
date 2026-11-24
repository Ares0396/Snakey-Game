using Snakey_Game.Tool;
using Snakey_Game.Tool.Manager;
using System;
using System.Windows.Forms;

namespace Snakey_Game
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
            GlobalConfig.UserDataManager = new UserDataManager();
            GlobalConfig.UserDataManager.LoadFromRegistry(); // Load the user data from the registry
        }

        private void Btn_Play_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm mainForm = new GameForm();
            mainForm.ShowDialog();
            this.Show();
        }

        private void Btn_SetDifficulty_Click(object sender, EventArgs e)
        {
            DifficultyForm difficultyForm = new DifficultyForm();
            difficultyForm.ShowDialog(this);
        }

        private void Btn_Scoreboard_Click(object sender, EventArgs e)
        {
            ScoreboardForm scoreboardForm = new ScoreboardForm();
            scoreboardForm.ShowDialog(this);
        }

        private void Btn_AuthorInfo_Click(object sender, EventArgs e)
        {
            AboutAuthorForm aboutAuthorForm = new AboutAuthorForm();
            aboutAuthorForm.ShowDialog(this);
        }

        private void Btn_Setting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.ShowDialog(this);

            // Because some settings might have been changed, we'll re-update the UI here
            UI.ApplySettingToForm(this);
        }

        private void Launcher_Load(object sender, EventArgs e)
        {
            SettingManager.LoadSettingsFromRegistry();
            UI.ApplySettingToForm(this);
        }
    }
}
