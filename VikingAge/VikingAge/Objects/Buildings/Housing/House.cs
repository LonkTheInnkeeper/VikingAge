namespace VikingAge.Objects.Buildings.Housing
{
    internal class House : IBuildings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxWorkers { get; set; }
        public int TotalWorkers { get; set; }
        public int Production { get; set; }
        public bool Usable { get; set; }
    }
}
