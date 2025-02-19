using System.Text.Json;
using CommunityToolkit.Maui.Storage;
using Model;

namespace Services
{
    public class DataManager
    {
        private static readonly string FileName = "kingdom-legacy-companion-data.json";
        private static DataManager _instance;
        private static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, FileName);

        public List<Game> Games { get; private set; } = new();

        public static DataManager Instance => _instance ??= new DataManager();

        private DataManager()
        {
            LoadDataAsync();
        }

        public async void AddGame(Game game)
        {
            Games.Add(game);
            await SaveDataAsync();
        }

        public async void RemoveGame(Game game)
        {
            Games.Remove(game);
            await SaveDataAsync();
        }

        public async Task ResetDataAsync()
        {
            Games = [];
            await SaveDataAsync();
            Game.RestoreUniqueId(0);
        }

        private void RestoreIdConsistency()
        {
            if (Games.Count()>0)
                Game.RestoreUniqueId(Games.Max(g => g.Id)+1);
        }

        public async Task SaveDataAsync()
        {
            try
            {
                string json = JsonSerializer.Serialize(Games, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        private async void LoadDataAsync()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = await File.ReadAllTextAsync(FilePath);
                    Games = JsonSerializer.Deserialize<List<Game>>(json) ?? new();
                    RestoreIdConsistency();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                Games = new();
            }
        }

        public async Task ImportDataAsync()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select yout kingdom-legacy-companion Json data.",
            });

            if (result != null)
            {
                using var stream = await result.OpenReadAsync();
                using var reader = new StreamReader(stream);
                string json = await reader.ReadToEndAsync();

                Games = JsonSerializer.Deserialize<List<Game>>(json) ?? Games;
            }
        }

        public async Task ExportDataAsync()
        {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException();
            
            await Share.Default.RequestAsync(new ShareFileRequest
            {
                File = new ShareFile(FilePath)
            });
        }
    }
}
