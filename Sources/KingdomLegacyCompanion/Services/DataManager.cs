using System.Text.Json;
using Model;

namespace Services
{
    public class DataManager
    {
        private static DataManager _instance;
        private static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "gameData.json");

        public List<Game> Games { get; private set; } = new();

        public static DataManager Instance => _instance ??= new DataManager();

        private DataManager()
        {
            LoadDataAsync();
            CheckIdConsistency();
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

        private void CheckIdConsistency()
        {
            int maxId = -1;
            foreach (var game in Games)
            {
                if (game.Id > maxId)
                    maxId = game.Id;
            }
            Game.RestoreUniqueId(maxId + 1);
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                Games = new();
            }
        }
    }
}
