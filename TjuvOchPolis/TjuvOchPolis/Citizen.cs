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

        public override string Interact(Person person2)
        {
            if (person2 is Police)
            {
                return "Medborgare " + Lastname + " säger hej till polis " + person2.Lastname;
            }
            else if (person2 is Thief)
            {
                return "Medborgare " + Lastname + " blir rånad av tjuv " + person2.Lastname;
            }
            else if (person2 is Citizen)
            {
                return "Medborgare " + Lastname + " hälsar på medborgare " + person2.Lastname;
            }
            return "Error medborgare";
        }
    }
}
