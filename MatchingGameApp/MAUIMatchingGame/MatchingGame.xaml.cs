using MatchingGameSystem;
namespace MAUIMatchingGame;

public partial class MatchingGame : ContentPage
{
    Game game = new();
    List<Button> AllMatchButtons;


    public MatchingGame()
	{
        InitializeComponent();
        game = new Game();
        BindingContext = game;

        AllMatchButtons = new() { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16 };

        // Bind each button to the corresponding card
        for (int i = 0; i < AllMatchButtons.Count; i++)
        {
            AllMatchButtons[i].BindingContext = game.AllCards.Count > i ? game.AllCards[i] : null;
        }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        game.StartGame();

        // After starting the game, bind buttons to cards
        for (int i = 0; i < AllMatchButtons.Count; i++)
        {
            AllMatchButtons[i].BindingContext = game.AllCards[i];
        }

    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        game.DoTurn(AllMatchButtons.IndexOf((Button)sender));
    }


}