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
            //Sound effect here
            SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.Sonic_exe_tails_scream);
            soundPlayer.Load();

            Thread.Sleep(200); // Wait for 200 milliseconds to ensure the sound is loaded before playing

            soundPlayer.Play(); // Play the sound effect when the form is shown
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
            }
        }
    }
}
