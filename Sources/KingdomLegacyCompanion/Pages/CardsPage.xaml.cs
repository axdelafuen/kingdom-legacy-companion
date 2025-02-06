namespace KingdomLegacyCompanion.Pages;

public partial class CardsPage : ContentPage
{
	public CardsPage()
	{
		InitializeComponent();
	}

    private async void GoBackMainPage(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}