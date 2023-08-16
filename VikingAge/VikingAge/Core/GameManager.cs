using System.Text.Json;
using VikingAge.Objects.Buildings;
using VikingAge.Objects.Buildings.Housing;
using VikingAge.Objects.Characters;
using VikingAge.UI;

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

        // Classes
        public Menu MenuRef { get; set; }
        public VillageEngine VillageEngineRef { get; set; }
        public VillagersEngine VillagersEngineRef { get; set; }
        public Resources Resources { get; set; } = new();

        // Data
        public int Year { get; set; }
        public List<IBuildings> Buildings { get; private set; } = new();
        public List<ICharacters> Characters { get; set; } = new();


        // Resources header
        public void DisplayResources()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Gold: {Resources.Gold}, Food: {Resources.Food}, Wood: {Resources.Wood}, Tools: {Resources.Tools}, Ore: {Resources.Ore}");
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
        // Construct 3 houses
        // Construct 6 new Villagers
        // Set resources for the start
        // Should I add dificulty options, that changes starting conditions?
        
        // BUG: Villagers and Houses are created but not showing in the game overview
        //      If I try to assign a residence to a Villager, the Buildings list is cleared for some reason
        private void NewGame()
        {
            for (int i = 0; i < 3; i++)
            {
                House house = VillageEngineRef.ConstructHouse();
                house.Usable = true;
                Buildings.Add(house);
            }
            for (int i = 0; i < 6; i++)
            {
                Characters.Add(VillagersEngineRef.MakeVillager());
            }

            Resources.Wood = 200;
            Resources.Gold = 50;
            Resources.Food = 100;
            Resources.Tools = 10;
            Resources.Ore = 0;
        }

        // Load data from JSON, if exists
        // If not, start NewGame()
        public void Load(Menu menu, VillagersEngine villagersEngine, VillageEngine villageEngine)
        {
            MenuRef = menu;
            VillageEngineRef = villageEngine;
            VillagersEngineRef = villagersEngine;

            if (!File.Exists(VillageFile))
            {
                NewGame();
                return;
            }

            Buildings = JsonSerializer.Deserialize<List<IBuildings>>(File.ReadAllText(VillageFile));
            Characters = JsonSerializer.Deserialize<List<ICharacters>>(File.ReadAllText(CharactersFile));
            Resources = JsonSerializer.Deserialize<Resources>(File.ReadAllText(ResourcesFile));
        }

        // Save data to JSON
        public void Save()
        {
            File.WriteAllText(VillageFile, JsonSerializer.Serialize(Buildings));
            File.WriteAllText(CharactersFile, JsonSerializer.Serialize(Characters));
            File.WriteAllText(ResourcesFile, JsonSerializer.Serialize(Resources));
        }
    }
}
