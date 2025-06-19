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
           // lstAllMatchButtons.ForEach(b => b.Click += CardClicked);
            lblGameStatus.DataBindings.Add("Text", game, "GameStatusDescription");
            lblPlayer1Score.DataBindings.Add("Text", game, "Player1ScoreDescription");
            lblPlayer2Score.DataBindings.Add("Text", game, "Player2ScoreDescription");

        }

        private string GetGameRules()
        {
            return """
        Rules of the game:
        
        Gameplay:
        
        Turn Structure: Players take turns choosing a card from the top 8 and a card from the bottom 8.
        Matching: If the chosen cards match, the player receives a point
        Non-Matching: If the cards do not match, they will flip back over after a one-second delay.
        Next Turn: After a turn, Player 2 will play its turn.
        """;
        }

       
        private void Start()
        {
            MessageBox.Show(GetGameRules());
            game.StartGame();
            for (int i = 0; i < lstAllMatchButtons.Count; i++)
            {
                Button btn = lstAllMatchButtons[i];
                Card card = game.lstAllCards[i];

                btn.DataBindings.Clear(); // prevent binding duplicates
                btn.DataBindings.Add("Text", card, "Value");
                btn.DataBindings.Add("BackColor", card, "BackColor");
                btn.DataBindings.Add("ForeColor", card, "ForeColor");
                btn.Click += CardClicked;
            }
        }


        private async Task DoTurn(Button btn)
        {

            int num = lstAllMatchButtons.IndexOf(btn);
            await game.DoTurn(num);
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
