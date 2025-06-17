namespace MatchingGameSystem
{
    public class Card
    {
        public string Value { get; set; }
        public bool IsMatched { get; set; }
        public bool IsRevealed { get; set; }

        public Game game { get; set; }

        public System.Drawing.Color BackColor { get; set; }
        public System.Drawing.Color ForeColor { get; set; }

        public Card(string value)
        {
            Value = value;
            IsMatched = false;
            IsRevealed = false;
        }

        public void Reveal()
        {
            IsRevealed = true;
            ForeColor = game.CardsRevealedColor;
        }
        public void Hide() {
            IsRevealed = false;
            ForeColor = BackColor;
        }
        public bool Equals(Card card)
        {
            return this.Value == card.Value;
        }

    }
}
