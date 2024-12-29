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

        public ValueTuple<int?, int?, string?> GetPlanet (string name)
        {
            CountRequestPlanet++;
            if (CountRequestPlanet % 3 == 0)
            {
                return (null, null, "Вы спрашиваете слишком часто");
            } 
            else
            {
                foreach (var planet in Planets) {
                    if (planet.Name == name) {
                        return (planet.Number, planet.EquatorLength, null);
                    }
                }

                return (null, null, "Не удалось найти планету");
            }
        }
    }
}
