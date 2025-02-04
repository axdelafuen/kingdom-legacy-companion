using Model;

namespace KingdomLegacyCompanion.Pages;

public partial class LoadPage : ContentPage
{
	private List<Game> _games;

    public LoadPage(List<Game> games)
    {
        InitializeComponent();
        _games = games;
        foreach (var game in _games.Where(g => g.IsEnded == false))
        {
            var button = new Button
            {
                Text = game.Name,
                AutomationId = game.Id.ToString(),
                FontSize = 18,
                Padding = new Thickness(10),
                CornerRadius = 10,
                HorizontalOptions = LayoutOptions.Center
            };

            button.Clicked += (sender, e) => OnGameSelected(game);

            ButtonContainer.Children.Add(button);
        }
    }
    private async void GoBackMainPage(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnGameSelected(Game game)
    {
        if (Navigation.NavigationStack.Any(page => page is GamePage))
            return;

        await Navigation.PushAsync(new GamePage(game));
    }
}