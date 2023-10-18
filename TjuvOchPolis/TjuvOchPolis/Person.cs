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

        public char Type { get; set; }

        public static List<Person> CreateList(char[,] board)
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 20; i++)
            {
                Random rnd = new Random();
                switch (rnd.Next(0, 3))
                {
                    case 0:
                        Police police = new Police();
                        police.InitializePerson(board);
                        persons.Add(police);
                        break;

                    case 1:
                        Thief thief = new Thief();
                        thief.InitializePerson(board);
                        persons.Add(thief);
                        break;

                    case 2:
                        Citizen citizen = new Citizen();
                        citizen.InitializePerson(board);
                        persons.Add(citizen);
                        break;
                }
            }
            return persons;

        }

        public void InitializePerson(char[,] board)
        {
            Random rand = new Random();
            X = rand.Next(0, board.GetLength(1));
            Y = rand.Next(0, board.GetLength(0));



        }

        public Person()
        {
            Random random = new Random();
            Direction = random.Next(0, 6);

        }


    }
}
