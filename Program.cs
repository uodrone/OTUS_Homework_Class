using System.Numerics;

namespace OTUS_Homework_Class
{
    public class Program
    {

        static void Main()
        {
            PlanetCreate();
        }

        static void PlanetCreate ()
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
