using System.Numerics;
using System.Threading.Channels;

namespace OTUS_Homework_Class
{
    public class Program
    {

        static void Main()
        {
            //Planets();

            var Venus = new Planet("Венера", 2, 38025, null);
            var Earth = new Planet("Земля", 3, 40075, Venus);
            var Mars = new Planet("Марс", 4, 21326, Earth);

            var PlanetsList = new PlanetsCatalogue(new List<Planet> { Venus, Earth, Mars });
            DisplayPlanetToScreen(PlanetsList, "Земля");
            DisplayPlanetToScreen(PlanetsList, "Лимония");
            DisplayPlanetToScreen(PlanetsList, "Марс");
            DisplayPlanetToScreen(PlanetsList, "Венера");
        }

        static void DisplayPlanetToScreen (PlanetsCatalogue PlanetsList, string? Name)
        {
            var Planet = PlanetsList.GetPlanet(Name).ToTuple();

            if (Planet.Item4 != null)
            {
                Console.WriteLine(Planet.Item4);
                Console.WriteLine();
            } else
            {
                Console.WriteLine($"Название планеты: {Planet.Item1}");
                Console.WriteLine($"Порядковый номер от солнца: {Planet.Item2}");
                Console.WriteLine($"Длина экватора: {Planet.Item3}");
                Console.WriteLine();
            }
        }

        static void Planets ()
        {
            var Venus = new
            {
                Name = "Венера",
                Number = 2,
                EquatorLength = 38025,
                PrevPlanet = "Меркурий" //если с new Object() то equals не сработает со вторым экземпляром
            };

            var Earth = new
            {
                Name = "Земля",
                Number = 3,
                EquatorLength = 40075,
                PrevPlanet = Venus
            };

            var Mars = new
            {
                Name = "Марс",
                Number = 4,
                EquatorLength = 21326,
                PrevPlanet = Earth
            };

            var OtherVenus = new
            {
                Name = "Венера",
                Number = 2,
                EquatorLength = 38025,
                PrevPlanet = "Меркурий"
            };

            var PlanetList = new List<Object> { Venus, Earth, Mars, OtherVenus };

            foreach (var Planet in PlanetList) {
                Console.WriteLine("Информация о планете:");
                Console.WriteLine($"Название: {Planet.GetType().GetProperty("Name").GetValue(Planet)}");
                Console.WriteLine($"Порядковый номер от Солнца: {Planet.GetType().GetProperty("Number").GetValue(Planet)}");
                Console.WriteLine($"Длина экватора: {Planet.GetType().GetProperty("EquatorLength").GetValue(Planet)}");
                Console.WriteLine($"Ссылка на предыдущую планету: {Planet.GetType().GetProperty("PrevPlanet").GetValue(Planet)}");

                if (Planet.Equals(Venus))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Планета эквивалентра Венере");
                    Console.ResetColor();
                } 
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Планета НЕ эквивалента Венере");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }
    }
}
