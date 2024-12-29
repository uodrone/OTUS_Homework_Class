using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTUS_Homework_Class
{
    internal class PlanetsCatalogue
    {
        public List<Planet> Planets {  get; set; }
        int CountRequestPlanet;

        public PlanetsCatalogue(List<Planet> planets)
        {
            Planets = planets;
        }

        public (string? name, int? num, int? EqLength, string? ErrMessage) GetPlanet (string Name)
        {
            CountRequestPlanet++;
            if (CountRequestPlanet % 3 == 0)
            {
                return (null, null, null, "Вы спрашиваете слишком часто");
            } 
            else
            {
                foreach (var planet in Planets) {
                    if (planet.Name == Name) {
                        return (planet.Name, planet.Number, planet.EquatorLength, null);
                    }
                }

                return (null, null, null, "Не удалось найти планету");
            }
        }
    }
}
