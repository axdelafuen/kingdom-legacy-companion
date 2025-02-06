using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
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

            var imageBackground = new Image
            {
                Source = "castle.jpg",
                Aspect = Aspect.Center,
                Opacity = 0.6
            };
            var layout = new AbsoluteLayout{};
            AbsoluteLayout.SetLayoutFlags(imageBackground, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(imageBackground, new Rect(0.5, 0.5, 1, 1));
            layout.Children.Add(imageBackground);
            double offsetX = 0;
            double offsetY = 0.5;

            AbsoluteLayout.SetLayoutBounds(imageBackground, new Rect(0.5 + offsetX, 0.5 + offsetY, 1, 1));

            var clipPath = new PathGeometry
            {
                Figures = new PathFigureCollection
                {
                    new PathFigure
                    {
                        StartPoint = new Point(20, 0), // Début en haut à gauche
                        Segments = new PathSegmentCollection
                        {
                            new LineSegment { Point = new Point(180, 0) },  // Bord supérieur droit
                            new LineSegment { Point = new Point(200, 30) }, // Inclinaison droite
                            new LineSegment { Point = new Point(180, 60) }, // Bas droit
                            new LineSegment { Point = new Point(20, 60) },  // Bas gauche
                            new LineSegment { Point = new Point(0, 30) },   // Inclinaison gauche
                            new LineSegment { Point = new Point(20, 0) }    // Fermeture
                        }
                    }
                }
            };

            var button = new Button
            {
                Text = game.Name,
                AutomationId = game.Id.ToString(),
                BackgroundColor = Colors.Transparent,
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
            };
            button.Clicked += (sender, e) => OnGameSelected(game);

            var border = new Border
            {
                BackgroundColor = Colors.Black,
                WidthRequest = 200,
                HeightRequest = 60,
                Padding = 0,
                Content = new Grid
                {
                    Children = { layout, button }
                },
                Clip = clipPath
            };

            ButtonContainer.Children.Add(border);
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