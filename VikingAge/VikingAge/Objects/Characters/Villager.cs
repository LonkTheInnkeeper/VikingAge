using VikingAge.Objects.Buildings.Housing;

namespace VikingAge.Objects.Characters
{
    internal class Villager : ICharacters
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public Professions Profession { get; set; }
        public Villager Mother { get; set; }
        public Villager Father { get; set; }
        public List<Villager> Kids { get; set; }
        public House Residence { get; set; }
    }
}
