using Model;
using Services;
using System.Windows.Input;

namespace KingdomLegacyCompanion.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void NewGameClicked(object sender, EventArgs e)
        {
            string response = await DisplayPromptAsync("Start a new adventure !", "What's the name of your kingdom?", "OK", "Cancel", placeholder: "Kingdom#"+Game.UniqueId);
            
            if (response == null)
                return;
            if (response != "")
                DataManager.Instance.Games.Add(new Game(response));
            else
                DataManager.Instance.Games.Add(new Game(null));

            if (Navigation.NavigationStack.Any(page => page is GamePage))
                return;
            
            await Navigation.PushAsync(new GamePage(DataManager.Instance.Games.Last()));
        }

        private async void LoadGameClicked(object sender, EventArgs e)
        {
            if (Navigation.NavigationStack.Any(page => page is LoadPage))
                return;

            await Navigation.PushAsync(new LoadPage(DataManager.Instance.Games));
        }

        private async void CheckHistoryClicked(object sender, EventArgs e)
        {
            if (Navigation.NavigationStack.Any(page => page is ScorePage))
                return;

            await Navigation.PushAsync(new ScorePage(DataManager.Instance.Games));
        }

        private async void GoToSettingsPage(object sender, EventArgs e)
        {
            if (Navigation.NavigationStack.Any(page => page is SettingsPage))
                return;

            await Navigation.PushAsync(new SettingsPage());
        }

        public ICommand OpenWebsiteCommand => new Command(() =>
        {
            Launcher.OpenAsync("https://www.kingdomlegacygame.com/");
        });
    }
}