using VikingAge.Core;
using VikingAge.Core.Utilities;

namespace VikingAge.UI
{
    internal class Menu: GameManager
    {
        public GameLogic GameLogic { get; set; } = new();
        public VillagersEngine VillagersEngine { get; set; } = new();
        public VillageEngine VillageEngine { get; set; } = new();

        public void StartGame(Menu menu)
        {
            Load(menu, VillagersEngine, VillageEngine);
        }

        public void MainMenu()
        {
            ClearConsole();

            Console.WriteLine("\n=== Main Menu ===\n");
            Console.WriteLine("1: Village");
            Console.WriteLine("2: Villagers");
            Console.WriteLine("3: Statistics");
            Console.WriteLine("4: Next year");
            Console.WriteLine("0: Exit\n");

            Console.WriteLine("Sellect action:");
            int choice = Tools.NumberSellection(Console.ReadLine(), 4);

            switch (choice)
            {
                case 0: Environment.Exit(0); break;
                case 1: Village(); break;
                case 2: Villagers(); break;
                case 3: Statistics(); break;
                case 4: GameLogic.NextYear(); break;
            }
        }

        private void Village()
        {
            ClearConsole();

            Console.WriteLine("\n=== Village ===\n");
            Console.WriteLine("1: Overview");
            Console.WriteLine("2: Build");
            Console.WriteLine("0: Back to Main Menu\n");

            Console.WriteLine("Sellect action:");
            int choice = Tools.NumberSellection(Console.ReadLine(), 2);

            switch (choice)
            {
                case 0: break;
                case 1: VillageEngine.VillageOverview(); break;
                case 2: VillageEngine.Build(); break;
            }
        }

        private void Villagers()
        {
            ClearConsole();

            Console.WriteLine("\n=== Villagers ===\n");
            Console.WriteLine("1: Overview");
            Console.WriteLine("0: Back to Main Menu\n");

            Console.WriteLine("Setllect action:");

            int choice = Tools.NumberSellection(Console.ReadLine(), 1);

            switch (choice)
            {
                case 0: break;
                case 1: VillagersEngine.VillagersOverview(); break;
            }
        }
    }
}
