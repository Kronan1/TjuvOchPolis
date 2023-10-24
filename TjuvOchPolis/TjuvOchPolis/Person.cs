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

        public List<Person> PersonsMet { get; set; }
        public string Lastname { get; set; }


        public static List<Person> CreateList(char[,] board, List<string> nameList)
        {
            List<Person> persons = new List<Person>();
            //for (int i = 0; i < 30; i++)
            //{
            //    Random rnd = new Random();
            //    int nameNumber = rnd.Next(0, nameList.Count);
            //    switch (rnd.Next(0, 3))
            //    {
            //        case 0:
            //            Police police = new Police();
            //            police.InitializePerson(board);
            //            police.Lastname = nameList[nameNumber];
            //            nameList.RemoveAt(nameNumber);
            //            persons.Add(police);
            //            break;

            //        case 1:
            //            Thief thief = new Thief();
            //            thief.InitializePerson(board);
            //            thief.Lastname = nameList[nameNumber];
            //            nameList.RemoveAt(nameNumber);
            //            persons.Add(thief);
            //            break;

            //        case 2:
            //            Citizen citizen = new Citizen();
            //            citizen.InitializePerson(board);
            //            citizen.Lastname = nameList[nameNumber];
            //            nameList.RemoveAt(nameNumber);
            //            persons.Add(citizen);
            //            break;
            //    }
            //}
            Random rnd = new Random();
            int nameNumber = 0;
            for (int i = 0; i < 10; i++)
            {
                nameNumber = rnd.Next(0, nameList.Count);
                Thief thief = new Thief();
                thief.InitializePerson(board);
                thief.Lastname = nameList[nameNumber];
                nameList.RemoveAt(nameNumber);
                persons.Add(thief);

            }
            for (int i = 0; i < 15; i++)
            {
                nameNumber = rnd.Next(0, nameList.Count);
                Police police = new Police();
                police.InitializePerson(board);
                police.Lastname = nameList[nameNumber];
                nameList.RemoveAt(nameNumber);
                persons.Add(police);

            }
            
            for (int i = 0; i < 10; i++)
            {
                nameNumber = rnd.Next(0, nameList.Count);
                Citizen citizen = new Citizen();
                citizen.InitializePerson(board);
                citizen.Lastname = nameList[nameNumber];
                nameList.RemoveAt(nameNumber);
                persons.Add(citizen);

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
            PersonsMet = new List<Person>();

        }

        public virtual string Interact(Person person2)
        {
            return "Error person";
        }


    }
}
