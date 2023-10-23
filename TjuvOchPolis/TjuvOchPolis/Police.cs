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
            if (person2 is Police)
            {
                return "Polis " + Lastname + " säger hej till polis " + person2.Lastname;
            }
            else if (person2 is Thief thief)
            {
                if (thief.Loot.Count > 0 && !thief.InJail)
                {
                    thief.InJail = true;
                    thief.JailTime = DateTime.Now;
                    return "Polis " + Lastname + " Hittar stöldgods hos tjuv " + thief.Lastname + " och arresterar den djäveln";
                }
                return "Polis " + Lastname + " tittar misstänksamt på tjuven " + person2.Lastname;
            }
            else if (person2 is Citizen)
            {
                return "Polis " + Lastname + " hälsar på medborgare " + person2.Lastname;
            }

            return "Error polis";
        }
    }
}
