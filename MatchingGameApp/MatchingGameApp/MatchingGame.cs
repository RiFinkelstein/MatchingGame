using System;
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
            lstMatchButtons2 = lstMatchButtons2.OrderBy(x => rnd.Next()).ToList();

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
                MatchPart1 = btn;
            }
        }

        private void RevealPictures2(Button btn)
        {
            if (btn.ForeColor == Color.DarkBlue)
            {
                btn.ForeColor = Color.White;
                MatchPart2 = btn;
            }
        }

        private async void CheckMatch()
        {
            if (MatchPart1 != null && MatchPart2 != null)
            {
                if (MatchPart1.Text == MatchPart2.Text)
                {
                    if (CurrentTurn== TurnEnum.Player1)
                    {
                        ScorePlayer1++;
                        lblPlayer1Score.Text ="Player 1: "+ ScorePlayer1.ToString();
                    }
                    else
                    {
                        ScorePlayer2++;
                        lblPlayer2Score.Text = "Player 2: " + ScorePlayer2.ToString();
                    }
                    MatchPart1.Enabled = false;
                    MatchPart2.Enabled = false;
                    MatchPart1 = null;
                    MatchPart2 = null;
                    lstMatchButtons2.ForEach(b => b.Click += Card2Clicked);
                    lstMatchButtons1.ForEach(b => b.Click += Card1Clicked);
                    GameOver();
                    if (GameOver()== false){
                        SwitchTurn();
                    }
                }
                else
                {
                    //when the wrong match is turned over then the progam waits a few seconds and then turns the cards back over
                    await Task.Delay(1000);
                    // Reset unmatched buttons to dark blue
                    
                    MatchPart1.ForeColor = Color.DarkBlue;
                    MatchPart2.ForeColor = Color.DarkBlue;
                    MatchPart1 = null;
                    MatchPart2 = null;
                    lstMatchButtons2.ForEach(b => b.Click += Card2Clicked);
                    lstMatchButtons1.ForEach(b => b.Click += Card1Clicked);

                    SwitchTurn();
                }
                lblGameStatus.Text = "Current Turn: " + CurrentTurn;
            }
        }
        
        private async void DoComputerTurn()
        {
            await Task.Delay(1000);
            CurrentTurn = TurnEnum.Player2;
            lblGameStatus.Text = "Current Turn: " + CurrentTurn;
            CurrentTurn = TurnEnum.Player2;
            var lst1 = lstMatchButtons1.Where(b => b.Enabled == true).ToList();
            var btn1 = lst1[new Random().Next(0, lst1.Count())];
            RevealPictures1(btn1);
            MatchPart1 = btn1;
            var lst2 = lstMatchButtons2.Where(b => b.Enabled == true).ToList();
            var btn2 = lst2[new Random().Next(0, lst2.Count())];
            RevealPictures2(btn2);
            MatchPart2 = btn2;
            CheckMatch();
            
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
            lblGameStatus.Text = "Current Turn: " + CurrentTurn;
            if (CurrentTurn == TurnEnum.Player2 && optAgainstComputer.Checked)
            {
                DoComputerTurn();
            }

        }

        private bool GameOver()
        {
            var winner = "";
            if (ScorePlayer1> ScorePlayer2)
            {
                winner = "Winner: Player 1";
            }
            else if (ScorePlayer1 < ScorePlayer2)
            {
                winner = "Winner: Player 2";
            }
            else
            {
                winner = "Tie";
            }

            if (lstMatchButtons1.Where(b => b.Enabled== true).Count() == 0 && lstMatchButtons2.Where(b => b.Enabled == true).Count() == 0)
            {
                lblGameStatus.Text =  winner  +Environment.NewLine +"Game Over- Press Restart to play again ";
                return true;
            }
            return false;
        }
        private void Card2Clicked(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                RevealPictures2((Button)sender);
                CheckMatch();
                lstMatchButtons2.ForEach(b => b.Click -= Card2Clicked);
            }
        }

        private void Card1Clicked(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                RevealPictures1((Button)sender);
                CheckMatch();
                lstMatchButtons1.ForEach(b => b.Click -= Card1Clicked);

            }
        }


        private void BtnStart_Click(object? sender, EventArgs e)
        {
            lstMatchButtons1.ForEach(b => b.Enabled = true);
            lstMatchButtons2.ForEach(b => b.Enabled = true);
            lstMatchButtons1.ForEach(b => b.ForeColor = Color.DarkBlue);
            lstMatchButtons2.ForEach(b => b.ForeColor = Color.DarkBlue);
            lblPlayer1Score.Text = "Player 1: 0";
            lblPlayer2Score.Text = "Player 2: 0";
            lblGameStatus.Text = "Current Turn: "+ TurnEnum.Player1;
            ScorePlayer1 = 0;
            ScorePlayer2 = 0;
            AddWordsToButton();
            btnStart.Text = "Restart";

        }
    }
}
