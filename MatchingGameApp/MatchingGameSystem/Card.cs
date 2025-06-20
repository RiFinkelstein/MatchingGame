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
        string _value;

        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                this.InvokePropertyChanged();
            }
        }
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
                this.InvokePropertyChanged(nameof(ForeColorMaui));
            }
        }
        public Microsoft.Maui.Graphics.Color BackColorMaui
        {
            get => this.ConvertToMauiColor(this.BackColor);
        }
        public Microsoft.Maui.Graphics.Color ForeColorMaui
        {
            get => this.ConvertToMauiColor(this.ForeColor);
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
            //ForeColor = game.CardsRevealedColor;
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

        private Microsoft.Maui.Graphics.Color ConvertToMauiColor(System.Drawing.Color systemColor)
        {
            float red = systemColor.R / 255f;
            float green = systemColor.G / 255f;
            float blue = systemColor.B / 255f;
            float alpha = systemColor.A / 255f;

            return new Microsoft.Maui.Graphics.Color(red, green, blue, alpha);
        }
        private void InvokePropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }


    }
}
