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
            //lstAllCards.ForEach(b => card.IsRevealed = true);
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
                lstCardsTopRow[i].BackColor = TopCardsHiddendColor;
                lstCardsTopRow[i].ForeColor = TopCardsHiddendColor;
            }

            //Assign values to the bottom row
            for (int i = 0; i < 8; i++)
            {
                lstCardsBottomRow[i].Value = shuffledBottom[i];
                lstCardsBottomRow[i].IsMatched = false;
                lstCardsBottomRow[i].IsRevealed = false;
                lstCardsBottomRow[i].BackColor = BottomCardsHiddenColor;
                lstCardsBottomRow[i].ForeColor = BottomCardsHiddenColor;
            }
            //Rebuild the full list of all cards
            lstAllCards = lstCardsTopRow.Concat(lstCardsBottomRow).ToList();
        }
        public async Task DoTurn(int cardnum)
        {
            Card card = this.lstAllCards[cardnum];

            if (lstMatchFound.Contains(card) == false && GameStatus == GameStatusEnum.Playing)
            {
                if (!card.IsRevealed)  // if card is not revealed already
                {
                    if (MatchPart1 == null)
                    {
                        card.Reveal();
                        MatchPart1 = card;

                    }
                    else if (MatchPart2 == null)
                    {
                        card.Reveal();
                        MatchPart2 = card;

                    }
                }
                await CheckMatch();
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
                        await Task.Delay(2000);
                        // Reset unmatched buttons

                        MatchPart1.Hide(TopCardsHiddendColor);  // properly hide top card
                        MatchPart2.Hide(BottomCardsHiddenColor); // properly hide bottom card

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
