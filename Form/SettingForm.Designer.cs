namespace Snakey_Game
{
    partial class SettingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ChkBox_DeathSoundEffect = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ColorDlg_BackgroundColor = new System.Windows.Forms.ColorDialog();
            this.Pn_BackgroundColor = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.Pn_ForegroundColor = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.Pn_SnakeColor = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.Pn_AppleColor = new System.Windows.Forms.Panel();
            this.ColorDlg_ForegroundColor = new System.Windows.Forms.ColorDialog();
            this.ColorDlg_SnakeColor = new System.Windows.Forms.ColorDialog();
            this.ColorDlg_AppleColor = new System.Windows.Forms.ColorDialog();
            this.Btn_Apply = new System.Windows.Forms.Button();
            this.Btn_Revert = new System.Windows.Forms.Button();
            this.Lb_Difficulty = new System.Windows.Forms.Label();
            this.Btn_SelectDifficulty = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Death Sound Effect";
            // 
            // ChkBox_DeathSoundEffect
            // 
            this.ChkBox_DeathSoundEffect.AutoSize = true;
            this.ChkBox_DeathSoundEffect.Location = new System.Drawing.Point(308, 74);
            this.ChkBox_DeathSoundEffect.Name = "ChkBox_DeathSoundEffect";
            this.ChkBox_DeathSoundEffect.Size = new System.Drawing.Size(59, 29);
            this.ChkBox_DeathSoundEffect.TabIndex = 2;
            this.ChkBox_DeathSoundEffect.Text = "Off";
            this.ChkBox_DeathSoundEffect.UseVisualStyleBackColor = true;
            this.ChkBox_DeathSoundEffect.CheckedChanged += new System.EventHandler(this.ChkBox_DeathSoundEffect_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Background Color";
            // 
            // ColorDlg_BackgroundColor
            // 
            this.ColorDlg_BackgroundColor.AnyColor = true;
            this.ColorDlg_BackgroundColor.FullOpen = true;
            // 
            // Pn_BackgroundColor
            // 
            this.Pn_BackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pn_BackgroundColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pn_BackgroundColor.Location = new System.Drawing.Point(308, 109);
            this.Pn_BackgroundColor.Name = "Pn_BackgroundColor";
            this.Pn_BackgroundColor.Size = new System.Drawing.Size(59, 25);
            this.Pn_BackgroundColor.TabIndex = 4;
            this.Pn_BackgroundColor.Click += new System.EventHandler(this.Pn_BackgroundColor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Foreground Color";
            // 
            // Pn_ForegroundColor
            // 
            this.Pn_ForegroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pn_ForegroundColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pn_ForegroundColor.Location = new System.Drawing.Point(308, 150);
            this.Pn_ForegroundColor.Name = "Pn_ForegroundColor";
            this.Pn_ForegroundColor.Size = new System.Drawing.Size(59, 25);
            this.Pn_ForegroundColor.TabIndex = 6;
            this.Pn_ForegroundColor.Click += new System.EventHandler(this.Pn_ForegroundColor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Snake Color";
            // 
            // Pn_SnakeColor
            // 
            this.Pn_SnakeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pn_SnakeColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pn_SnakeColor.Location = new System.Drawing.Point(308, 191);
            this.Pn_SnakeColor.Name = "Pn_SnakeColor";
            this.Pn_SnakeColor.Size = new System.Drawing.Size(59, 25);
            this.Pn_SnakeColor.TabIndex = 8;
            this.Pn_SnakeColor.Click += new System.EventHandler(this.Pn_SnakeColor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Apple Color";
            // 
            // Pn_AppleColor
            // 
            this.Pn_AppleColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pn_AppleColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pn_AppleColor.Location = new System.Drawing.Point(308, 232);
            this.Pn_AppleColor.Name = "Pn_AppleColor";
            this.Pn_AppleColor.Size = new System.Drawing.Size(59, 25);
            this.Pn_AppleColor.TabIndex = 10;
            this.Pn_AppleColor.Click += new System.EventHandler(this.Pn_AppleColor_Click);
            // 
            // ColorDlg_ForegroundColor
            // 
            this.ColorDlg_ForegroundColor.AnyColor = true;
            this.ColorDlg_ForegroundColor.FullOpen = true;
            // 
            // ColorDlg_SnakeColor
            // 
            this.ColorDlg_SnakeColor.AnyColor = true;
            this.ColorDlg_SnakeColor.FullOpen = true;
            // 
            // ColorDlg_AppleColor
            // 
            this.ColorDlg_AppleColor.AnyColor = true;
            this.ColorDlg_AppleColor.FullOpen = true;
            // 
            // Btn_Apply
            // 
            this.Btn_Apply.Location = new System.Drawing.Point(12, 359);
            this.Btn_Apply.Name = "Btn_Apply";
            this.Btn_Apply.Size = new System.Drawing.Size(107, 39);
            this.Btn_Apply.TabIndex = 11;
            this.Btn_Apply.Text = "Apply";
            this.Btn_Apply.UseVisualStyleBackColor = false;
            this.Btn_Apply.Click += new System.EventHandler(this.Btn_Apply_Click);
            // 
            // Btn_Revert
            // 
            this.Btn_Revert.Location = new System.Drawing.Point(184, 359);
            this.Btn_Revert.Name = "Btn_Revert";
            this.Btn_Revert.Size = new System.Drawing.Size(217, 39);
            this.Btn_Revert.TabIndex = 12;
            this.Btn_Revert.Text = "Revert to Default";
            this.Btn_Revert.UseVisualStyleBackColor = false;
            this.Btn_Revert.Click += new System.EventHandler(this.Btn_Revert_Click);
            // 
            // Lb_Difficulty
            // 
            this.Lb_Difficulty.AutoSize = true;
            this.Lb_Difficulty.Location = new System.Drawing.Point(12, 293);
            this.Lb_Difficulty.Name = "Lb_Difficulty";
            this.Lb_Difficulty.Size = new System.Drawing.Size(160, 25);
            this.Lb_Difficulty.TabIndex = 13;
            this.Lb_Difficulty.Text = "Game difficulty:";
            // 
            // Btn_SelectDifficulty
            // 
            this.Btn_SelectDifficulty.Location = new System.Drawing.Point(275, 286);
            this.Btn_SelectDifficulty.Name = "Btn_SelectDifficulty";
            this.Btn_SelectDifficulty.Size = new System.Drawing.Size(104, 39);
            this.Btn_SelectDifficulty.TabIndex = 14;
            this.Btn_SelectDifficulty.Text = "Choose";
            this.Btn_SelectDifficulty.UseVisualStyleBackColor = false;
            this.Btn_SelectDifficulty.Click += new System.EventHandler(this.Btn_SelectDifficulty_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(413, 410);
            this.Controls.Add(this.Btn_SelectDifficulty);
            this.Controls.Add(this.Lb_Difficulty);
            this.Controls.Add(this.Btn_Revert);
            this.Controls.Add(this.Btn_Apply);
            this.Controls.Add(this.Pn_AppleColor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Pn_SnakeColor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Pn_ForegroundColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Pn_BackgroundColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChkBox_DeathSoundEffect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ChkBox_DeathSoundEffect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog ColorDlg_BackgroundColor;
        private System.Windows.Forms.Panel Pn_BackgroundColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel Pn_ForegroundColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel Pn_SnakeColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel Pn_AppleColor;
        private System.Windows.Forms.ColorDialog ColorDlg_ForegroundColor;
        private System.Windows.Forms.ColorDialog ColorDlg_SnakeColor;
        private System.Windows.Forms.ColorDialog ColorDlg_AppleColor;
        private System.Windows.Forms.Button Btn_Apply;
        private System.Windows.Forms.Button Btn_Revert;
        private System.Windows.Forms.Label Lb_Difficulty;
        private System.Windows.Forms.Button Btn_SelectDifficulty;
    }
}