namespace MatchingGameApp
{
    partial class MatchingGame
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
            tblMain = new TableLayoutPanel();
            tblToolbar = new TableLayoutPanel();
            btnStart = new Button();
            opt2Player = new RadioButton();
            optAgainstComputer = new RadioButton();
            lblScore = new Label();
            lblPlayer1Score = new Label();
            lblPlayer2Score = new Label();
            tblGameStatus = new TableLayoutPanel();
            llblGameStatus = new Label();
            tblMatchingCards = new TableLayoutPanel();
            btnMatch1 = new Button();
            btnMatch2 = new Button();
            btnMatch3 = new Button();
            btnMatch4 = new Button();
            btnMatch5 = new Button();
            btnMatch6 = new Button();
            btnMatch7 = new Button();
            btnMatch8 = new Button();
            btnMatch9 = new Button();
            btnMatch10 = new Button();
            btnMatch11 = new Button();
            btnMatch12 = new Button();
            btnMatch13 = new Button();
            btnMatch14 = new Button();
            btnMatch15 = new Button();
            btnMatch16 = new Button();
            btnMatch17 = new Button();
            btnMatch18 = new Button();
            btnMatch19 = new Button();
            btnMatch20 = new Button();
            btnMatch21 = new Button();
            btnMatch22 = new Button();
            btnMatch23 = new Button();
            btnMatch24 = new Button();
            btnMatch25 = new Button();
            tblMain.SuspendLayout();
            tblToolbar.SuspendLayout();
            tblGameStatus.SuspendLayout();
            tblMatchingCards.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(tblToolbar, 0, 0);
            tblMain.Controls.Add(tblGameStatus, 0, 1);
            tblMain.Controls.Add(tblMatchingCards, 0, 2);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 3;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tblMain.Size = new Size(800, 698);
            tblMain.TabIndex = 0;
            // 
            // tblToolbar
            // 
            tblToolbar.BackColor = SystemColors.ControlDarkDark;
            tblToolbar.ColumnCount = 6;
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.63084F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.7065611F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.77009F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.6308336F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.6308336F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.6308336F));
            tblToolbar.Controls.Add(btnStart, 0, 0);
            tblToolbar.Controls.Add(opt2Player, 1, 0);
            tblToolbar.Controls.Add(optAgainstComputer, 2, 0);
            tblToolbar.Controls.Add(lblScore, 3, 0);
            tblToolbar.Controls.Add(lblPlayer1Score, 4, 0);
            tblToolbar.Controls.Add(lblPlayer2Score, 5, 0);
            tblToolbar.Dock = DockStyle.Fill;
            tblToolbar.Location = new Point(3, 3);
            tblToolbar.Name = "tblToolbar";
            tblToolbar.RowCount = 1;
            tblToolbar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblToolbar.Size = new Size(794, 63);
            tblToolbar.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnStart.BackColor = SystemColors.ButtonHighlight;
            btnStart.FlatStyle = FlatStyle.Popup;
            btnStart.Location = new Point(3, 3);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(110, 57);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            // 
            // opt2Player
            // 
            opt2Player.AutoSize = true;
            opt2Player.Checked = true;
            opt2Player.Dock = DockStyle.Fill;
            opt2Player.Location = new Point(119, 3);
            opt2Player.Name = "opt2Player";
            opt2Player.Size = new Size(86, 57);
            opt2Player.TabIndex = 1;
            opt2Player.TabStop = true;
            opt2Player.Text = "2 Player";
            opt2Player.UseVisualStyleBackColor = true;
            // 
            // optAgainstComputer
            // 
            optAgainstComputer.AutoSize = true;
            optAgainstComputer.Dock = DockStyle.Fill;
            optAgainstComputer.Location = new Point(211, 3);
            optAgainstComputer.Name = "optAgainstComputer";
            optAgainstComputer.Size = new Size(230, 57);
            optAgainstComputer.TabIndex = 2;
            optAgainstComputer.Text = "play agains the computer";
            optAgainstComputer.UseVisualStyleBackColor = true;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Dock = DockStyle.Fill;
            lblScore.Location = new Point(447, 0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(110, 63);
            lblScore.TabIndex = 3;
            lblScore.Text = "Score:";
            lblScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayer1Score
            // 
            lblPlayer1Score.AutoSize = true;
            lblPlayer1Score.Dock = DockStyle.Fill;
            lblPlayer1Score.Location = new Point(563, 0);
            lblPlayer1Score.Name = "lblPlayer1Score";
            lblPlayer1Score.Size = new Size(110, 63);
            lblPlayer1Score.TabIndex = 4;
            lblPlayer1Score.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayer2Score
            // 
            lblPlayer2Score.AutoSize = true;
            lblPlayer2Score.Dock = DockStyle.Fill;
            lblPlayer2Score.Location = new Point(679, 0);
            lblPlayer2Score.Name = "lblPlayer2Score";
            lblPlayer2Score.Size = new Size(112, 63);
            lblPlayer2Score.TabIndex = 5;
            lblPlayer2Score.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblGameStatus
            // 
            tblGameStatus.ColumnCount = 5;
            tblGameStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblGameStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblGameStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblGameStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblGameStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblGameStatus.Controls.Add(llblGameStatus, 1, 0);
            tblGameStatus.Dock = DockStyle.Fill;
            tblGameStatus.Location = new Point(3, 72);
            tblGameStatus.Name = "tblGameStatus";
            tblGameStatus.RowCount = 1;
            tblGameStatus.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblGameStatus.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblGameStatus.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblGameStatus.Size = new Size(794, 63);
            tblGameStatus.TabIndex = 1;
            // 
            // llblGameStatus
            // 
            llblGameStatus.AutoSize = true;
            llblGameStatus.BackColor = Color.SteelBlue;
            tblGameStatus.SetColumnSpan(llblGameStatus, 3);
            llblGameStatus.Dock = DockStyle.Fill;
            llblGameStatus.Location = new Point(161, 0);
            llblGameStatus.Name = "llblGameStatus";
            llblGameStatus.Size = new Size(468, 63);
            llblGameStatus.TabIndex = 0;
            llblGameStatus.Text = "Game Status: ";
            llblGameStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblMatchingCards
            // 
            tblMatchingCards.ColumnCount = 5;
            tblMatchingCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblMatchingCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblMatchingCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblMatchingCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblMatchingCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblMatchingCards.Controls.Add(btnMatch1, 0, 0);
            tblMatchingCards.Controls.Add(btnMatch2, 1, 0);
            tblMatchingCards.Controls.Add(btnMatch3, 2, 0);
            tblMatchingCards.Controls.Add(btnMatch4, 3, 0);
            tblMatchingCards.Controls.Add(btnMatch5, 4, 0);
            tblMatchingCards.Controls.Add(btnMatch6, 0, 1);
            tblMatchingCards.Controls.Add(btnMatch7, 1, 1);
            tblMatchingCards.Controls.Add(btnMatch8, 2, 1);
            tblMatchingCards.Controls.Add(btnMatch9, 3, 1);
            tblMatchingCards.Controls.Add(btnMatch10, 4, 1);
            tblMatchingCards.Controls.Add(btnMatch11, 0, 2);
            tblMatchingCards.Controls.Add(btnMatch12, 1, 2);
            tblMatchingCards.Controls.Add(btnMatch13, 2, 2);
            tblMatchingCards.Controls.Add(btnMatch14, 3, 2);
            tblMatchingCards.Controls.Add(btnMatch15, 4, 2);
            tblMatchingCards.Controls.Add(btnMatch16, 0, 3);
            tblMatchingCards.Controls.Add(btnMatch17, 1, 3);
            tblMatchingCards.Controls.Add(btnMatch18, 2, 3);
            tblMatchingCards.Controls.Add(btnMatch19, 3, 3);
            tblMatchingCards.Controls.Add(btnMatch20, 4, 3);
            tblMatchingCards.Controls.Add(btnMatch21, 0, 4);
            tblMatchingCards.Controls.Add(btnMatch22, 1, 4);
            tblMatchingCards.Controls.Add(btnMatch23, 2, 4);
            tblMatchingCards.Controls.Add(btnMatch24, 3, 4);
            tblMatchingCards.Controls.Add(btnMatch25, 4, 4);
            tblMatchingCards.Dock = DockStyle.Fill;
            tblMatchingCards.Location = new Point(3, 141);
            tblMatchingCards.Name = "tblMatchingCards";
            tblMatchingCards.RowCount = 5;
            tblMatchingCards.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblMatchingCards.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblMatchingCards.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblMatchingCards.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblMatchingCards.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblMatchingCards.Size = new Size(794, 554);
            tblMatchingCards.TabIndex = 2;
            // 
            // btnMatch1
            // 
            btnMatch1.BackColor = Color.DarkBlue;
            btnMatch1.Dock = DockStyle.Fill;
            btnMatch1.Location = new Point(3, 3);
            btnMatch1.Name = "btnMatch1";
            btnMatch1.Size = new Size(152, 104);
            btnMatch1.TabIndex = 0;
            btnMatch1.UseVisualStyleBackColor = false;
            // 
            // btnMatch2
            // 
            btnMatch2.BackColor = Color.DarkBlue;
            btnMatch2.Dock = DockStyle.Fill;
            btnMatch2.Location = new Point(161, 3);
            btnMatch2.Name = "btnMatch2";
            btnMatch2.Size = new Size(152, 104);
            btnMatch2.TabIndex = 1;
            btnMatch2.UseVisualStyleBackColor = false;
            // 
            // btnMatch3
            // 
            btnMatch3.BackColor = Color.DarkBlue;
            btnMatch3.Dock = DockStyle.Fill;
            btnMatch3.Location = new Point(319, 3);
            btnMatch3.Name = "btnMatch3";
            btnMatch3.Size = new Size(152, 104);
            btnMatch3.TabIndex = 2;
            btnMatch3.UseVisualStyleBackColor = false;
            // 
            // btnMatch4
            // 
            btnMatch4.BackColor = Color.DarkBlue;
            btnMatch4.Dock = DockStyle.Fill;
            btnMatch4.Location = new Point(477, 3);
            btnMatch4.Name = "btnMatch4";
            btnMatch4.Size = new Size(152, 104);
            btnMatch4.TabIndex = 3;
            btnMatch4.UseVisualStyleBackColor = false;
            // 
            // btnMatch5
            // 
            btnMatch5.BackColor = Color.DarkBlue;
            btnMatch5.Dock = DockStyle.Fill;
            btnMatch5.Location = new Point(635, 3);
            btnMatch5.Name = "btnMatch5";
            btnMatch5.Size = new Size(156, 104);
            btnMatch5.TabIndex = 4;
            btnMatch5.UseVisualStyleBackColor = false;
            // 
            // btnMatch6
            // 
            btnMatch6.BackColor = Color.DarkBlue;
            btnMatch6.Dock = DockStyle.Fill;
            btnMatch6.Location = new Point(3, 113);
            btnMatch6.Name = "btnMatch6";
            btnMatch6.Size = new Size(152, 104);
            btnMatch6.TabIndex = 5;
            btnMatch6.UseVisualStyleBackColor = false;
            // 
            // btnMatch7
            // 
            btnMatch7.BackColor = Color.DarkBlue;
            btnMatch7.Dock = DockStyle.Fill;
            btnMatch7.Location = new Point(161, 113);
            btnMatch7.Name = "btnMatch7";
            btnMatch7.Size = new Size(152, 104);
            btnMatch7.TabIndex = 6;
            btnMatch7.UseVisualStyleBackColor = false;
            // 
            // btnMatch8
            // 
            btnMatch8.BackColor = Color.DarkBlue;
            btnMatch8.Dock = DockStyle.Fill;
            btnMatch8.Location = new Point(319, 113);
            btnMatch8.Name = "btnMatch8";
            btnMatch8.Size = new Size(152, 104);
            btnMatch8.TabIndex = 7;
            btnMatch8.UseVisualStyleBackColor = false;
            // 
            // btnMatch9
            // 
            btnMatch9.BackColor = Color.DarkBlue;
            btnMatch9.Dock = DockStyle.Fill;
            btnMatch9.Location = new Point(477, 113);
            btnMatch9.Name = "btnMatch9";
            btnMatch9.Size = new Size(152, 104);
            btnMatch9.TabIndex = 8;
            btnMatch9.UseVisualStyleBackColor = false;
            // 
            // btnMatch10
            // 
            btnMatch10.BackColor = Color.DarkBlue;
            btnMatch10.Dock = DockStyle.Fill;
            btnMatch10.Location = new Point(635, 113);
            btnMatch10.Name = "btnMatch10";
            btnMatch10.Size = new Size(156, 104);
            btnMatch10.TabIndex = 9;
            btnMatch10.UseVisualStyleBackColor = false;
            // 
            // btnMatch11
            // 
            btnMatch11.BackColor = Color.DarkBlue;
            btnMatch11.Dock = DockStyle.Fill;
            btnMatch11.Location = new Point(3, 223);
            btnMatch11.Name = "btnMatch11";
            btnMatch11.Size = new Size(152, 104);
            btnMatch11.TabIndex = 10;
            btnMatch11.UseVisualStyleBackColor = false;
            // 
            // btnMatch12
            // 
            btnMatch12.BackColor = Color.DarkBlue;
            btnMatch12.Dock = DockStyle.Fill;
            btnMatch12.Location = new Point(161, 223);
            btnMatch12.Name = "btnMatch12";
            btnMatch12.Size = new Size(152, 104);
            btnMatch12.TabIndex = 11;
            btnMatch12.UseVisualStyleBackColor = false;
            // 
            // btnMatch13
            // 
            btnMatch13.BackColor = Color.DarkBlue;
            btnMatch13.Dock = DockStyle.Fill;
            btnMatch13.Location = new Point(319, 223);
            btnMatch13.Name = "btnMatch13";
            btnMatch13.Size = new Size(152, 104);
            btnMatch13.TabIndex = 12;
            btnMatch13.UseVisualStyleBackColor = false;
            // 
            // btnMatch14
            // 
            btnMatch14.BackColor = Color.DarkBlue;
            btnMatch14.Dock = DockStyle.Fill;
            btnMatch14.Location = new Point(477, 223);
            btnMatch14.Name = "btnMatch14";
            btnMatch14.Size = new Size(152, 104);
            btnMatch14.TabIndex = 13;
            btnMatch14.UseVisualStyleBackColor = false;
            // 
            // btnMatch15
            // 
            btnMatch15.BackColor = Color.DarkBlue;
            btnMatch15.Dock = DockStyle.Fill;
            btnMatch15.Location = new Point(635, 223);
            btnMatch15.Name = "btnMatch15";
            btnMatch15.Size = new Size(156, 104);
            btnMatch15.TabIndex = 14;
            btnMatch15.UseVisualStyleBackColor = false;
            // 
            // btnMatch16
            // 
            btnMatch16.BackColor = Color.DarkBlue;
            btnMatch16.Dock = DockStyle.Fill;
            btnMatch16.Location = new Point(3, 333);
            btnMatch16.Name = "btnMatch16";
            btnMatch16.Size = new Size(152, 104);
            btnMatch16.TabIndex = 15;
            btnMatch16.UseVisualStyleBackColor = false;
            // 
            // btnMatch17
            // 
            btnMatch17.BackColor = Color.DarkBlue;
            btnMatch17.Dock = DockStyle.Fill;
            btnMatch17.Location = new Point(161, 333);
            btnMatch17.Name = "btnMatch17";
            btnMatch17.Size = new Size(152, 104);
            btnMatch17.TabIndex = 16;
            btnMatch17.UseVisualStyleBackColor = false;
            // 
            // btnMatch18
            // 
            btnMatch18.BackColor = Color.DarkBlue;
            btnMatch18.Dock = DockStyle.Fill;
            btnMatch18.Location = new Point(319, 333);
            btnMatch18.Name = "btnMatch18";
            btnMatch18.Size = new Size(152, 104);
            btnMatch18.TabIndex = 17;
            btnMatch18.UseVisualStyleBackColor = false;
            // 
            // btnMatch19
            // 
            btnMatch19.BackColor = Color.DarkBlue;
            btnMatch19.Dock = DockStyle.Fill;
            btnMatch19.Location = new Point(477, 333);
            btnMatch19.Name = "btnMatch19";
            btnMatch19.Size = new Size(152, 104);
            btnMatch19.TabIndex = 18;
            btnMatch19.UseVisualStyleBackColor = false;
            // 
            // btnMatch20
            // 
            btnMatch20.BackColor = Color.DarkBlue;
            btnMatch20.Dock = DockStyle.Fill;
            btnMatch20.Location = new Point(635, 333);
            btnMatch20.Name = "btnMatch20";
            btnMatch20.Size = new Size(156, 104);
            btnMatch20.TabIndex = 19;
            btnMatch20.UseVisualStyleBackColor = false;
            // 
            // btnMatch21
            // 
            btnMatch21.BackColor = Color.DarkBlue;
            btnMatch21.Dock = DockStyle.Fill;
            btnMatch21.Location = new Point(3, 443);
            btnMatch21.Name = "btnMatch21";
            btnMatch21.Size = new Size(152, 108);
            btnMatch21.TabIndex = 20;
            btnMatch21.UseVisualStyleBackColor = false;
            // 
            // btnMatch22
            // 
            btnMatch22.BackColor = Color.DarkBlue;
            btnMatch22.Dock = DockStyle.Fill;
            btnMatch22.Location = new Point(161, 443);
            btnMatch22.Name = "btnMatch22";
            btnMatch22.Size = new Size(152, 108);
            btnMatch22.TabIndex = 21;
            btnMatch22.UseVisualStyleBackColor = false;
            // 
            // btnMatch23
            // 
            btnMatch23.BackColor = Color.DarkBlue;
            btnMatch23.Dock = DockStyle.Fill;
            btnMatch23.Location = new Point(319, 443);
            btnMatch23.Name = "btnMatch23";
            btnMatch23.Size = new Size(152, 108);
            btnMatch23.TabIndex = 22;
            btnMatch23.UseVisualStyleBackColor = false;
            // 
            // btnMatch24
            // 
            btnMatch24.BackColor = Color.DarkBlue;
            btnMatch24.Dock = DockStyle.Fill;
            btnMatch24.Location = new Point(477, 443);
            btnMatch24.Name = "btnMatch24";
            btnMatch24.Size = new Size(152, 108);
            btnMatch24.TabIndex = 23;
            btnMatch24.UseVisualStyleBackColor = false;
            // 
            // btnMatch25
            // 
            btnMatch25.BackColor = Color.DarkBlue;
            btnMatch25.Dock = DockStyle.Fill;
            btnMatch25.Location = new Point(635, 443);
            btnMatch25.Name = "btnMatch25";
            btnMatch25.Size = new Size(156, 108);
            btnMatch25.TabIndex = 24;
            btnMatch25.UseVisualStyleBackColor = false;
            // 
            // MatchingGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 698);
            Controls.Add(tblMain);
            Name = "MatchingGame";
            Text = "Matching Game";
            tblMain.ResumeLayout(false);
            tblToolbar.ResumeLayout(false);
            tblToolbar.PerformLayout();
            tblGameStatus.ResumeLayout(false);
            tblGameStatus.PerformLayout();
            tblMatchingCards.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblToolbar;
        private Button btnStart;
        private RadioButton opt2Player;
        private RadioButton optAgainstComputer;
        private Label lblScore;
        private Label lblPlayer1Score;
        private Label lblPlayer2Score;
        private TableLayoutPanel tblGameStatus;
        private Label llblGameStatus;
        private TableLayoutPanel tblMatchingCards;
        private Button btnMatch1;
        private Button btnMatch2;
        private Button btnMatch3;
        private Button btnMatch4;
        private Button btnMatch5;
        private Button btnMatch6;
        private Button btnMatch7;
        private Button btnMatch8;
        private Button btnMatch9;
        private Button btnMatch10;
        private Button btnMatch11;
        private Button btnMatch12;
        private Button btnMatch13;
        private Button btnMatch14;
        private Button btnMatch15;
        private Button btnMatch16;
        private Button btnMatch17;
        private Button btnMatch18;
        private Button btnMatch19;
        private Button btnMatch20;
        private Button btnMatch21;
        private Button btnMatch22;
        private Button btnMatch23;
        private Button btnMatch24;
        private Button btnMatch25;
    }
}