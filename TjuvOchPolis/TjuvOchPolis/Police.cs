using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Police : Person
    {
        public List<Valuable> ConfiscatedLoot { get; set; }

        public Police()
        {
            Type = 'P';
            ConfiscatedLoot = new List<Valuable>();
        }

        public override string Interact(Person person2)
        {
            if (person2 is Police police)
            {
                return "Polis " + Lastname + " säger hej till polis " + police.Lastname;
            }
            else if (person2 is Thief thief)
            {
                if (thief.Loot.Count > 0 && !thief.InJail)
                {
                    thief.InJail = true;
                    thief.JailTime = DateTime.Now;
                    ConfiscatedLoot.AddRange(thief.Loot);
                    thief.Loot.Clear();
                    return "Polis " + Lastname + " Hittar stöldgods hos tjuv " + thief.Lastname + " och arresterar samt tar stöldgodset";
                }
                return "Polis " + Lastname + " tittar misstänksamt på tjuven " + thief.Lastname;
            }
            else if (person2 is Citizen citizen)
            {
                if( citizen.Valuables.Count == 0)
                {
                    citizen.InPoorhouse = true;
                    return "Polis " + Lastname + " stoppar medborgare " + citizen.Lastname + " i fattighuset";
                }
                return "Polis " + Lastname + " hälsar på medborgare " + citizen.Lastname;
            }

            return "Error polis";
        }
    }
}
