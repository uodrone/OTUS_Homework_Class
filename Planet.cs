using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTUS_Homework_Class
{
    public class Planet
    {
        public string Name { get; }
        public int Number { get; }
        public int EquatorLength { get; }
        public Planet? PrevisionPlanet { get; }

        public Planet (string name, int number, int equatorLength, Planet previsionPlanet)
        {
            Name = name;
            Number = number;
            EquatorLength = equatorLength;
            PrevisionPlanet = previsionPlanet;
        }
    }
}
