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

        public bool InJail { get; set; }

        public DateTime JailTime { get; set; }

        public Thief() 
        {
            Type = 'T';
            Loot = new List<Valuable>();
        }

        public override string Interact(Person person2)
        {
            if (person2 is Police)
            {
                if (Loot.Count > 0 && !InJail)
                {
                    InJail = true;
                    JailTime = DateTime.Now;
                }
                return "Tjuv " + Lastname + " pekar finger åt polis " + person2.Lastname;
            }
            else if (person2 is Thief)
            {
                return "Tjuv " + Lastname + " fnissar åt tjuv " + person2.Lastname;
            }
            else if (person2 is Citizen citizen)
            {
                if (citizen.Valuables.Count > 0)
                {
                    Loot.Add(citizen.Valuables[0]);
                    citizen.Valuables.RemoveAt(0);
                    return "Tjuv " + Lastname + " rånar medborgare " + person2.Lastname + " på dess " + Loot[Loot.Count - 1];
                }
                return "Tjuv " + Lastname + " blir sur på " + person2.Lastname + " som inte har något värdefullt";
            }
            return "Error tjuv";
        }
    }
}
