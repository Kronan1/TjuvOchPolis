using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Citizen : Person 
    {
        public List<Valuable> Valuables { get; set; }

        public Citizen() 
        {
            Type = 'C';
            Valuables = new List<Valuable>()
            {
                new Valuable("Watch"),
                new Valuable("Keys"),
                new Valuable("Phone"),
                new Valuable("Money")
            };
        
        }
    }
}
