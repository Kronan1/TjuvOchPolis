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
            if (person2 is Police police)
            {
                if (Loot.Count > 0 && !InJail)
                {
                    InJail = true;
                    police.ConfiscatedLoot.AddRange(Loot);
                    Loot.Clear();
                    return "Tjuv " + Lastname + " blir arresterad av polis " + police.Lastname;
                }
                return "Tjuv " + Lastname + " pekar finger åt polis " + police.Lastname;
            }
            else if (person2 is Thief thief)
            {
                return "Tjuv " + Lastname + " fnissar åt tjuv " + thief.Lastname;
            }
            else if (person2 is Citizen citizen)
            {
                if (citizen.Valuables.Count > 0)
                {
                    Loot.Add(citizen.Valuables[0]);
                    citizen.Valuables.RemoveAt(0);
                    return "Tjuv " + Lastname + " rånar medborgare " + citizen.Lastname + " på dess " + Loot[Loot.Count - 1].Name;
                }
                return "Tjuv " + Lastname + " blir sur på " + citizen.Lastname + " som inte har något värdefullt";
            }
            return "Error tjuv";
        }
    }
}
