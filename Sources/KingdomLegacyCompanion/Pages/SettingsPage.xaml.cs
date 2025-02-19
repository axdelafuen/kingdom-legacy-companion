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

    private async void ExportData(object sender, EventArgs e)
    {
        try
        {
            await DataManager.Instance.ExportDataAsync();
        }
        catch(Exception)
        {
            await DisplayAlert("No data found !", "You need at least one game started to get your data.", "OK");
        }
    }

    private async void ImportData(object sender, EventArgs e)
    {
        await DataManager.Instance.ImportDataAsync();
    }
}