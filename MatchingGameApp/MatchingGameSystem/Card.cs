namespace MatchingGameSystem
{
    public class Card
    {
        public string Value { get; private set; }
        public bool IsMatched { get; set; }
        public bool IsRevealed { get; set; }

        public Card(string value)
        {
            Value = value;
            IsMatched = false;
            IsRevealed = false;
        }
    }
}
