namespace MatchingGameSystem
{
    public class Game
    {
        public enum Player { Player1, Player2 }
        public Player CurrentTurn { get; private set; } = Player.Player1;

        public List<Card> CardsTop { get; private set; }
        public List<Card> CardsBottom { get; private set; }

        public int ScorePlayer1 { get; private set; }
        public int ScorePlayer2 { get; private set; }

        private Card? SelectedCard1;
        private Card? SelectedCard2;

        public Game(List<string> matchValues)
        {
            var shuffledTop = matchValues.OrderBy(x => Guid.NewGuid()).ToList();
            var shuffledBottom = matchValues.OrderBy(x => Guid.NewGuid()).ToList();

            CardsTop = shuffledTop.Select(v => new Card(v)).ToList();
            CardsBottom = shuffledBottom.Select(v => new Card(v)).ToList();
        }

        public void SelectCard(Card card)
        {
            if (SelectedCard1 == null)
                SelectedCard1 = card;
            else if (SelectedCard2 == null)
                SelectedCard2 = card;
        }

        public bool IsReadyToCheck() => SelectedCard1 != null && SelectedCard2 != null;

        public bool CheckMatch()
        {
            if (SelectedCard1 == null || SelectedCard2 == null)
                return false;

            bool isMatch = SelectedCard1.Value == SelectedCard2.Value;

            if (isMatch)
            {
                SelectedCard1.IsMatched = true;
                SelectedCard2.IsMatched = true;

                if (CurrentTurn == Player.Player1)
                    ScorePlayer1++;
                else
                    ScorePlayer2++;
            }

            return isMatch;
        }

        public void ResetSelection()
        {
            SelectedCard1 = null;
            SelectedCard2 = null;
        }

        public void SwitchTurn()
        {
            CurrentTurn = (CurrentTurn == Player.Player1) ? Player.Player2 : Player.Player1;
        }

        public bool IsGameOver()
        {
            return CardsTop.All(c => c.IsMatched) && CardsBottom.All(c => c.IsMatched);
        }
    }
}
