namespace Snakey_Game
{
    partial class DifficultyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChkBox_Easy = new System.Windows.Forms.CheckBox();
            this.ChkBox_Medium = new System.Windows.Forms.CheckBox();
            this.ChkBox_Hard = new System.Windows.Forms.CheckBox();
            this.Btn_Done = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChkBox_Easy
            // 
            this.ChkBox_Easy.AutoSize = true;
            this.ChkBox_Easy.ForeColor = System.Drawing.Color.LightGreen;
            this.ChkBox_Easy.Location = new System.Drawing.Point(12, 126);
            this.ChkBox_Easy.Name = "ChkBox_Easy";
            this.ChkBox_Easy.Size = new System.Drawing.Size(372, 29);
            this.ChkBox_Easy.TabIndex = 0;
            this.ChkBox_Easy.Text = "I\'M A BABY, PLEASE FORGIVE ME";
            this.ChkBox_Easy.UseVisualStyleBackColor = true;
            this.ChkBox_Easy.CheckedChanged += new System.EventHandler(this.ChkBox_Easy_CheckedChanged);
            // 
            // ChkBox_Medium
            // 
            this.ChkBox_Medium.AutoSize = true;
            this.ChkBox_Medium.ForeColor = System.Drawing.Color.Yellow;
            this.ChkBox_Medium.Location = new System.Drawing.Point(12, 161);
            this.ChkBox_Medium.Name = "ChkBox_Medium";
            this.ChkBox_Medium.Size = new System.Drawing.Size(142, 29);
            this.ChkBox_Medium.TabIndex = 1;
            this.ChkBox_Medium.Text = "Just normal";
            this.ChkBox_Medium.UseVisualStyleBackColor = true;
            this.ChkBox_Medium.CheckedChanged += new System.EventHandler(this.ChkBox_Medium_CheckedChanged);
            // 
            // ChkBox_Hard
            // 
            this.ChkBox_Hard.AutoSize = true;
            this.ChkBox_Hard.ForeColor = System.Drawing.Color.Red;
            this.ChkBox_Hard.Location = new System.Drawing.Point(12, 196);
            this.ChkBox_Hard.Name = "ChkBox_Hard";
            this.ChkBox_Hard.Size = new System.Drawing.Size(324, 29);
            this.ChkBox_Hard.TabIndex = 2;
            this.ChkBox_Hard.Text = "Who says I\'m not good at this?";
            this.ChkBox_Hard.UseVisualStyleBackColor = true;
            this.ChkBox_Hard.CheckedChanged += new System.EventHandler(this.ChkBox_Hard_CheckedChanged);
            // 
            // Btn_Done
            // 
            this.Btn_Done.Location = new System.Drawing.Point(183, 278);
            this.Btn_Done.Name = "Btn_Done";
            this.Btn_Done.Size = new System.Drawing.Size(110, 51);
            this.Btn_Done.TabIndex = 3;
            this.Btn_Done.Text = "Done";
            this.Btn_Done.UseVisualStyleBackColor = false;
            this.Btn_Done.Click += new System.EventHandler(this.Btn_Done_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "How difficult do you want the game to be?";
            // 
            // DifficultyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(473, 343);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Done);
            this.Controls.Add(this.ChkBox_Hard);
            this.Controls.Add(this.ChkBox_Medium);
            this.Controls.Add(this.ChkBox_Easy);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "DifficultyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select the difficulty";
            this.Load += new System.EventHandler(this.DifficultyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ChkBox_Easy;
        private System.Windows.Forms.CheckBox ChkBox_Medium;
        private System.Windows.Forms.CheckBox ChkBox_Hard;
        private System.Windows.Forms.Button Btn_Done;
        private System.Windows.Forms.Label label1;
    }
}