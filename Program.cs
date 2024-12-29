using System.Numerics;
using System.Threading.Channels;

namespace OTUS_Homework_Class
{
    public class Program
    {

        static void Main()
        {

            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Программа 2");
            Console.WriteLine();
            Console.ResetColor();

            var Venus = new Planet("Венера", 2, 38025, null);
            var Earth = new Planet("Земля", 3, 40075, Venus);
            var Mars = new Planet("Марс", 4, 21326, Earth);

            var PlanetsList = new PlanetsCatalogue(new List<Planet> { Venus, Earth, Mars });
            DisplayPlanetToScreen(PlanetsList, "Земля");
            DisplayPlanetToScreen(PlanetsList, "Лимония");
            DisplayPlanetToScreen(PlanetsList, "Марс");
            DisplayPlanetToScreen(PlanetsList, "Венера");
            Console.WriteLine();
        }

        static void DisplayPlanetToScreen (PlanetsCatalogue PlanetsList, string? Name)
        {
            var (number, equator, error) = PlanetsList.GetPlanet(Name);

            if (error != null)
            {
                Console.WriteLine(error);
                Console.WriteLine();
            } 
            else
            {
                Console.WriteLine($"Название планеты: {Name}");
                Console.WriteLine($"Порядковый номер от солнца: {number}");
                Console.WriteLine($"Длина экватора: {equator}");
                Console.WriteLine();
            }
        }
    }
}
