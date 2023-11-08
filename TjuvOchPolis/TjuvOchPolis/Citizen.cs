using Microsoft.VisualBasic;
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
        public bool InPoorhouse { get; set; }

        public Citizen() 
        {
            Type = 'M';
            Valuables = new List<Valuable>()
            {
                new Valuable("klocka"),
                new Valuable("nycklar"),
                new Valuable("mobil"),
                new Valuable("pengar")
            };
        }

        public override string Interact(Person person2)
        {
            if (person2 is Police police)
            {
                if(Valuables.Count == 0)
                {
                    InPoorhouse = true;
                    return "Medborgare " + Lastname + " blir stoppad av polis " + police.Lastname + " och skickad till fattighuset";
                }
                return "Medborgare " + Lastname + " säger hej till polis " + police.Lastname;
            }
            else if (person2 is Thief thief)
            {
                if (Valuables.Count > 0)
                {
                    thief.Loot.Add(Valuables[0]);
                    Valuables.RemoveAt(0);
                    return "Medborgare " + Lastname + " blir rånad av tjuv " + thief.Lastname + " på dess " + thief.Loot[thief.Loot.Count - 1].Name;
                }
                return "Medborgare " + Lastname + " tittar oroligt på tjuv " + thief.Lastname + " när denne rotar igenom hens tomma fickor";
            }
            else if (person2 is Citizen citizen)
            {
                return "Medborgare " + Lastname + " hälsar på medborgare " + citizen.Lastname;
            }
            return "Error medborgare";
        }
    }
}
