﻿using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

using System.Collections.Generic;
using System;



namespace MatchingGameSystem
{
    public class Game : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler? Scorechanged;

        private GameStatusEnum _gamestatus = GameStatusEnum.NotStarted;
        private TurnEnum _currentturn;
        private int _player1score;
        private int _player2score;
        private List<Card> _allCards = new();
        private static int player1wins;
        private static int player2wins;
        private static int totalties;
        private static int numgames;

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
        public static string TotalScore { get => $"Total Wins: Player 1:{player1wins}  Player 2:{player2wins}  Ties:{totalties}"; }
        public static string TotalTieslabel { get => $"Ties:{totalties}"; }
        public static string Player1Wins { get => $"Player 1:{player1wins}"; }
        public static string Player2Wins { get => $"Player 2:{player2wins}"; }



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

        public List<Card> AllCards
        {
            get => _allCards;
            set
            {
                _allCards = value;
                this.InvokePropertyChanged();

            }
        }

        public List<Card> CardsTopRow { get; set; } = new();

        public List<Card> CardsBottomRow { get; set; } = new();
        private List<Card> MatchFound { get; set; } = new();
        public List<string> CardNames { get; set; } = new() { "A", "B", "C", "D", "E", "F", "G", "H" };

        private bool isCheckingMatch = false;
        public string GameName { get; private set; } = $"Game {numgames}";



        public System.Drawing.Color TopCardsHiddendColor { get; set; } = System.Drawing.Color.LightBlue;
        public System.Drawing.Color BottomCardsHiddenColor { get; set; } = System.Drawing.Color.LightPink;
        public System.Drawing.Color CardsRevealedColor { get; set; } = System.Drawing.Color.Black;


        public Game()
        {
            numgames++;
            this.GameName = "Game " + numgames;
        }

        public void StartGame()
        {
            Player1Score = 0;
            Player2Score = 0;
            GameStatus = GameStatusEnum.Playing;
            CurrentTurn = TurnEnum.player1;
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
                        card.ForeColor = this.CardsRevealedColor;
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

                        card.ForeColor = this.CardsRevealedColor;
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
                        if (MatchFound.Count == AllCards.Count)
                        {
                            // Game is over
                            if (Player1Score > Player2Score)
                            {
                                GameStatus = GameStatusEnum.Winner;
                                player1wins++;
                                Scorechanged?.Invoke(this, new EventArgs());

                            }
                            else if (Player2Score > Player1Score)
                            {
                                GameStatus = GameStatusEnum.Winner;
                                player2wins++;
                                Scorechanged?.Invoke(this, new EventArgs());


                            }
                            else
                            {
                                GameStatus = GameStatusEnum.Tie;
                                totalties++;
                                Scorechanged?.Invoke(this, new EventArgs());
                            }
                        }
                        else
                        {
                            SwitchTurn();
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
        }
        public void UpdateScore()
        {
            if (CurrentTurn == TurnEnum.player1)
            {
                Player1Score++;
            }
            else
            {
                Player2Score++;
            }
        }

        private string GameStatusDescriptionString()
        {
            return GameStatus switch
            {
                GameStatusEnum.NotStarted => $"{GameName}: Press start to begin playing",
                GameStatusEnum.Playing => $"{GameName}: Game Status: Playing   Current Turn: {CurrentTurn}",
                GameStatusEnum.Tie => $"{GameName}: Game Over! It's a Tie! Press Start to play again",
                GameStatusEnum.Winner => Player1Score > Player2Score
                    ? $"{GameName}: Game Over! Player 1 Wins! Press Start to play again"
                    : $"{GameName}: Game Over! Player 2 Wins! Press Start to play again",
                _ => ""
            };
        }

        private void InvokePropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
