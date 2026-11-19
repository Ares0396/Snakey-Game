namespace Snakey_Game
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.Lb_Score = new System.Windows.Forms.Label();
            this.Lb_HighestScore = new System.Windows.Forms.Label();
            this.TxtBox_PlayerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_StartPlaying = new System.Windows.Forms.Button();
            this.Tmr_Animation = new System.Windows.Forms.Timer(this.components);
            this.Lb_Status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lb_Score
            // 
            this.Lb_Score.AutoSize = true;
            this.Lb_Score.Location = new System.Drawing.Point(47, 33);
            this.Lb_Score.Name = "Lb_Score";
            this.Lb_Score.Size = new System.Drawing.Size(169, 25);
            this.Lb_Score.TabIndex = 0;
            this.Lb_Score.Text = "Current Score: 0";
            // 
            // Lb_HighestScore
            // 
            this.Lb_HighestScore.AutoSize = true;
            this.Lb_HighestScore.Location = new System.Drawing.Point(47, 78);
            this.Lb_HighestScore.Name = "Lb_HighestScore";
            this.Lb_HighestScore.Size = new System.Drawing.Size(171, 25);
            this.Lb_HighestScore.TabIndex = 1;
            this.Lb_HighestScore.Text = "Highest Score: 0";
            // 
            // TxtBox_PlayerName
            // 
            this.TxtBox_PlayerName.BackColor = System.Drawing.Color.Black;
            this.TxtBox_PlayerName.ForeColor = System.Drawing.Color.White;
            this.TxtBox_PlayerName.Location = new System.Drawing.Point(52, 192);
            this.TxtBox_PlayerName.Name = "TxtBox_PlayerName";
            this.TxtBox_PlayerName.Size = new System.Drawing.Size(164, 31);
            this.TxtBox_PlayerName.TabIndex = 2;
            this.TxtBox_PlayerName.Text = "Player 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name:";
            // 
            // Btn_StartPlaying
            // 
            this.Btn_StartPlaying.ForeColor = System.Drawing.Color.White;
            this.Btn_StartPlaying.Location = new System.Drawing.Point(52, 243);
            this.Btn_StartPlaying.Name = "Btn_StartPlaying";
            this.Btn_StartPlaying.Size = new System.Drawing.Size(164, 45);
            this.Btn_StartPlaying.TabIndex = 4;
            this.Btn_StartPlaying.Text = "Start PLaying";
            this.Btn_StartPlaying.UseVisualStyleBackColor = false;
            this.Btn_StartPlaying.Click += new System.EventHandler(this.Btn_StartPlaying_Click);
            // 
            // Tmr_Animation
            // 
            this.Tmr_Animation.Tick += new System.EventHandler(this.Tmr_Animation_Tick);
            // 
            // Lb_Status
            // 
            this.Lb_Status.AutoSize = true;
            this.Lb_Status.Location = new System.Drawing.Point(47, 347);
            this.Lb_Status.Name = "Lb_Status";
            this.Lb_Status.Size = new System.Drawing.Size(119, 25);
            this.Lb_Status.TabIndex = 5;
            this.Lb_Status.Text = "Status: Idle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 451);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 120);
            this.label1.TabIndex = 6;
            this.label1.Text = "Press W to move up.\r\nPress A to move left.\r\nPress S to move down.\r\nPress D to mov" +
    "e right.\r\nPress Space to pause.\r\nPress Esc to exit the Death screen";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1184, 631);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lb_Status);
            this.Controls.Add(this.Btn_StartPlaying);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtBox_PlayerName);
            this.Controls.Add(this.Lb_HighestScore);
            this.Controls.Add(this.Lb_Score);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snakey Game v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lb_Score;
        private System.Windows.Forms.Label Lb_HighestScore;
        private System.Windows.Forms.TextBox TxtBox_PlayerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_StartPlaying;
        private System.Windows.Forms.Timer Tmr_Animation;
        private System.Windows.Forms.Label Lb_Status;
        private System.Windows.Forms.Label label1;
    }
}