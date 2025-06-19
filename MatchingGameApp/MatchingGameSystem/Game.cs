using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

using System.Collections.Generic;



namespace MatchingGameSystem
{
    public class Game : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private GameStatusEnum _gamestatus = GameStatusEnum.NotStarted;
        private TurnEnum _currentturn;
        private int _player1score;
        private int _player2score;

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
        public string Player2ScoreDescription { get => $"Player 2: {Player2Score}"; }  


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


        public Card? MatchPart1 { get; set; }

        public Card? MatchPart2 { get; set; }

        private List<Card> AllCards { get; set; } = new();

        private List<Card> CardsTopRow { get; set; } = new();

        private List<Card> CardsBottomRow { get; set; } = new();
        private List<Card> MatchFound { get; set; } = new();
        private List<string> CardNames { get; set; } = new() { "A", "B", "C", "D", "E", "F", "G", "H" };

        private bool isCheckingMatch = false;

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
            this.CardsBottomRow.ForEach(b => b.BackColor = this.BottomCardsHiddenColor);
            this.CardsTopRow.ForEach(b => b.BackColor = this.TopCardsHiddendColor);
            CardsTopRow.Clear();
            CardsBottomRow.Clear();
            AllCards.Clear();

            for (int i = 0; i < 8; i++)
            {
                CardsTopRow.Add(new Card(""));
                CardsBottomRow.Add(new Card(""));
            }

            AllCards = CardsTopRow.Concat(CardsBottomRow).ToList();
            AddWordsToButton();
        }

        public void AddWordsToButton()
        {
            // Shuffle the names for both rows independently
            var rnd = new Random();
            var shuffledTop = CardNames.OrderBy(x => rnd.Next()).ToList();
            var shuffledBottom = CardNames.OrderBy(x => rnd.Next()).ToList();

            //Assign values to the top row
            for (int i = 0; i < 8; i++)
            {
                CardsTopRow[i].Value = shuffledTop[i];
                CardsTopRow[i].IsMatched = false;
                CardsTopRow[i].IsRevealed = false;
                CardsTopRow[i].BackColor = TopCardsHiddendColor;
                CardsTopRow[i].ForeColor = TopCardsHiddendColor;
            }

            //Assign values to the bottom row
            for (int i = 0; i < 8; i++)
            {
                CardsBottomRow[i].Value = shuffledBottom[i];
                CardsBottomRow[i].IsMatched = false;
                CardsBottomRow[i].IsRevealed = false;
                CardsBottomRow[i].BackColor = BottomCardsHiddenColor;
                CardsBottomRow[i].ForeColor = BottomCardsHiddenColor;
            }
            //Rebuild the full list of all cards
            AllCards = CardsTopRow.Concat(CardsBottomRow).ToList();
        }
        public async Task DoTurn(int cardnum)
        {
            Card card = this.AllCards[cardnum];

            if (MatchFound.Contains(card) == false && GameStatus == GameStatusEnum.Playing)
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
          (CardsTopRow.Contains(MatchPart1) && CardsTopRow.Contains(card)) ||
          (CardsBottomRow.Contains(MatchPart1) && CardsBottomRow.Contains(card))
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
                        MatchFound.Add(MatchPart1);
                        MatchFound.Add(MatchPart2);
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
                            CardsTopRow.Contains(MatchPart1) ? TopCardsHiddendColor : BottomCardsHiddenColor
                        );
                        MatchPart2.Hide(
                            CardsTopRow.Contains(MatchPart2) ? TopCardsHiddendColor : BottomCardsHiddenColor
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
            if (MatchFound.Count == AllCards.Count)
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
            return GameStatus switch
            {
                GameStatusEnum.NotStarted => "Press start to begin playing",
                GameStatusEnum.Playing => $"Game Status: Playing   Current Turn: {CurrentTurn}",
                GameStatusEnum.Tie => "Game Over! It's a Tie! Press Start to play again",
                GameStatusEnum.Winner => Player1Score > Player2Score
                    ? "Game Over! Player 1 Wins! Press Start to play again"
                    : "Game Over! Player 2 Wins! Press Start to play again",
                _ => ""
            };
        }

        private void InvokePropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
