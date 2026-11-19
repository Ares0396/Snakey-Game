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
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void ChkBox_DeathSoundEffect_CheckedChanged(object sender, EventArgs e)
        {
            GlobalConfig.TurnOnDeathSoundEffect = ChkBox_DeathSoundEffect.Checked;
            if (GlobalConfig.TurnOnDeathSoundEffect)
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
            ChkBox_DeathSoundEffect.Checked = GlobalConfig.TurnOnDeathSoundEffect;
        }
    }
}
