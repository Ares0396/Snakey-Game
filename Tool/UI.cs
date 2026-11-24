using Snakey_Game.Tool.Manager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snakey_Game.Tool
{
    public class UI
    {
        Panel applePanel;
        List<Panel> snakePanels;
        Form gameForm;

        Model model;

        bool isDisposed = false;

        public UI(Panel applePanel, List<Panel> snakePanels, Model model, Form gameForm)
        {
            this.applePanel = applePanel;
            this.snakePanels = snakePanels;
            this.model = model;
            this.gameForm = gameForm;
        }
        public void ThrowIfDisposed()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("UI has been disposed.");
            }
        }

        public void UpdateUI()
        {
            ThrowIfDisposed();

            GenerateApple();

            Panel newHead = new Panel()
            {
                Size = new Size(GlobalConfig.SnakeSize, GlobalConfig.SnakeSize),
                BackColor = SettingManager.SnakeColor,
                Location = model.CurrentModel[0]
            };
            snakePanels.Insert(0, newHead);
            gameForm.Controls.Add(newHead);

            if (model.CurrentModel.Count < snakePanels.Count)
            {
                Panel tail = snakePanels.Last();
                snakePanels.Remove(tail);
                gameForm.Controls.Remove(tail);
                tail.Dispose();
            }
        }

        public void GenerateApple()
        {
            ThrowIfDisposed();
            applePanel.Location = GlobalConfig.ApplePosition; //The location here is determined by the model, which is updated in the game loop.
        }

        public void Dispose()
        {
            if (isDisposed) return;

            //Let the gameform manually dispose of the panels, since they are added to the form's controls.
            model.Dispose();

            snakePanels = null;
            applePanel = null;
            model = null;

            isDisposed = true;
        }


        // Now these are the parts that apply settings to the UI
        // All methods below are static, simply because they don't need any instance above.
        // So basically, UI works both as the graphics updater and the settings worker.
        public static void ApplySettingToForm(Form form)
        {
            form.BackColor = SettingManager.BackgroundColor;
            form.ForeColor = SettingManager.ForegroundColor;

            // Apply the settings to child controls as well
            foreach (Control control in form.Controls)
            {
                // STOP if the control is a color panel in SettingForm
                if (control is Panel && form is SettingForm)
                {
                    continue; // Continue to the next because every panel in SettingForm is a color panel
                }

                // Also STOP if you get to the labels in DifficultyForm
                if (control is DifficultyForm && form is DifficultyForm)
                {
                    continue;
                }
                control.BackColor = SettingManager.BackgroundColor;
                control.ForeColor = SettingManager.ForegroundColor;
            }
        }
    }
}
