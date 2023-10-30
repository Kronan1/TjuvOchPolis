using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Poorhouse
    {
        public List<Person> PoorhouseList { get; set; } = new List<Person>();
        public char[,] Board { get; set; } = new char[4, 40];

        public List<Person> PutPeopleInPoorhouse(List<Person> persons, Interactions interactions)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i] is Citizen citizen && citizen.InPoorhouse)
                {
                    Random rnd = new Random();
                    citizen.X = rnd.Next(0, Board.GetLength(1));
                    citizen.Y = rnd.Next(0, Board.GetLength(0));
                    PoorhouseList.Add(citizen);
                    persons.RemoveAt(i);
                    i--;
                }
            }

            return persons;
        }

    }
}
