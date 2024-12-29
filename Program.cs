using System.Numerics;
using System.Threading.Channels;
using System.Xml.Linq;

namespace OTUS_Homework_Class
{
    public class Program
    {
        static int CountRequest = 1;

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Программа 3");
            Console.WriteLine("Валидация частоты запросов");
            Console.WriteLine();
            Console.ResetColor();

            var Venus = new Planet("Венера", 2, 38025, null);
            var Earth = new Planet("Земля", 3, 40075, Venus);
            var Mars = new Planet("Марс", 4, 21326, Earth);

            string ValidateRequestFrequency(string name) => (CountRequest++ % 3 == 0) ? "Вы спрашиваете слишком часто" : null;
            string ValidatePlanetForbidden(string name) => name == "Лимония" ? "Это запретная планета" : null;

            var PlanetsList = new PlanetsCatalogue(new List<Planet> { Venus, Earth, Mars });
            DisplayPlanetToScreen(PlanetsList, "Земля", ValidateRequestFrequency);
            DisplayPlanetToScreen(PlanetsList, "Лимония", ValidateRequestFrequency);
            DisplayPlanetToScreen(PlanetsList, "Марс", ValidateRequestFrequency);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Валидация запретности планеты");
            Console.WriteLine();
            Console.ResetColor();
            PlanetsList = new PlanetsCatalogue(new List<Planet> { Venus, Earth, Mars });
            DisplayPlanetToScreen(PlanetsList, "Земля", ValidatePlanetForbidden);
            DisplayPlanetToScreen(PlanetsList, "Лимония", ValidatePlanetForbidden);
            DisplayPlanetToScreen(PlanetsList, "Марс", ValidatePlanetForbidden);

            Console.WriteLine();
        }

        static void DisplayPlanetToScreen(PlanetsCatalogue PlanetsList, string Name, PlanetsCatalogue.LyambdaValidator lyambdaValidator)
        {
            var (number, equator, error) = PlanetsList.GetPlanet(Name, lyambdaValidator);

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
