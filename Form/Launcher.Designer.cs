namespace Snakey_Game
{
    partial class Launcher
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
            this.Btn_AuthorInfo = new System.Windows.Forms.Button();
            this.Btn_Scoreboard = new System.Windows.Forms.Button();
            this.Btn_SetDifficulty = new System.Windows.Forms.Button();
            this.Btn_Play = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Setting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_AuthorInfo
            // 
            this.Btn_AuthorInfo.ForeColor = System.Drawing.Color.White;
            this.Btn_AuthorInfo.Location = new System.Drawing.Point(14, 314);
            this.Btn_AuthorInfo.Name = "Btn_AuthorInfo";
            this.Btn_AuthorInfo.Size = new System.Drawing.Size(399, 40);
            this.Btn_AuthorInfo.TabIndex = 9;
            this.Btn_AuthorInfo.Text = "About the author";
            this.Btn_AuthorInfo.UseVisualStyleBackColor = false;
            this.Btn_AuthorInfo.Click += new System.EventHandler(this.Btn_AuthorInfo_Click);
            // 
            // Btn_Scoreboard
            // 
            this.Btn_Scoreboard.ForeColor = System.Drawing.Color.White;
            this.Btn_Scoreboard.Location = new System.Drawing.Point(14, 222);
            this.Btn_Scoreboard.Name = "Btn_Scoreboard";
            this.Btn_Scoreboard.Size = new System.Drawing.Size(399, 40);
            this.Btn_Scoreboard.TabIndex = 8;
            this.Btn_Scoreboard.Text = "Scoreboard";
            this.Btn_Scoreboard.UseVisualStyleBackColor = false;
            this.Btn_Scoreboard.Click += new System.EventHandler(this.Btn_Scoreboard_Click);
            // 
            // Btn_SetDifficulty
            // 
            this.Btn_SetDifficulty.ForeColor = System.Drawing.Color.White;
            this.Btn_SetDifficulty.Location = new System.Drawing.Point(14, 176);
            this.Btn_SetDifficulty.Name = "Btn_SetDifficulty";
            this.Btn_SetDifficulty.Size = new System.Drawing.Size(399, 40);
            this.Btn_SetDifficulty.TabIndex = 7;
            this.Btn_SetDifficulty.Text = "Difficulty";
            this.Btn_SetDifficulty.UseVisualStyleBackColor = false;
            this.Btn_SetDifficulty.Click += new System.EventHandler(this.Btn_SetDifficulty_Click);
            // 
            // Btn_Play
            // 
            this.Btn_Play.ForeColor = System.Drawing.Color.White;
            this.Btn_Play.Location = new System.Drawing.Point(14, 130);
            this.Btn_Play.Name = "Btn_Play";
            this.Btn_Play.Size = new System.Drawing.Size(399, 40);
            this.Btn_Play.TabIndex = 6;
            this.Btn_Play.Text = "LET\'S PLAY!";
            this.Btn_Play.UseVisualStyleBackColor = false;
            this.Btn_Play.Click += new System.EventHandler(this.Btn_Play_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Welcome to Ares0396\'s SNAKEY GAME!";
            // 
            // Btn_Setting
            // 
            this.Btn_Setting.ForeColor = System.Drawing.Color.White;
            this.Btn_Setting.Location = new System.Drawing.Point(14, 268);
            this.Btn_Setting.Name = "Btn_Setting";
            this.Btn_Setting.Size = new System.Drawing.Size(399, 40);
            this.Btn_Setting.TabIndex = 10;
            this.Btn_Setting.Text = "Setting";
            this.Btn_Setting.UseVisualStyleBackColor = false;
            this.Btn_Setting.Click += new System.EventHandler(this.Btn_Setting_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(422, 377);
            this.Controls.Add(this.Btn_Setting);
            this.Controls.Add(this.Btn_AuthorInfo);
            this.Controls.Add(this.Btn_Scoreboard);
            this.Controls.Add(this.Btn_SetDifficulty);
            this.Controls.Add(this.Btn_Play);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snakey Game v1.0";
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_AuthorInfo;
        private System.Windows.Forms.Button Btn_Scoreboard;
        private System.Windows.Forms.Button Btn_SetDifficulty;
        private System.Windows.Forms.Button Btn_Play;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Setting;
    }
}