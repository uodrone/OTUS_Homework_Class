using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OTUS_Homework_Class
{
    public class PlanetsCatalogue
    {
        public List<Planet> Planets { get; set; }
        public int CountRequestPlanet;
        public delegate string LyambdaValidator(string name);

        public PlanetsCatalogue(List<Planet> planets)
        {
            Planets = planets;
        }

        public ValueTuple<int?, int?, string?> GetPlanet(string name, LyambdaValidator lyambdaValidator)
        {
            string error = lyambdaValidator(name);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, null, error);
            }
            else
            {
                foreach (var planet in Planets)
                {
                    if (planet.Name == name)
                    {
                        return (planet.Number, planet.EquatorLength, null);
                    }
                }

                return (null, null, "Не удалось найти планету");
            }
        }
    }
}
