using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

using System.Collections.Generic;


namespace MatchingGameSystem
{
    public class Game : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        GameStatusEnum _gamestatus = GameStatusEnum.NotStarted;
        TurnEnum _currentturn;
        int _player1score;
        int _player2score;

        public enum GameStatusEnum { NotStarted, Playing, Winner, Tie }
        public enum TurnEnum { None, player1, player2 }


        public int Player1Score
        {
            get => _player1score; set
            {
                _player1score = value;
                this.InvokePropertyChanged();
                this.InvokePropertyChanged("Player1ScoreDescription");

            }
        }
        public int Player2Score
        {
            get => _player2score; set
            {
                _player2score = value;
                this.InvokePropertyChanged();
                this.InvokePropertyChanged("Player2ScoreDescription");

            }
        }

        public string Player1ScoreDescription { get => $"Player 1: {Player1Score}"; }
        public string Player2ScoreDescription { get => $"Player 2: {Player2Score}"; } //calculated 


        public TurnEnum CurrentTurn
        {
            get => _currentturn; set
            {
                _currentturn = value;
                this.InvokePropertyChanged();
                this.InvokePropertyChanged("GameStatusDescription");
            }

        }

        public GameStatusEnum GameStatus
        {
            get => _gamestatus; set
            {
                _gamestatus = value;
                this.InvokePropertyChanged();
                this.InvokePropertyChanged("CurrentTurn");

                this.InvokePropertyChanged("GameStatusDescription");
            }

        }
        public string GameStatusDescription { get => GameStatusDescriptionString(); } //calculated 


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
        }




        public void StartGame()
        {
            Player1Score = 0;
            Player2Score = 0;
            GameStatus = GameStatusEnum.Playing;
            CurrentTurn = TurnEnum.player1;
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
            AddWordsToButton();
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
                        if (
          (lstCardsTopRow.Contains(MatchPart1) && lstCardsTopRow.Contains(card)) ||
          (lstCardsBottomRow.Contains(MatchPart1) && lstCardsBottomRow.Contains(card))
        )
                        {
                            return; // same row — ignore selection
                        }


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
                            GameStatus = GameStatusEnum.Playing;
                        }
                    }
                    else
                    {
                        //when the wrong match is turned over then the progam waits a few seconds and then turns the cards back over
                        await Task.Delay(2000);
                        // Reset unmatched buttons

                        MatchPart1.Hide(
                            lstCardsTopRow.Contains(MatchPart1) ? TopCardsHiddendColor : BottomCardsHiddenColor
                        );
                        MatchPart2.Hide(
                            lstCardsTopRow.Contains(MatchPart2) ? TopCardsHiddendColor : BottomCardsHiddenColor
                        );


                        MatchPart1 = null;
                        MatchPart2 = null;
                        SwitchTurn();

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

        private string GameStatusDescriptionString()
        {
            string msg = "";
            if (GameStatus == GameStatusEnum.NotStarted)
            {
                msg = "Press start to begin playing";
            }
            else if (GameStatus == GameStatusEnum.Playing)
            {
                msg = $"Game Status: Playing   Current Turn: {CurrentTurn}";
            }
            else if (GameStatus == GameStatusEnum.Tie)
            {
                msg = "Game Over! its a Tie! Press Start to play again";
            }
            else
            {
                if (Player1Score > Player2Score)
                {
                    msg = "Game Over! Player 1 Wins! Press Start to play again";
                }
                else
                {
                    msg = "Game Over! Player 2 Wins! Press Start to play again";
                }
            }

            return msg;
        }

        private void InvokePropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
