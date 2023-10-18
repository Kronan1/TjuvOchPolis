using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Thief : Person
    {
        public List<Valuable> Loot { get; set; }

        public Thief() 
        {
            Type = 'T';
            
        }
    }
}
