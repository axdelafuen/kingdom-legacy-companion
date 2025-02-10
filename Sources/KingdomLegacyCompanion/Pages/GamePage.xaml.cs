using Model;
using Services;

namespace KingdomLegacyCompanion.Pages;

public partial class GamePage : ContentPage
{
    private Game _currentGame;
    public GamePage(Game game)
    {
        InitializeComponent();
        _currentGame = game;
        BindingContext = _currentGame;
        SaveNewGame();
    }

    private async void GoBackMainPage(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void SaveNewGame()
    {
        await DataManager.Instance.SaveDataAsync();
    }

    private async void AddValueToResource(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            switch (button.AutomationId)
            {
                case "gold":
                    _currentGame.Gold++;
                    break;
                case "wood":
                    _currentGame.Wood++;
                    break;
                case "stone":
                    _currentGame.Stone++;
                    break;
                case "steel":
                    _currentGame.Steel++;
                    break;
                case "sword":
                    _currentGame.Sword++;
                    break;
                case "tradegoods":
                    _currentGame.TradeGoods++;
                    break;
                default:
                    break;
            }
            await DataManager.Instance.SaveDataAsync();
        }
    }

    private async void SubValueToResource(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            switch (button.AutomationId)
            {
                case "gold":
                    if (_currentGame.Gold > 0)
                        _currentGame.Gold--;
                    break;
                case "wood":
                    if (_currentGame.Wood > 0)
                        _currentGame.Wood--;
                    break;
                case "stone":
                    if (_currentGame.Stone > 0)
                        _currentGame.Stone--;
                    break;
                case "steel":
                    if (_currentGame.Steel > 0)
                        _currentGame.Steel--;
                    break;
                case "sword":
                    if (_currentGame.Sword > 0)
                        _currentGame.Sword--;
                    break;
                case "tradegoods":
                    if (_currentGame.TradeGoods > 0)
                        _currentGame.TradeGoods--;
                    break;
                default:
                    break;
            }
            await DataManager.Instance.SaveDataAsync();
        }
    }
    private async void EndGameClicked(object sender, EventArgs e)
    {
        string response = await DisplayPromptAsync("End the adventure !", "Sum up all fame", "OK", "Cancel", keyboard: Keyboard.Numeric);
        if (response != null && response != "" && int.TryParse(response, out int intResponse))
        {
            _currentGame.IsEnded = true;
            _currentGame.Score = intResponse;
            await DataManager.Instance.SaveDataAsync();
            await Navigation.PopToRootAsync();
        }
    }

    private async void DeleteThisGame(object sender, EventArgs e)
    {
        bool response = await DisplayAlert("Delete this kingdom !", "Are you sure you want to delete this kingdom ?", "OK", "Cancel");
        if (response)
        {
            DataManager.Instance.RemoveGame(_currentGame);
            await Navigation.PopToRootAsync();
        }
    }
}