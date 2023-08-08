using VikingAge.Core.Manager;

namespace VikingAge.Core
{   // What a change
    static class Tools
    {
        public static int NumberSellection(string number, int range)
        {
            int result = 0;
            bool parsed = false;
            while (!parsed)
            {
                parsed = int.TryParse(number, out result);

                if (!parsed)
                {
                    Console.WriteLine("Input a whole number:");
                    number = Console.ReadLine();
                }
                else if (result > range)
                {
                    Console.WriteLine($"Input a number bellow {range + 1}");
                    parsed = false;
                    number = Console.ReadLine();
                }
            }

            return result;
        }
    }
}
