using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Jail
    {
        public List<Person> JailList { get; set; }
        public char[,] Board = new char[4, 20];
        public Jail()
        {
            JailList = new List<Person>();
        }

        //public void DrawJail()
        //{
        //    char[,] board = new char[4, 10];
        //    for (int i = 0; i < board.GetLength(1) + 2; i++)
        //    {
        //        Console.Write('=');
        //    }
        //    Console.WriteLine();

        //    for (int i = 0; i < board.GetLength(0); i++)
        //    {
        //        Console.Write('|');
        //        for (int j = 0; j < board.GetLength(1); j++)
        //        {
        //            if (board[i, j] is Thief)
        //            {
        //                Console.Write('T');
        //            }
        //            else
        //            {
        //                Console.Write(' ');
        //            }

        //        }
        //        Console.Write('|');
        //        Console.WriteLine();
        //    }

        //    for (int i = 0; i < board.GetLength(1) + 2; i++)
        //    {
        //        Console.Write('=');
        //    }
        //    Console.WriteLine();
        //}

        public List<Person> PutPeopleInJail(List<Person> persons)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i] is Thief thief && thief.InJail)
                {
                    thief.JailTime = DateTime.Now;
                    JailList.Add(thief);
                    persons.RemoveAt(i);
                    i--;
                }
            }
            persons.AddRange(Parole());
            
            return persons;



        }

        public List<Person> Parole()
        {
            List<Person> prisonersReleased = new List<Person>();
            for (int i = 0; i < JailList.Count; i++)
            {
                Thief thief = (Thief)JailList[i];
                DateTime dateTime = DateTime.Now;
                TimeSpan timeSpan = dateTime - thief.JailTime;

                if (timeSpan.TotalSeconds > 10)
                {
                    thief.InJail = false;
                    prisonersReleased.Add(thief);
                    JailList.RemoveAt(i);
                    i--;
                }
            }
            return prisonersReleased;

        }
    }
}
