﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGameApp
{
    public partial class MatchingGame : Form
    {

        enum TurnEnum { Player1, Player2 };
        TurnEnum CurrentTurn= TurnEnum.Player1;

        Button MatchPart1;
        Button MatchPart2;


        List<Button> lstMatchButtons1;
        List<Button> lstMatchButtons2;
        List<string> lstMatchStrings;

        int ScorePlayer1 = 0;
        int ScorePlayer2 = 0;

        public MatchingGame()
        {
            InitializeComponent();
            btnStart.Click += BtnStart_Click;


            lstMatchButtons1 = new() { btnMatch1, btnMatch2, btnMatch3, btnMatch4, btnMatch5, btnMatch6, btnMatch7, btnMatch8 };
            lstMatchButtons2 = new() { btnMatch9, btnMatch10, btnMatch11, btnMatch12, btnMatch13, btnMatch14, btnMatch15, btnMatch16 };


            lstMatchButtons1.ForEach(b => b.Click += Card1Clicked);
            lstMatchButtons2.ForEach(b => b.Click += Card2Clicked);

            lstMatchStrings = new() { "A", "B", "C", "D", "E", "F", "G", "H" };
            lstMatchButtons1.ForEach(b => b.Enabled = false);
            lstMatchButtons2.ForEach(b => b.Enabled = false);
            lstMatchButtons1.ForEach(b => b.ForeColor = Color.DarkBlue);
            lstMatchButtons2.ForEach(b => b.ForeColor = Color.DarkBlue);


            lblGameStatus.Text = "Click Start to begin game";
        }




        private void AddWordsToButton()
        {
            Random rnd = new();
            lstMatchButtons1 = lstMatchButtons1.OrderBy(x => rnd.Next()).ToList();
            //assign text to lables
            for (int i = 0; i < 8; i++)
            {
                lstMatchButtons1[i].Text = lstMatchStrings[i];
                lstMatchButtons2[i].Text = lstMatchStrings[i];
            }
        }

        private void RevealPictures1(Button btn)
        {
            if (btn.ForeColor == Color.DarkBlue)
            {
                btn.ForeColor = Color.White;
            }
            MatchPart1 = btn;
        }

        private void RevealPictures2(Button btn)
        {
            if (btn.ForeColor == Color.DarkBlue)
            {
                btn.ForeColor = Color.White;
            }
            MatchPart2 = btn;
        }

        private void CheckMatch()
        {
            if (MatchPart1 != null && MatchPart2 != null)
            {

                if (MatchPart1.Text == MatchPart2.Text)
                {
                    //ScorePlayer1++;
                    if (CurrentTurn== TurnEnum.Player1)
                    {
                        ScorePlayer1++;
                        lblPlayer1Score.Text = CurrentTurn + ": "+ ScorePlayer1.ToString();
                    }
                    else
                    {
                        ScorePlayer2++;
                        lblPlayer2Score.Text = CurrentTurn+ ": " + ScorePlayer2.ToString();
                    }
                    MatchPart1.Enabled = false;
                    MatchPart2.Enabled = false;
                    MatchPart1 = null;
                    MatchPart2 = null;
                    GameOVer();
                }
             else
                {
                    //when the wrong match is turned over then the progam waits a few seconds and then turns the cards back over
                    var t = Task.Run(async delegate
                    {
                        await Task.Delay(1000);
                    });
                    t.Wait();
                    {
                        // Reset unmatched buttons to dark blue
                        this.Invoke(new Action(() =>
                        {
                            MatchPart1.ForeColor = Color.DarkBlue;
                            MatchPart2.ForeColor = Color.DarkBlue;
                            lblGameStatus.Text = "Current Turn: ";
                        }));
                    }
                    MatchPart1 = null;
                    MatchPart2 = null;
                    SwitchTurn();
                    lblGameStatus.Text = "Current Turn: " + CurrentTurn;
                }
            }
        }

        private void SwitchTurn()
        {
            if (CurrentTurn== TurnEnum.Player1)
            {
                CurrentTurn = TurnEnum.Player2;
            }
            else
            {
                CurrentTurn = TurnEnum.Player1;
            }
        }

        private void GameOVer()
        {
            if (lstMatchButtons1.Where(b => b.Enabled== true).Count() == 0 && lstMatchButtons2.Where(b => b.Enabled == true).Count() == 0)
            {
                lblGameStatus.Text = "Game Over- Press Start to play again";
            }
        }  

        private void Card2Clicked(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                RevealPictures2((Button)sender);
                CheckMatch();

            }
        }

        private void Card1Clicked(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                RevealPictures1((Button)sender);
                CheckMatch();
            }
        }


        private void BtnStart_Click(object? sender, EventArgs e)
        {
            lstMatchButtons1.ForEach(b => b.Enabled = true);
            lstMatchButtons2.ForEach(b => b.Enabled = true);
            lstMatchButtons1.ForEach(b => b.ForeColor = Color.DarkBlue);
            lstMatchButtons2.ForEach(b => b.ForeColor = Color.DarkBlue);
            lblGameStatus.Text = "Current Turn: "+ CurrentTurn;
            ScorePlayer1 = 0;
            ScorePlayer2 = 0;
            AddWordsToButton();
            btnStart.Text = "Restart";

        }
    }
}
