using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snakey_Game
{
    public partial class EndGameForm : Form
    {
        bool canClose = false;

        public EndGameForm()
        {
            InitializeComponent();
        }

        private void EndGameForm_Load(object sender, EventArgs e)
        {
            Tmr_FormClose.Enabled = true;
            Tmr_FormClose.Start();
        }

        private void Tmr_FormClose_Tick(object sender, EventArgs e)
        {
            Tmr_FormClose.Stop();
            canClose = true;
            Close();
        }

        private void EndGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canClose)
            {
                e.Cancel = true; // Cancel the close event if the form is not allowed to close yet
                return;
            }
            GlobalConfig.SoundPlayer.Stop(); // Stop the sound effect if the user presses Escape
        }

        private void EndGameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Note: Have to press, then release
            if (e.KeyChar == (char)Keys.Escape)
            {
                canClose = true;
                Close();
            }
        }
    }
}
