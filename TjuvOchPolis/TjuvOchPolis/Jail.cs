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
        public char[,] Board = new char[10, 10];
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

        public List<Person> PutPeopleInJail(List<Person> persons, Interactions interactions)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i] is Thief thief && thief.InJail)
                {
                    Random rnd = new Random();
                    thief.X = rnd.Next(0, Board.GetLength(1));
                    thief.Y = rnd.Next(0, Board.GetLength(0));
                    thief.JailTime = DateTime.Now;
                    JailList.Add(thief);
                    persons.RemoveAt(i);
                    i--;
                }
            }
            persons.AddRange(Parole(interactions));
            
            return persons;



        }

        public List<Person> Parole(Interactions interactions)
        {
            List<Person> prisonersReleased = new List<Person>();
            for (int i = 0; i < JailList.Count; i++)
            {
                Thief thief = (Thief)JailList[i];
                DateTime dateTime = DateTime.Now;
                TimeSpan timeSpan = dateTime - thief.JailTime;

                if (timeSpan.TotalSeconds > 30)
                {
                    interactions.Conversations.Add("Tjuv " + thief.Lastname + " släpptes ur fängelset.");
                    interactions.NewConversation = true;
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
