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


        TurnEnum CurrentTurn = TurnEnum.Player1;

        enum GameStatusEnum { NotStarted, Playing, WinnerPlayer1, WinnerPlayer2, Tie }
        GameStatusEnum GameStatus = GameStatusEnum.NotStarted;

        Button MatchPart1;
        Button MatchPart2;


        List<Button> lstMatchButtons1;
        List<Button> lstMatchButtons2;
        List<Button> lstAllMatchButtons;

        List<Button> lstMatchFound = new();
        List<string> lstMatchStrings;

        int ScorePlayer1 = 0;
        int ScorePlayer2 = 0;
        bool isCheckingMatch = false;


        public MatchingGame()
        {
            InitializeComponent();
            btnStart.Click += BtnStart_Click;


            lstAllMatchButtons = new() { btnMatch1, btnMatch2, btnMatch3, btnMatch4, btnMatch5, btnMatch6, btnMatch7, btnMatch8, btnMatch9, btnMatch10, btnMatch11, btnMatch12, btnMatch13, btnMatch14, btnMatch15, btnMatch16 };
            lstMatchButtons1 = lstAllMatchButtons.Take(8).ToList();
            lstMatchButtons2 = lstAllMatchButtons.Skip(8).Take(8).ToList();



            lstMatchButtons1.ForEach(b => b.Click += CardClicked);
            lstMatchButtons2.ForEach(b => b.Click += CardClicked);

            lstMatchStrings = new() { "A", "B", "C", "D", "E", "F", "G", "H" };


            SetButtonForeColor(lstMatchButtons1, Color.LightBlue);
            SetButtonForeColor(lstMatchButtons2, Color.LightPink);

            lblGameStatus.Text = "Click Start to begin game";

        }

        private string GetGameRules()
        {
            return """
        Rules of the game:
        
        Gameplay:
        
        Turn Structure: Players take turns choosing a card from the top 8 and a card from the bottom 8.
        Matching: If the chosen cards match, the player receives a point, and the matched cards turn black.
        Non-Matching: If the cards do not match, they will flip back over after a one-second delay.
        Next Turn: After a turn, Player 2 will play its turn.
        """;
        }

        private void ResetScore()
        {
            ScorePlayer1 = 0;
            ScorePlayer2 = 0;
            lblPlayer1Score.Text = "PLayer 1: 0";
            lblPlayer2Score.Text = "PLayer 2: 0";
        }


        private void SetButtonForeColor(List<Button> buttons, Color clr)
        {
            buttons.ForEach(b => b.ForeColor = clr);
        }

        private void ResetMatchParts()
        {
            MatchPart1 = null;
            MatchPart2 = null;
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
            MessageBox.Show(GetGameRules());

            SetButtonForeColor(lstMatchButtons1, Color.LightBlue);
            SetButtonForeColor(lstMatchButtons2, Color.LightPink);

            lstMatchFound.Clear();
            lblGameStatus.Text = "Current Turn: " + TurnEnum.Player1;
            ResetScore();
            AddWordsToButton();
            btnStart.Text = "Restart";
            GameStatus = GameStatusEnum.Playing;
        }

        private void DoTurn(Button btn)
        {
            if (lstMatchFound.Contains(btn) == false && GameStatus == GameStatusEnum.Playing)
            {
                if (btn.ForeColor == Color.LightBlue && MatchPart1 == null)
                {

                    btn.ForeColor = Color.Black;
                    MatchPart1 = btn;

                }
                else if (btn.ForeColor == Color.LightPink && MatchPart2 == null)
                {
                    btn.ForeColor = Color.Black;
                    MatchPart2 = btn;

                }
            }
        }

        private async void CheckMatch()
        {
            if (MatchPart1 != null && MatchPart2 != null && !isCheckingMatch)
            {
                isCheckingMatch = true;

                if (MatchPart1.Text == MatchPart2.Text)
                {
                    UpdateScore();
                    lstMatchFound.Add(MatchPart1);
                    lstMatchFound.Add(MatchPart2);
                    ResetMatchParts();
                    if (!GameOver())
                    {
                        SwitchTurn();
                        lblGameStatus.Text = "Current Turn: " + CurrentTurn;
                        GameStatus = GameStatusEnum.Playing;
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
                isCheckingMatch = false;

            }
        }


        private void SwitchTurn()
        {
            CurrentTurn = CurrentTurn == TurnEnum.Player1 ? TurnEnum.Player2 : TurnEnum.Player1;
            lblGameStatus.Text = "Current Turn: " + CurrentTurn;
        }



        private bool GameOver()
        {
            var winner = "";
            if (lstMatchFound.Count == lstAllMatchButtons.Count)
            {
                if (ScorePlayer1 > ScorePlayer2)
                {
                    winner = "Winner: Player 1";
                    GameStatus = GameStatusEnum.WinnerPlayer1;
                }
                else if (ScorePlayer1 < ScorePlayer2)
                {
                    winner = "Winner: Player 2";
                    GameStatus = GameStatusEnum.WinnerPlayer2;

                }
                else
                {
                    winner = "Tie";
                    GameStatus = GameStatusEnum.Tie;
                }
                lblGameStatus.Text = winner + Environment.NewLine + "Game Over - Press Restart to play again";
                return true;

            }
            return false;
        }


        private void CardClicked(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                DoTurn((Button)sender);
                CheckMatch();
            }
        }

        private void BtnStart_Click(object? sender, EventArgs e)
        {
            Start();
        }
    }
}
