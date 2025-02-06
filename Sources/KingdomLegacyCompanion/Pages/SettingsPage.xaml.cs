using Services;

namespace KingdomLegacyCompanion.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}
    private async void GoBackMainPage(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void ClearAppData(object sender, EventArgs e)
    {
        bool confirmation = await DisplayAlert("Clear all data ?", "All the saved kingdoms will be deleted !", "OK", "Cancel");
        if (confirmation)
        {
            await DataManager.Instance.ResetDataAsync();
        }
    }

    private async void CardsPageClicked(object sender, EventArgs e)
    {
        if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
        {
            if (Navigation.NavigationStack.Any(page => page is CardsPage))
                return;

            await Navigation.PushAsync(new CardsPage());
        }
        else
            await DisplayAlert("No internet !", "This feature requires internet connection, try again later.", "OK");
    }
}