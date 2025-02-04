using Services;

namespace KingdomLegacyCompanion
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            _ = DataManager.Instance;
            MainPage = new AppShell();
        }
    }
}
