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
            lblScore = new Label();
            lblPlayer1Score = new Label();
            lblPlayer2Score = new Label();
            lblTotalScores = new Label();
            tblGameOptions = new TableLayoutPanel();
            tblGameStatus = new TableLayoutPanel();
            lblGameStatus = new Label();
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
            rbGame1 = new RadioButton();
            rbGame2 = new RadioButton();
            rbGame3 = new RadioButton();
            tblMain.SuspendLayout();
            tblToolbar.SuspendLayout();
            tblGameOptions.SuspendLayout();
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
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tblMain.Size = new Size(800, 698);
            tblMain.TabIndex = 0;
            // 
            // tblToolbar
            // 
            tblToolbar.BackColor = Color.Silver;
            tblToolbar.ColumnCount = 6;
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.63084F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.0100746F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.2997475F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.6308336F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.6308336F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.6308336F));
            tblToolbar.Controls.Add(btnStart, 0, 0);
            tblToolbar.Controls.Add(lblScore, 3, 0);
            tblToolbar.Controls.Add(lblPlayer1Score, 4, 0);
            tblToolbar.Controls.Add(lblPlayer2Score, 5, 0);
            tblToolbar.Controls.Add(lblTotalScores, 2, 0);
            tblToolbar.Controls.Add(tblGameOptions, 1, 0);
            tblToolbar.Dock = DockStyle.Fill;
            tblToolbar.Location = new Point(3, 3);
            tblToolbar.Name = "tblToolbar";
            tblToolbar.RowCount = 1;
            tblToolbar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblToolbar.Size = new Size(794, 133);
            tblToolbar.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnStart.BackColor = SystemColors.ButtonHighlight;
            btnStart.FlatStyle = FlatStyle.Popup;
            btnStart.Location = new Point(3, 3);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(110, 127);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Dock = DockStyle.Fill;
            lblScore.Location = new Point(447, 0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(110, 133);
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
            lblPlayer1Score.Size = new Size(110, 133);
            lblPlayer1Score.TabIndex = 4;
            lblPlayer1Score.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayer2Score
            // 
            lblPlayer2Score.AutoSize = true;
            lblPlayer2Score.Dock = DockStyle.Fill;
            lblPlayer2Score.Location = new Point(679, 0);
            lblPlayer2Score.Name = "lblPlayer2Score";
            lblPlayer2Score.Size = new Size(112, 133);
            lblPlayer2Score.TabIndex = 5;
            lblPlayer2Score.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalScores
            // 
            lblTotalScores.AutoSize = true;
            lblTotalScores.Dock = DockStyle.Fill;
            lblTotalScores.Location = new Point(262, 0);
            lblTotalScores.Name = "lblTotalScores";
            lblTotalScores.Size = new Size(179, 133);
            lblTotalScores.TabIndex = 6;
            lblTotalScores.Text = "Total Score ";
            lblTotalScores.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblGameOptions
            // 
            tblGameOptions.ColumnCount = 1;
            tblGameOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblGameOptions.Controls.Add(rbGame1, 0, 0);
            tblGameOptions.Controls.Add(rbGame2, 0, 1);
            tblGameOptions.Controls.Add(rbGame3, 0, 2);
            tblGameOptions.Dock = DockStyle.Fill;
            tblGameOptions.Location = new Point(119, 3);
            tblGameOptions.Name = "tblGameOptions";
            tblGameOptions.RowCount = 3;
            tblGameOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 47.9166679F));
            tblGameOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 52.0833321F));
            tblGameOptions.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tblGameOptions.Size = new Size(137, 127);
            tblGameOptions.TabIndex = 7;
            // 
            // tblGameStatus
            // 
            tblGameStatus.ColumnCount = 5;
            tblGameStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblGameStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblGameStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblGameStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblGameStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblGameStatus.Controls.Add(lblGameStatus, 1, 0);
            tblGameStatus.Dock = DockStyle.Fill;
            tblGameStatus.Location = new Point(3, 142);
            tblGameStatus.Name = "tblGameStatus";
            tblGameStatus.RowCount = 1;
            tblGameStatus.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblGameStatus.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblGameStatus.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblGameStatus.Size = new Size(794, 63);
            tblGameStatus.TabIndex = 1;
            // 
            // lblGameStatus
            // 
            lblGameStatus.AutoSize = true;
            lblGameStatus.BackColor = Color.Tan;
            tblGameStatus.SetColumnSpan(lblGameStatus, 3);
            lblGameStatus.Dock = DockStyle.Fill;
            lblGameStatus.Location = new Point(161, 0);
            lblGameStatus.Name = "lblGameStatus";
            lblGameStatus.Size = new Size(468, 63);
            lblGameStatus.TabIndex = 0;
            lblGameStatus.Text = "Game Status: ";
            lblGameStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblMatchingCards
            // 
            tblMatchingCards.ColumnCount = 4;
            tblMatchingCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblMatchingCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblMatchingCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblMatchingCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblMatchingCards.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblMatchingCards.Controls.Add(btnMatch1, 0, 0);
            tblMatchingCards.Controls.Add(btnMatch2, 1, 0);
            tblMatchingCards.Controls.Add(btnMatch3, 2, 0);
            tblMatchingCards.Controls.Add(btnMatch4, 3, 0);
            tblMatchingCards.Controls.Add(btnMatch5, 0, 1);
            tblMatchingCards.Controls.Add(btnMatch6, 1, 1);
            tblMatchingCards.Controls.Add(btnMatch7, 2, 1);
            tblMatchingCards.Controls.Add(btnMatch8, 3, 1);
            tblMatchingCards.Controls.Add(btnMatch9, 0, 2);
            tblMatchingCards.Controls.Add(btnMatch10, 1, 2);
            tblMatchingCards.Controls.Add(btnMatch11, 2, 2);
            tblMatchingCards.Controls.Add(btnMatch12, 3, 2);
            tblMatchingCards.Controls.Add(btnMatch13, 0, 3);
            tblMatchingCards.Controls.Add(btnMatch14, 1, 3);
            tblMatchingCards.Controls.Add(btnMatch15, 2, 3);
            tblMatchingCards.Controls.Add(btnMatch16, 3, 3);
            tblMatchingCards.Dock = DockStyle.Fill;
            tblMatchingCards.Location = new Point(3, 211);
            tblMatchingCards.Name = "tblMatchingCards";
            tblMatchingCards.RowCount = 4;
            tblMatchingCards.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMatchingCards.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMatchingCards.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMatchingCards.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMatchingCards.Size = new Size(794, 484);
            tblMatchingCards.TabIndex = 2;
            // 
            // btnMatch1
            // 
            btnMatch1.BackColor = Color.LightBlue;
            btnMatch1.Dock = DockStyle.Fill;
            btnMatch1.Font = new Font("Wingdings", 40.2F);
            btnMatch1.ForeColor = Color.LightBlue;
            btnMatch1.Location = new Point(3, 3);
            btnMatch1.Name = "btnMatch1";
            btnMatch1.Size = new Size(192, 115);
            btnMatch1.TabIndex = 0;
            btnMatch1.UseVisualStyleBackColor = false;
            // 
            // btnMatch2
            // 
            btnMatch2.BackColor = Color.LightBlue;
            btnMatch2.Dock = DockStyle.Fill;
            btnMatch2.Font = new Font("Wingdings", 40.2F);
            btnMatch2.ForeColor = Color.LightBlue;
            btnMatch2.Location = new Point(201, 3);
            btnMatch2.Name = "btnMatch2";
            btnMatch2.Size = new Size(192, 115);
            btnMatch2.TabIndex = 1;
            btnMatch2.UseVisualStyleBackColor = false;
            // 
            // btnMatch3
            // 
            btnMatch3.BackColor = Color.LightBlue;
            btnMatch3.Dock = DockStyle.Fill;
            btnMatch3.Font = new Font("Wingdings", 40.2F);
            btnMatch3.ForeColor = Color.LightBlue;
            btnMatch3.Location = new Point(399, 3);
            btnMatch3.Name = "btnMatch3";
            btnMatch3.Size = new Size(192, 115);
            btnMatch3.TabIndex = 2;
            btnMatch3.UseVisualStyleBackColor = false;
            // 
            // btnMatch4
            // 
            btnMatch4.BackColor = Color.LightBlue;
            btnMatch4.Dock = DockStyle.Fill;
            btnMatch4.Font = new Font("Wingdings", 40.2F);
            btnMatch4.ForeColor = Color.LightBlue;
            btnMatch4.Location = new Point(597, 3);
            btnMatch4.Name = "btnMatch4";
            btnMatch4.Size = new Size(194, 115);
            btnMatch4.TabIndex = 3;
            btnMatch4.UseVisualStyleBackColor = false;
            // 
            // btnMatch5
            // 
            btnMatch5.BackColor = Color.LightBlue;
            btnMatch5.Dock = DockStyle.Fill;
            btnMatch5.Font = new Font("Wingdings", 40.2F);
            btnMatch5.ForeColor = Color.LightBlue;
            btnMatch5.Location = new Point(3, 124);
            btnMatch5.Name = "btnMatch5";
            btnMatch5.Size = new Size(192, 115);
            btnMatch5.TabIndex = 5;
            btnMatch5.UseVisualStyleBackColor = false;
            // 
            // btnMatch6
            // 
            btnMatch6.BackColor = Color.LightBlue;
            btnMatch6.Dock = DockStyle.Fill;
            btnMatch6.Font = new Font("Wingdings", 40.2F);
            btnMatch6.ForeColor = Color.LightBlue;
            btnMatch6.Location = new Point(201, 124);
            btnMatch6.Name = "btnMatch6";
            btnMatch6.Size = new Size(192, 115);
            btnMatch6.TabIndex = 6;
            btnMatch6.UseVisualStyleBackColor = false;
            // 
            // btnMatch7
            // 
            btnMatch7.BackColor = Color.LightBlue;
            btnMatch7.Dock = DockStyle.Fill;
            btnMatch7.Font = new Font("Wingdings", 40.2F);
            btnMatch7.ForeColor = Color.LightBlue;
            btnMatch7.Location = new Point(399, 124);
            btnMatch7.Name = "btnMatch7";
            btnMatch7.Size = new Size(192, 115);
            btnMatch7.TabIndex = 7;
            btnMatch7.UseVisualStyleBackColor = false;
            // 
            // btnMatch8
            // 
            btnMatch8.BackColor = Color.LightBlue;
            btnMatch8.Dock = DockStyle.Fill;
            btnMatch8.Font = new Font("Wingdings", 40.2F);
            btnMatch8.ForeColor = Color.LightBlue;
            btnMatch8.Location = new Point(597, 124);
            btnMatch8.Name = "btnMatch8";
            btnMatch8.Size = new Size(194, 115);
            btnMatch8.TabIndex = 8;
            btnMatch8.UseVisualStyleBackColor = false;
            // 
            // btnMatch9
            // 
            btnMatch9.BackColor = Color.LightPink;
            btnMatch9.Dock = DockStyle.Fill;
            btnMatch9.Font = new Font("Wingdings", 40.2F);
            btnMatch9.ForeColor = Color.LightPink;
            btnMatch9.Location = new Point(3, 245);
            btnMatch9.Name = "btnMatch9";
            btnMatch9.Size = new Size(192, 115);
            btnMatch9.TabIndex = 10;
            btnMatch9.UseVisualStyleBackColor = false;
            // 
            // btnMatch10
            // 
            btnMatch10.BackColor = Color.LightPink;
            btnMatch10.Dock = DockStyle.Fill;
            btnMatch10.Font = new Font("Wingdings", 40.2F);
            btnMatch10.ForeColor = Color.LightPink;
            btnMatch10.Location = new Point(201, 245);
            btnMatch10.Name = "btnMatch10";
            btnMatch10.Size = new Size(192, 115);
            btnMatch10.TabIndex = 11;
            btnMatch10.UseVisualStyleBackColor = false;
            // 
            // btnMatch11
            // 
            btnMatch11.BackColor = Color.LightPink;
            btnMatch11.Dock = DockStyle.Fill;
            btnMatch11.Font = new Font("Wingdings", 40.2F);
            btnMatch11.ForeColor = Color.LightPink;
            btnMatch11.Location = new Point(399, 245);
            btnMatch11.Name = "btnMatch11";
            btnMatch11.Size = new Size(192, 115);
            btnMatch11.TabIndex = 12;
            btnMatch11.UseVisualStyleBackColor = false;
            // 
            // btnMatch12
            // 
            btnMatch12.BackColor = Color.LightPink;
            btnMatch12.Dock = DockStyle.Fill;
            btnMatch12.Font = new Font("Wingdings", 40.2F);
            btnMatch12.ForeColor = Color.LightPink;
            btnMatch12.Location = new Point(597, 245);
            btnMatch12.Name = "btnMatch12";
            btnMatch12.Size = new Size(194, 115);
            btnMatch12.TabIndex = 13;
            btnMatch12.UseVisualStyleBackColor = false;
            // 
            // btnMatch13
            // 
            btnMatch13.BackColor = Color.LightPink;
            btnMatch13.Dock = DockStyle.Fill;
            btnMatch13.Font = new Font("Wingdings", 40.2F);
            btnMatch13.ForeColor = Color.LightPink;
            btnMatch13.Location = new Point(3, 366);
            btnMatch13.Name = "btnMatch13";
            btnMatch13.Size = new Size(192, 115);
            btnMatch13.TabIndex = 15;
            btnMatch13.UseVisualStyleBackColor = false;
            // 
            // btnMatch14
            // 
            btnMatch14.BackColor = Color.LightPink;
            btnMatch14.Dock = DockStyle.Fill;
            btnMatch14.Font = new Font("Wingdings", 40.2F);
            btnMatch14.ForeColor = Color.LightPink;
            btnMatch14.Location = new Point(201, 366);
            btnMatch14.Name = "btnMatch14";
            btnMatch14.Size = new Size(192, 115);
            btnMatch14.TabIndex = 16;
            btnMatch14.UseVisualStyleBackColor = false;
            // 
            // btnMatch15
            // 
            btnMatch15.BackColor = Color.LightPink;
            btnMatch15.Dock = DockStyle.Fill;
            btnMatch15.Font = new Font("Wingdings", 40.2F);
            btnMatch15.ForeColor = Color.LightPink;
            btnMatch15.Location = new Point(399, 366);
            btnMatch15.Name = "btnMatch15";
            btnMatch15.Size = new Size(192, 115);
            btnMatch15.TabIndex = 17;
            btnMatch15.UseVisualStyleBackColor = false;
            // 
            // btnMatch16
            // 
            btnMatch16.BackColor = Color.LightPink;
            btnMatch16.Dock = DockStyle.Fill;
            btnMatch16.Font = new Font("Wingdings", 40.2F);
            btnMatch16.ForeColor = Color.LightPink;
            btnMatch16.Location = new Point(597, 366);
            btnMatch16.Name = "btnMatch16";
            btnMatch16.Size = new Size(194, 115);
            btnMatch16.TabIndex = 18;
            btnMatch16.UseVisualStyleBackColor = false;
            // 
            // rbGame1
            // 
            rbGame1.AutoSize = true;
            rbGame1.Location = new Point(3, 3);
            rbGame1.Name = "rbGame1";
            rbGame1.Size = new Size(81, 24);
            rbGame1.TabIndex = 0;
            rbGame1.TabStop = true;
            rbGame1.Text = "Game 1";
            rbGame1.UseVisualStyleBackColor = true;
            // 
            // rbGame2
            // 
            rbGame2.AutoSize = true;
            rbGame2.Location = new Point(3, 39);
            rbGame2.Name = "rbGame2";
            rbGame2.Size = new Size(81, 24);
            rbGame2.TabIndex = 1;
            rbGame2.TabStop = true;
            rbGame2.Text = "Game 2";
            rbGame2.UseVisualStyleBackColor = true;
            // 
            // rbGame3
            // 
            rbGame3.AutoSize = true;
            rbGame3.Location = new Point(3, 79);
            rbGame3.Name = "rbGame3";
            rbGame3.Size = new Size(81, 24);
            rbGame3.TabIndex = 2;
            rbGame3.TabStop = true;
            rbGame3.Text = "Game 3";
            rbGame3.UseVisualStyleBackColor = true;
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
            tblGameOptions.ResumeLayout(false);
            tblGameOptions.PerformLayout();
            tblGameStatus.ResumeLayout(false);
            tblGameStatus.PerformLayout();
            tblMatchingCards.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblToolbar;
        private Button btnStart;
        private Label lblScore;
        private Label lblPlayer1Score;
        private Label lblPlayer2Score;
        private TableLayoutPanel tblGameStatus;
        private Label lblGameStatus;
        private TableLayoutPanel tblMatchingCards;
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
        private Button btnMatch1;
        private Button btnMatch2;
        private Button btnMatch3;
        private Label lblTotalScores;
        private TableLayoutPanel tblGameOptions;
        private RadioButton rbGame1;
        private RadioButton rbGame2;
        private RadioButton rbGame3;
    }
}