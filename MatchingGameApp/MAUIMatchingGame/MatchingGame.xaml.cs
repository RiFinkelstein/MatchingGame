using MatchingGameSystem;
namespace MAUIMatchingGame;

public partial class MatchingGame : ContentPage
{
    Game activegame = new();
    List<Game> lstgame = new() { new Game(), new Game(), new Game() };
    List<Button> AllMatchButtons;


    public MatchingGame()
    {
        InitializeComponent();

        lstgame.ForEach(g => g.Scorechanged += G_Scorechnaged); 
        Game1Rb.BindingContext = lstgame[0];
        Game2Rb.BindingContext = lstgame[1];
        Game3Rb.BindingContext = lstgame[2];
        activegame = lstgame[0];
        this.BindingContext = activegame;

        AllMatchButtons = new() { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16 };

        // Bind each button to the corresponding card
        for (int i = 0; i < AllMatchButtons.Count; i++)
        {
            AllMatchButtons[i].BindingContext = activegame.AllCards.Count > i ? activegame.AllCards[i] : null;
        }
    }
    private void G_Scorechnaged(object? sender, EventArgs e)
    {
        TotalScorelbl.Text = Game.TotalScore;
    }

    private void StartbtnButton_Clicked(object sender, EventArgs e)
    {
        activegame.StartGame();

        // After starting the game, bind buttons to cards
        for (int i = 0; i < AllMatchButtons.Count; i++)
        {
            AllMatchButtons[i].BindingContext = activegame.AllCards[i];
        }

    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        //game.DoTurn(AllMatchButtons.IndexOf((Button)sender));
        activegame.DoTurn(AllMatchButtons.IndexOf((Button)sender));
    }
    private void Game_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RadioButton rb = (RadioButton)sender;
        if (rb.IsChecked && rb.BindingContext != null)
        {
            activegame = (Game)rb.BindingContext;
            this.BindingContext = activegame;
            TotalScorelbl.Text = Game.TotalScore;
            // Rebind buttons to correct game's cards
            for (int i = 0; i < AllMatchButtons.Count; i++)
            {
                AllMatchButtons[i].BindingContext = activegame.AllCards.Count > i ? activegame.AllCards[i] : null;
            }
        }
    }
}