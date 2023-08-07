using VikingAge.Core.Manager;
using VikingAge.Objects.Buildings;
using VikingAge.Objects.Buildings.Housing;
using VikingAge.Objects.Buildings.Resources;
using VikingAge.Objects.Buildings.Services;

namespace VikingAge.Core.Engines
{
    internal class VillageEngine: GameManager
    {
        List<Farm> farms = new List<Farm>();
        List<ForesterLodge> foresterLodges = new List<ForesterLodge>();
        List<Forge> forges = new List<Forge>();
        List<Mine> mines = new List<Mine>();
        List<House> houses = new List<House>();
        List<Tavern> taverns = new List<Tavern>();

        public void Build()
        {
            ClearConsole();

            Console.WriteLine("\n=== Village Construction ===\n");
            Console.WriteLine("What do you want to build?");
            Console.WriteLine("1. Farm");
            Console.WriteLine("2. Forester Lodge");
            Console.WriteLine("3. Forge");
            Console.WriteLine("4. Mine");
            Console.WriteLine("5. House");
            Console.WriteLine("6. Tavern");
            Console.WriteLine("0. Cancel");

            int choice = Tools.NumberSellection(Console.ReadLine(), 6);
            switch (choice)
            {
                case 0: break;
                case 1: Buildings.Add(ConstructFarm()); break;
                case 2: Buildings.Add(ConstructForester()); break;
                case 3: Buildings.Add(ConstructForge()); break;
                case 4: Buildings.Add(ConstructMine()); break;
                case 5: Buildings.Add(ConstructHouse()); break;
                case 6: Buildings.Add(ConstructTavern()); break;
            }

            GetBuildings();
        }

        public void VillageOverview()
        {
            ClearConsole();

            GetBuildings();

            Console.WriteLine($"\nSum of all buildings: {Buildings.Count}\n");

            Console.WriteLine($"\nFARMS: {farms.Count}\n");
            foreach (Farm farm in farms)
            {
                Console.WriteLine($"Name: {farm.Name}");
                Console.WriteLine($"Workers: {farm.TotalWorkers}");
                Console.WriteLine($"Production: {farm.Production}\n");
            }

            Console.WriteLine($"\nFORESTER LODGES: {foresterLodges.Count}\n");
            foreach (ForesterLodge lodge in foresterLodges)
            {
                Console.WriteLine($"Name: {lodge.Name}");
                Console.WriteLine($"Workers: {lodge.TotalWorkers}");
                Console.WriteLine($"Production: {lodge.Production}\n");
            }

            Console.WriteLine($"\nFORGES: {forges.Count}\n");
            foreach (Forge forge in forges)
            {
                Console.WriteLine($"Name: {forge.Name}");
                Console.WriteLine($"Workers: {forge.TotalWorkers}");
                Console.WriteLine($"Production: {forge.Production}\n");
            }

            Console.WriteLine($"\nMINES: {mines.Count}\n");
            foreach (Mine mine in mines)
            {
                Console.WriteLine($"Name: {mine.Name}");
                Console.WriteLine($"Workers: {mine.TotalWorkers}");
                Console.WriteLine($"Production: {mine.Production}\n");
            }

            Console.WriteLine($"\nTAVERNS: {taverns.Count}\n");
            foreach (Tavern tavern in taverns)
            {
                Console.WriteLine($"Name: {tavern.Name}");
                Console.WriteLine($"Workers: {tavern.TotalWorkers}");
                Console.WriteLine($"Production: {tavern.Production}\n");
            }

            Console.WriteLine($"\nHOUSES: {houses.Count}\n");
            foreach (House house in houses)
            {
                Console.WriteLine($"Name: {house.Name}");
                Console.WriteLine($"Workers: {house.TotalWorkers}");
                Console.WriteLine($"Production: {house.Production}\n");
            }

            Console.WriteLine("Press enter");
            Console.ReadLine();
        }

        private void GetBuildings()
        {
            farms.Clear();
            foresterLodges.Clear();
            forges.Clear();
            mines.Clear();
            houses.Clear();
            taverns.Clear();

            foreach (IBuildings building in Buildings)
            {
                if (building is Farm)
                {
                    farms.Add((Farm)building);
                }
                else if (building is ForesterLodge)
                {
                    foresterLodges.Add((ForesterLodge)building);
                }
                else if (building is Forge)
                {
                    forges.Add((Forge)building);
                }
                else if (building is Mine)
                {
                    mines.Add((Mine)building);
                }
                else if (building is House)
                {
                    houses.Add((House)building);
                }
                else if (building is Tavern)
                {
                    taverns.Add((Tavern)building);
                }
            }
        }

        private Farm ConstructFarm()
        {
            Farm farm = new Farm();
            farm.Name = $"Farm {farms.Count + 1}";
            farm.Usable = false;
            farm.Id = Buildings.Count;
            return farm;
        }

        private ForesterLodge ConstructForester()
        {
            ForesterLodge forester = new ForesterLodge();
            forester.Name = $"Forester Lodge {foresterLodges.Count + 1}";
            forester.Usable = false;
            forester.Id = Buildings.Count;
            return forester;
        }

        private Forge ConstructForge()
        {
            Forge forge = new Forge();
            forge.Name = $"Forge {forges.Count + 1}";
            forge.Usable = false;
            forge.Id = Buildings.Count;
            return forge;
        }

        private Mine ConstructMine()
        {
            Mine mine = new Mine();
            mine.Name = $"Mine {mines.Count + 1}";
            mine.Usable = false;
            mine.Id = Buildings.Count;
            return mine;
        }

        private House ConstructHouse()
        {
            House house = new House();
            house.Name = $"House {houses.Count + 1}";
            house.Usable = false;
            house.Id = Buildings.Count;
            return house;
        }

        private Tavern ConstructTavern()
        {
            Tavern tavern = new Tavern();
            tavern.Name = $"Tavern {taverns.Count + 1}";
            tavern.Usable = false;
            tavern.Id = Buildings.Count;
            return tavern;
        }
    }
}