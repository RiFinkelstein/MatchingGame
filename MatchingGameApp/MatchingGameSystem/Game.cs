using System.Drawing;

namespace MatchingGameSystem
{
    public class Game
    {
        public enum GameStatusEnum { NotStarted, Playing, Winner, Tie }
        public enum TurnEnum { None, player1, player2 }



        public int Player1Score { get; set; }
        public int Player2Score { get; set; }

        public TurnEnum CurrentTurn { get; set; }

        public GameStatusEnum GameStatus { get; set; }
        public string GameStatusDescription { get; set; } // this will be calculated based on the gamestatusenum

        public Card MatchPart1 { get; set; }

        public Card MatchPart2 { get; set; }

        public List<Card> lstAllCards { get; set; } = new();

        public List<Card> lstCardsTopRow { get; set; } = new();

        public List<Card> lstCardsBottomRow { get; set; } = new();

        public List<string> lstCardNames { get; set; } = new() { "A", "B", "C", "D", "E", "F", "G", "H" };

        public System.Drawing.Color TopCardsHiddendColor { get; set; } = System.Drawing.Color.LightBlue;
        public System.Drawing.Color BottomCardsHiddenColor { get; set; } = System.Drawing.Color.LightPink;
        public System.Drawing.Color CardsRevealedColor { get; set; } = System.Drawing.Color.Black;


        public Game()
        {
            this.lstCardsBottomRow.ForEach(b => b.BackColor = this.BottomCardsHiddenColor);
            this.lstCardsTopRow.ForEach(b => b.BackColor = this.TopCardsHiddendColor);
            lstCardsTopRow.Clear();
            lstCardsBottomRow.Clear();
            lstAllCards.Clear();

            for (int i = 0; i < 8; i++)
            {
                lstCardsTopRow.Add(new Card(""));
                lstCardsBottomRow.Add(new Card(""));
            }

            lstAllCards = lstCardsTopRow.Concat(lstCardsBottomRow).ToList();

        }




        public void StartGame()
        {
            //EnableButtons(lstAllMatchButtons);
            //AllCards.ForEach(b => b.Enabled = true);
            lstAllCards.ForEach(b => b.ForeColor = b.BackColor);
            GameStatusDescription = $"Current Turn: {CurrentTurn.ToString()}";
            Player1Score = 0;
            Player2Score = 0;
            GameStatus = GameStatusEnum.Playing;
            CurrentTurn = TurnEnum.player1;
            AddWordsToButton();
            //btnStart.Text = "Restart";
        }

        public void AddWordsToButton()
        {
            // Shuffle the names for both rows independently
            var rnd = new Random();
            var shuffledTop = lstCardNames.OrderBy(x => rnd.Next()).ToList();
            var shuffledBottom = lstCardNames.OrderBy(x => rnd.Next()).ToList();

            //Assign values to the top row
            for (int i = 0; i < 8; i++)
            {
                lstCardsTopRow[i].Value = shuffledTop[i];
                lstCardsTopRow[i].IsMatched = false;
                lstCardsTopRow[i].IsRevealed = false;
                lstCardsTopRow[i].ForeColor = lstCardsTopRow[i].BackColor; // hide initially
            }

            //Assign values to the bottom row
            for (int i = 0; i < 8; i++)
            {
                lstCardsBottomRow[i].Value = shuffledBottom[i];
                lstCardsBottomRow[i].IsMatched = false;
                lstCardsBottomRow[i].IsRevealed = false;
                lstCardsBottomRow[i].ForeColor = lstCardsBottomRow[i].BackColor; // hide initially
            }
            //Rebuild the full list of all cards
            lstAllCards = lstCardsTopRow.Concat(lstCardsBottomRow).ToList();
        }


        public void HandleCardClick(Card Card, string letterrevealed)
        {
        }
        public void CheckMatch()
        {
        }
        public void SwitchTurn()
        {
        }
        public void UpdateScore()
        {
        }

        public void IsGameOver()
        {
        }
    }
}
