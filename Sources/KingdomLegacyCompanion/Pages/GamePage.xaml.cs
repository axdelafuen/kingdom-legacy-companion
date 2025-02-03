using Model;

namespace KingdomLegacyCompanion.Pages;

public partial class GamePage : ContentPage
{
	public Game CurrentGame;
	public GamePage(Game game)
	{
        InitializeComponent();
        CurrentGame = game;
        BindingContext = CurrentGame;
    }
}