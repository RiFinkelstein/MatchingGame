using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace MatchingGameSystem
{
    public class Card: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        System.Drawing.Color _forecolor;
        System.Drawing.Color _backcolor;

        public string Value { get; set; }
        public bool IsMatched { get; set; }
        public bool IsRevealed { get; set; }


        public System.Drawing.Color BackColor
        {
            get => _backcolor; set
            {
                _backcolor = value;
                this.InvokePropertyChanged();
            }
        }

        public System.Drawing.Color ForeColor
        {
            get => _forecolor; set
            {
                _forecolor = value;
                this.InvokePropertyChanged();
            }
        }

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
        private void InvokePropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }


    }
}
