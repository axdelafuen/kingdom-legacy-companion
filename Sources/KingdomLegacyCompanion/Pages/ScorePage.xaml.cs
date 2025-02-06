using Model;

namespace KingdomLegacyCompanion.Pages;

public partial class ScorePage : ContentPage
{
    private List<Game> _games;
    public ScorePage(List<Game> games)
    {
        InitializeComponent();
        _games = games;
        foreach (var game in _games.Where(g => g.IsEnded == true).OrderByDescending(g => g.Score))
        {
            var label = new Label
            {
                Text = game.Name + " - " + game.Score,
                AutomationId = game.Id.ToString(),
                FontSize = 18,
                TextColor = Colors.White,
                Padding = new Thickness(10),
                HorizontalOptions = LayoutOptions.Center
            };

            LabelContainer.Children.Add(label);
        }
    }
    private async void GoBackMainPage(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}