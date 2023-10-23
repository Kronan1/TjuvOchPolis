using Microsoft.VisualBasic;
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

        public override string Interact(Person person2)
        {
            if (person2 is Police)
            {
                return "Tjuv " + Lastname + " säger hej till polis " + person2.Lastname;
            }
            else if (person2 is Thief)
            {
                return "Tjuv " + Lastname + " fnissar åt tjuv " + person2.Lastname;
            }
            else if (person2 is Citizen)
            {
                return "Tjuv " + Lastname + " rånar medborgare " + person2.Lastname;
            }
            return "Error tjuv";
        }
    }
}
