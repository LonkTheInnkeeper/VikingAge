using System.Xml.Serialization;
using VikingAge.Core.Manager;
using VikingAge.Objects.Buildings.Housing;
using VikingAge.Objects.Characters;

namespace VikingAge.Core.Engines
{
    internal class VillagersEngine: GameManager
    {
        public List<Villager> Villagers { get; set; }

        public void VillagersOverview()
        {
            Console.WriteLine($"Sum of all characters: {Characters.Count}");
            Console.WriteLine($"Sum of villagers: {GetVillagersCount()}");

            foreach (Villager villager in Characters)
            {
                Console.WriteLine($"\nName: {villager.Name}");
                Console.WriteLine($"Age: {villager.Age}");
                Console.WriteLine($"Sex: {villager.Sex}");
                Console.WriteLine($"Profession: {villager.Profession}");
                Console.WriteLine($"Residence: {villager.Residence.Name}");
                Console.WriteLine($"Mother: {villager.Mother.Name}");
                Console.WriteLine($"Father: {villager.Father.Name}");
                Console.WriteLine("Kids:");
                ListKids(villager);
            }

            Console.WriteLine("Press enter");
            Console.ReadLine();
        }

        private int GetVillagersCount()
        {
            int count = 0;
            foreach (Villager villager in Characters)
            {
                count++;
            }
            return count;
        }

        public void GetVillagers()
        {
            foreach (Villager villager in Characters)
            {
                Villagers.Add(villager);
            }
        }

        private void ListKids(Villager villager)
        {
            foreach (Villager kid in villager.Kids)
            {
                Console.WriteLine(kid.Name);
            }
        }

        public void MakeVillager(Villager? mother = null, Villager? father = null)
        {
            Villager villager = new Villager();
            villager.Name = Characters.Count.ToString();    // Temporary
            villager.Age = SetAge();
            villager.Sex = SetSex(villager);
            villager.Mother = mother;
            villager.Father = father;
            villager.Profession = SetProfession(villager);
            villager.Residence = SetResidence(villager);
        }

        private House SetResidence(Villager villager)
        {
            // Choose a residence of parents
            // Else choose a random house
            if (villager.Mother != null)
            {
                return villager.Mother.Residence;
            }
            else if (villager.Father != null)
            {
                return villager.Father.Residence;
            }

            Random rnd = new Random();
            var houses = new List<House>();

            foreach (House house in Buildings)
            {
                houses.Add(house);
            }

            int index = rnd.Next(houses.Count);
            return houses[index];
        }

        private int SetAge()
        {
            // If game just started, set random age
            // Else set 0

            if (Year == 0)
            {
                Random rnd = new Random();
                return rnd.Next(12, 50);
            }
            return 0;
        }

        private Sex SetSex(Villager villager)
        {
            Random rnd = new Random();
            var valuesSex = Enum.GetValues(typeof(Sex));
            return (Sex)valuesSex.GetValue(rnd.Next(valuesSex.Length));
        }

        private Professions SetProfession(Villager villager)
        {
            // If villager doesn't have a mother, set random profession
            // Else choose a profession from one of the parents

            Random rnd = new Random();
            if (villager.Mother == null)
            {
                var valuesProf = Enum.GetValues(typeof(Professions));
                return (Professions)valuesProf.GetValue(rnd.Next(valuesProf.Length));
            }

            Professions[] profs = new[]
            {
                villager.Mother.Profession,
                villager.Father.Profession
            };

            return (Professions)profs.GetValue(rnd.Next(profs.Length));
        }
    }
}
