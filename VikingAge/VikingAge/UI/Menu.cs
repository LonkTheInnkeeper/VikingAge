using VikingAge.Core;
using VikingAge.Core.Engines;
using VikingAge.Core.Manager;

namespace VikingAge.UI
{

    internal class Menu: GameManager
    {
        GameLogic gameLogic = new GameLogic();
        VillageEngine village = new VillageEngine();
        VillagersEngine villagers = new VillagersEngine();

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
                case 4: gameLogic.NextYear(); break;
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
                case 1: village.VillageOverview(); break;
                case 2: village.Build(); break;
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
                case 1: villagers.VillagersOverview(); break;
            }
        }
    }
}
