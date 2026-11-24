using Snakey_Game.Tool;
using Snakey_Game.Tool.Manager;
using System;
using System.Windows.Forms;

namespace Snakey_Game
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void ChkBox_DeathSoundEffect_CheckedChanged(object sender, EventArgs e)
        {
            SettingManager.TurnOnDeathSoundEffect = ChkBox_DeathSoundEffect.Checked;
            if (SettingManager.TurnOnDeathSoundEffect)
            {
                ChkBox_DeathSoundEffect.Text = "On";
            }
            else
            {
                ChkBox_DeathSoundEffect.Text = "Off";
            }
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            UI.ApplySettingToForm(this);

            ChkBox_DeathSoundEffect.Checked = SettingManager.TurnOnDeathSoundEffect;
            Pn_BackgroundColor.BackColor = SettingManager.BackgroundColor;
            Pn_ForegroundColor.BackColor = SettingManager.ForegroundColor;
            Pn_SnakeColor.BackColor = SettingManager.SnakeColor;
            Pn_AppleColor.BackColor = SettingManager.AppleColor;

            Lb_Difficulty.Text = $"Game difficulty: {SettingManager.CurrentDifficulty}";
        }
        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ChkBox_DeathSoundEffect.Checked != SettingManager.TurnOnDeathSoundEffect ||
            Pn_BackgroundColor.BackColor != SettingManager.BackgroundColor ||
            Pn_ForegroundColor.BackColor != SettingManager.ForegroundColor ||
            Pn_SnakeColor.BackColor != SettingManager.SnakeColor ||
            Pn_AppleColor.BackColor != SettingManager.AppleColor)
            {
                MessageBox.Show("You have unsaved settings.", "Unsaved settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void Pn_BackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDlg_BackgroundColor.ShowDialog();
            Pn_BackgroundColor.BackColor = ColorDlg_BackgroundColor.Color;
        }

        private void Pn_ForegroundColor_Click(object sender, EventArgs e)
        {
            ColorDlg_ForegroundColor.ShowDialog();
            Pn_ForegroundColor.BackColor = ColorDlg_ForegroundColor.Color;
        }

        private void Pn_SnakeColor_Click(object sender, EventArgs e)
        {
            ColorDlg_SnakeColor.ShowDialog();
            Pn_SnakeColor.BackColor = ColorDlg_SnakeColor.Color;
        }

        private void Pn_AppleColor_Click(object sender, EventArgs e)
        {
            ColorDlg_AppleColor.ShowDialog();
            Pn_AppleColor.BackColor = ColorDlg_AppleColor.Color;
        }

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            // Save the settings
            SettingManager.TurnOnDeathSoundEffect = ChkBox_DeathSoundEffect.Checked;
            SettingManager.BackgroundColor = Pn_BackgroundColor.BackColor;
            SettingManager.ForegroundColor = Pn_ForegroundColor.BackColor;
            SettingManager.SnakeColor = Pn_SnakeColor.BackColor;
            SettingManager.AppleColor = Pn_AppleColor.BackColor;
            SettingManager.SaveSettingsToRegistry();

            // Use UI to apply settings across the app
            UI.ApplySettingToForm(this);
        }

        private void Btn_Revert_Click(object sender, EventArgs e)
        {
            SettingManager.RevertToDefault(true); // Save settings as well
            UI.ApplySettingToForm(this); // Refresh the window

            // Reset setting interface
            ChkBox_DeathSoundEffect.Checked = SettingManager.TurnOnDeathSoundEffect;
            Pn_BackgroundColor.BackColor = SettingManager.BackgroundColor;
            Pn_ForegroundColor.BackColor = SettingManager.ForegroundColor;
            Pn_SnakeColor.BackColor = SettingManager.SnakeColor;
            Pn_AppleColor.BackColor = SettingManager.AppleColor;
        }

        private void Btn_SelectDifficulty_Click(object sender, EventArgs e)
        {
            DifficultyForm form = new DifficultyForm();
            form.ShowDialog();

            Lb_Difficulty.Text = $"Game difficulty: {SettingManager.CurrentDifficulty}"; // Update difficulty label
        }
    }
}
