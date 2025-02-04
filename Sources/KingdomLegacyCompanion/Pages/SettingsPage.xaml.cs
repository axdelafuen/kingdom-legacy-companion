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
}