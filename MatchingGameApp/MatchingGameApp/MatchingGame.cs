using MatchingGameSystem;
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
        Game game = new();


        List<Button> lstMatchButtons1;
        List<Button> lstMatchButtons2;
        List<Button> lstAllMatchButtons;

       public MatchingGame()
        {
            InitializeComponent();
            btnStart.Click += BtnStart_Click;
            lstAllMatchButtons = new() { btnMatch1, btnMatch2, btnMatch3, btnMatch4, btnMatch5, btnMatch6, btnMatch7, btnMatch8, btnMatch9, btnMatch10, btnMatch11, btnMatch12, btnMatch13, btnMatch14, btnMatch15, btnMatch16 };
            lstMatchButtons1 = lstAllMatchButtons.Take(8).ToList();
            lstMatchButtons2 = lstAllMatchButtons.Skip(8).Take(8).ToList();
            lstAllMatchButtons.ForEach(b => b.Click += CardClicked);
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

       
        private void Start()
        {
            MessageBox.Show(GetGameRules());
            game.StartGame();
        }


        private async Task DoTurn(Button btn)
        {

            int num = lstAllMatchButtons.IndexOf(btn);
            await game.DoTurn(num);
            UpdateUI();
        }

        private async Task UpdateUI()
        {
            for (int i = 0; i < lstAllMatchButtons.Count; i++)
            {
                Button btn = lstAllMatchButtons[i];
                Card card = game.lstAllCards[i];

                btn.Text = card.IsRevealed || card.IsMatched ? card.Value : "";
                btn.ForeColor = card.ForeColor;
                btn.Refresh();  // Force redraw immediately (optional)
            }

            lblPlayer1Score.Text = $"Player 1: {game.Player1Score}";
            lblPlayer2Score.Text = $"Player 2: {game.Player2Score}";
            lblGameStatus.Text = game.GameStatus.ToString() + game.CurrentTurn.ToString();
        }



   
        private async void CardClicked(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                await DoTurn(btn);
            }
        }


        private void BtnStart_Click(object? sender, EventArgs e)
        {
            Start();
        }
    }
}
