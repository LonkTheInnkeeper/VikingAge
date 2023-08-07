using VikingAge.Objects.Buildings;
using VikingAge.Objects.Characters;

namespace VikingAge.Core.Manager
{
    internal abstract class GameManager
    {
        public int Year { get; set; }
        public List<IBuildings> Buildings { get; set; } = new();
        public List<ICharacters> Characters { get; set; } = new();

        Resources resources = new Resources();

        public void DisplayResources()
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Gold: {resources.Gold}, Food: {resources.Food}, Wood: {resources.Wood}, Tools: {resources.Tools}, Ore: {resources.Ore}");
            Console.WriteLine(new string('-', 50));
            Console.ForegroundColor= ConsoleColor.White;
        }

        public void Statistics()
        {
            throw new NotImplementedException();
        }

        public void ClearConsole()
        {
            Console.Clear();
            DisplayResources();
        }
    }
}
