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

        enum TurnEnum { Player1, Player2};


        TurnEnum CurrentTurn= TurnEnum.Player1;

        Button MatchPart1;
        Button MatchPart2;


        List<Button> lstMatchButtons1;
        List<Button> lstMatchButtons2;
        List<Button> lstAllMatchButtons;
        List<string> lstMatchStrings;

        int ScorePlayer1 = 0;
        int ScorePlayer2 = 0;


        public MatchingGame()
        {
            InitializeComponent();
            btnStart.Click += BtnStart_Click;


            lstMatchButtons1 = new() { btnMatch1, btnMatch2, btnMatch3, btnMatch4, btnMatch5, btnMatch6, btnMatch7, btnMatch8 };
            lstMatchButtons2 = new() { btnMatch9, btnMatch10, btnMatch11, btnMatch12, btnMatch13, btnMatch14, btnMatch15, btnMatch16 };
            lstAllMatchButtons = new() { btnMatch1, btnMatch2, btnMatch3, btnMatch4, btnMatch5, btnMatch6, btnMatch7, btnMatch8, btnMatch9, btnMatch10, btnMatch11, btnMatch12, btnMatch13, btnMatch14, btnMatch15, btnMatch16 };


            DisableButtons(lstAllMatchButtons);

            lstMatchButtons1.ForEach(b => b.Click += Card1Clicked);
            lstMatchButtons2.ForEach(b => b.Click += Card2Clicked);

            lstMatchStrings = new() { "A", "B", "C", "D", "E", "F", "G", "H" };


            SetButtonForeColor(lstMatchButtons1, Color.LightBlue);
            SetButtonForeColor(lstMatchButtons2, Color.LightPink);

            lblGameStatus.Text = "Click Start to begin game";
        }

        private void ResetScore()
        {
            ScorePlayer1 = 0;
            ScorePlayer2 = 0;
            lblPlayer1Score.Text = "PLayer 1: 0";
            lblPlayer2Score.Text = "PLayer 2: 0";
        }


        private void DisableMatchButtons()
        {
            MatchPart1.Enabled = false;
            MatchPart2.Enabled = false; 
        }

        private void EnableButtons(List<Button> buttons)
        {
            buttons.ForEach(b=>b.Enabled = true);
        }
        private void EnableButtonClicks(List<Button> buttons, EventHandler clickhandler)
        {
            buttons.ForEach(b=> b.Click += clickhandler);
        }

        private void DisableButtons(List<Button> buttons)
        {
            buttons.ForEach(b => b.Enabled = false);
        }

        private void DisableButtonClicks(List<Button> buttons, EventHandler clickhandler)
        {
            buttons.ForEach(b => b.Click -= clickhandler);
        }

        private void SetButtonForeColor(List<Button> buttons, Color clr)
        {
            buttons.ForEach(b => b.ForeColor = clr);
        }

        private void ResetMatchParts()
        {
            MatchPart1 = null;
            MatchPart2 = null;
            EnableButtonClicks(lstMatchButtons1, Card1Clicked);
            EnableButtonClicks(lstMatchButtons2, Card2Clicked);
        }

        private void UpdateScore()
        {
            if (CurrentTurn == TurnEnum.Player1)
            {
                ScorePlayer1++;
                lblPlayer1Score.Text = "Player 1: " + ScorePlayer1.ToString();
            }
            else
            {
                ScorePlayer2++;
                lblPlayer2Score.Text = "Player 2: " + ScorePlayer2.ToString();
            }
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

        private void Start()
        {
            MessageBox.Show("Rules of the game: \r\n\r\n Gameplay:\r\n\r\nTurn Structure: Players take turns choosing a card from the top 8 and a card from the bottom 8.\r\nMatching: If the chosen cards match, the player receives a point, and the matched cards turn black.\r\nNon-Matching: If the cards do not match, they will flip back over after a one-second delay.\r\nNext Turn: After a turn, Player 2 will play its turn.");
            EnableButtons(lstAllMatchButtons);

            SetButtonForeColor(lstMatchButtons1, Color.LightBlue);
            SetButtonForeColor(lstMatchButtons2, Color.LightPink);


            lblGameStatus.Text = "Current Turn: " + TurnEnum.Player1;
            ResetScore();
            AddWordsToButton();
            btnStart.Text = "Restart";
        }
        
        private void RevealPicture(Button btn, int part)
        {
            if (btn.ForeColor == Color.LightBlue || btn.ForeColor == Color.LightPink)
            {
                btn.ForeColor = Color.Black;
                if (part == 1)
                {
                    MatchPart1 = btn;
                }
                else if(part == 2)
                {
                    MatchPart2 = btn;
                }

            }
        }


        private async void CheckMatch()
        {
            if (MatchPart1 != null && MatchPart2 != null)
            {
                if (MatchPart1.Text == MatchPart2.Text)
                {
                    UpdateScore();
                    DisableMatchButtons();
                    ResetMatchParts();
                    if (!GameOver())
                    {
                        SwitchTurn();
                        lblGameStatus.Text = "Current Turn: " + CurrentTurn;
                    }
                    else
                    {
                        GameOver();
                    }
                }
                else
                {
                    //when the wrong match is turned over then the progam waits a few seconds and then turns the cards back over
                    await Task.Delay(1000);
                    // Reset unmatched buttons to dark blue
                    if (MatchPart1 != null)
                    {
                        MatchPart1.ForeColor = Color.LightBlue;
                    }
                    if (MatchPart2 != null)
                    {
                        MatchPart2.ForeColor = Color.LightPink;
                    }
                    ResetMatchParts();
                    SwitchTurn();
                    lblGameStatus.Text = "Current Turn: " + CurrentTurn;

                }
            }
        }
        /*
        private async void DoComputerTurn()
        {
            DisableButtonClicks(lstMatchButtons2, Card2Clicked);
            DisableButtonClicks(lstMatchButtons1, Card1Clicked);
            await Task.Delay(1000);
            CurrentTurn = TurnEnum.Player2;
            lblGameStatus.Text = "Current Turn: " + CurrentTurn;
            CurrentTurn = TurnEnum.Player2;

            var availablebuttons1 = lstMatchButtons1.Where(b => b.Enabled == true).ToList();
            var btn1 = availablebuttons1[new Random().Next(0, availablebuttons1.Count())];
            RevealPicture(btn1, 1);
            MatchPart1 = btn1;

            var availablebuttons2 = lstMatchButtons2.Where(b => b.Enabled == true).ToList();
            var btn2 = availablebuttons2[new Random().Next(0, availablebuttons2.Count())];
            RevealPicture(btn2, 2);
            MatchPart2 = btn2;

            CheckMatch();
        }
        */
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
            /*if (CurrentTurn == TurnEnum.Player2 && optAgainstComputer.Checked)
            {
                DoComputerTurn();
            }*/

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
                RevealPicture((Button)sender, 2);
                CheckMatch();
                DisableButtonClicks(lstMatchButtons2, Card2Clicked);
            }
        }

        private void Card1Clicked(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                RevealPicture((Button)sender, 1);
                CheckMatch();
                DisableButtonClicks(lstMatchButtons1, Card1Clicked);
            }
        }

        private void BtnStart_Click(object? sender, EventArgs e)
        {
            Start();
        }
    }
}
