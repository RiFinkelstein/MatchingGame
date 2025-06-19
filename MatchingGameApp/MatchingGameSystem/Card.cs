using System.Drawing;

namespace MatchingGameSystem
{
    public class Card
    {


        public string Value { get; set; }
        public bool IsMatched { get; set; }
        public bool IsRevealed { get; set; }
        public System.Drawing.Color BackColor { get; set; }
        public System.Drawing.Color ForeColor { get; set; }

        public Card(string value)
        {
            Value = value;
            IsMatched = false;
            IsRevealed = false;
            BackColor = Color.Gray;     // default, overridden later
            ForeColor = BackColor;      // hidden initially
        }
        public Game game { get; set; }

        public void Reveal()
        {
            IsRevealed = true;
            ForeColor = Color.Black;
        }
        public void Hide(Color hiddencolor)
        {
            IsRevealed = false;
            ForeColor = hiddencolor;
            BackColor = hiddencolor;
        }
        public bool Equals(Card card)
        {
            return this.Value == card.Value;
        }

    }
}
