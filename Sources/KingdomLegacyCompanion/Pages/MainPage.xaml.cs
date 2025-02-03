using Model;

namespace KingdomLegacyCompanion.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void NewGameClicked(object sender, EventArgs e)
        {
            Game newGame = new Game(null);
            await Navigation.PushAsync(new GamePage(newGame));
        }
    }

}