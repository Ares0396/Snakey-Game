using Snakey_Game.Tool;
using System;
using System.Windows.Forms;

namespace Snakey_Game
{
    public partial class AboutAuthorForm : Form
    {
        public AboutAuthorForm()
        {
            InitializeComponent();
        }

        private void AboutAuthorForm_Load(object sender, EventArgs e)
        {
            UI.ApplySettingToForm(this);
        }
    }
}
