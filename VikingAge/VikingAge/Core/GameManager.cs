using System.Text.Json;
using VikingAge.Objects.Buildings;
using VikingAge.Objects.Characters;

namespace VikingAge.Core
{
    internal abstract class GameManager
    {
        // This class holds all the valuable information about the game, its progression and saving system
        // TODO: Implement NewGame()
        // TODO: Implement resources management

        private const string VillageFile = "VillageData.json";
        private const string CharactersFile = "CharactersData.json";
        private const string ResourcesFile = "ResourcesData.json";

        public int Year { get; set; }
        public List<IBuildings> Buildings { get; set; } = new();
        public List<ICharacters> Characters { get; set; } = new();

        Resources resources = new Resources();

        // Resources header
        public void DisplayResources()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Gold: {resources.Gold}, Food: {resources.Food}, Wood: {resources.Wood}, Tools: {resources.Tools}, Ore: {resources.Ore}");
            Console.WriteLine(new string('-', 50));
            Console.ForegroundColor = ConsoleColor.White;
        }

        // I don't know what to use this for yet
        public void Statistics()
        {
            throw new NotImplementedException();
        }

        // Clean console and display resources header
        public void ClearConsole()
        {
            Console.Clear();
            DisplayResources();
        }

        // Start a new game
        // Construct 6 new Villagers
        // Set resources for the start
        // Should I add dificulty options, that changes starting conditions?
        private void NewGame()
        {
            throw new NotImplementedException();
        }

        // Load data from JSON, if exists
        // If not, start NewGame()
        public void Load()
        {
            if (!File.Exists(VillageFile))
            {
                NewGame();
                return;
            }

            Buildings = JsonSerializer.Deserialize<List<IBuildings>>(File.ReadAllText(VillageFile));
            Characters = JsonSerializer.Deserialize<List<ICharacters>>(File.ReadAllText(VillageFile));
            resources = JsonSerializer.Deserialize<Resources>(File.ReadAllText(ResourcesFile));
        }

        // Save data to JSON
        public void Save()
        {
            File.WriteAllText(VillageFile, JsonSerializer.Serialize(Buildings));
            File.WriteAllText(VillageFile, JsonSerializer.Serialize(Characters));
            File.WriteAllText(ResourcesFile, JsonSerializer.Serialize(resources));
        }
    }
}
