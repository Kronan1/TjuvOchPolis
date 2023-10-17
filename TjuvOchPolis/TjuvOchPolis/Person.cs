using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Person
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Direction { get; set; }

        public List<Valuable> Valuables { get; set; }

        public char Type { get; set; }

        public static List<Person> CreateList()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 20; i++)
            {
                Random rnd = new Random();
                switch (rnd.Next(0, 3))
                {
                    case 0:
                        Police police = new Police();
                        persons.Add(police);
                        break;

                    case 1:
                        Thief thief = new Thief();
                        persons.Add(thief);
                        break;

                    case 2:
                        Citizen citizen = new Citizen();
                        persons.Add(citizen);
                        break;
                }
            }
            return persons;

        }

    }
}
