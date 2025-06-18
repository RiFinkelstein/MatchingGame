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
        public List<Card> lstMatchFound { get; set; } = new();


        public List<string> lstCardNames { get; set; } = new() { "A", "B", "C", "D", "E", "F", "G", "H" };

        public bool isCheckingMatch = false;

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


        public void DoTurn(Card card)
        {

            if (lstMatchFound.Contains(card) == false && GameStatus == GameStatusEnum.Playing)
            {
                if (card.ForeColor == TopCardsHiddendColor && MatchPart1 == null)
                {

                    card.ForeColor = CardsRevealedColor;
                    MatchPart1 = card;

                }
                else if (card.ForeColor == BottomCardsHiddenColor && MatchPart2 == null)
                {
                    card.ForeColor = CardsRevealedColor;
                    MatchPart2 = card;
                }
            }
        }

        public async Task CheckMatch()
        {
            {
                if (MatchPart1 != null && MatchPart2 != null && !isCheckingMatch)
                {
                    isCheckingMatch = true;

                    if (MatchPart1.Value == MatchPart2.Value)
                    {
                        UpdateScore();
                        lstMatchFound.Add(MatchPart1);
                        lstMatchFound.Add(MatchPart2);
                        MatchPart1 = null;
                        MatchPart2 = null;
                        if (!IsGameOver())
                        {
                            SwitchTurn();
                            //lblGameStatus.Text = "Current Turn: " + CurrentTurn;
                            GameStatus = GameStatusEnum.Playing;
                        }
                    }
                    else
                    {
                        //when the wrong match is turned over then the progam waits a few seconds and then turns the cards back over
                        await Task.Delay(1000);
                        // Reset unmatched buttons
                        if (MatchPart1 != null)
                        {
                            MatchPart1.ForeColor = TopCardsHiddendColor;
                        }
                        if (MatchPart2 != null)
                        {
                            MatchPart2.ForeColor = BottomCardsHiddenColor;
                        }
                        MatchPart1 = null;
                        MatchPart2 = null;
                        SwitchTurn();
                        //lblGameStatus.Text = "Current Turn: " + CurrentTurn;

                    }
                    isCheckingMatch = false;
                }
            }
        }
        public void SwitchTurn()
        {
            CurrentTurn = CurrentTurn == TurnEnum.player1 ? TurnEnum.player2 : TurnEnum.player1;
            //lblGameStatus.Text = "Current Turn: " + CurrentTurn;
        }
        public void UpdateScore()
        {
            if (CurrentTurn == TurnEnum.player1)
            {
                Player1Score++;
                //lblPlayer1Score.Text = "Player 1: " + ScorePlayer1.ToString();
            }
            else
            {
                Player2Score++;
                //lblPlayer2Score.Text = "Player 2: " + ScorePlayer2.ToString();
            }
        }

        public bool IsGameOver()
        {
            var winner = "";
            if (lstMatchFound.Count == lstAllCards.Count)
            {
                if (Player1Score > Player2Score)
                {
                    winner = "Player 1";
                    GameStatus = GameStatusEnum.Winner;
                }
                else if (Player1Score < Player2Score)
                {
                    winner = "Player 2";
                    GameStatus = GameStatusEnum.Winner;

                }
                else
                {
                    winner = "Tie";
                    GameStatus = GameStatusEnum.Tie;
                }
                //lblGameStatus.Text = winner + Environment.NewLine + "Game Over - Press Restart to play again";
                return true;

            }
            return false;
        }
    }
}
