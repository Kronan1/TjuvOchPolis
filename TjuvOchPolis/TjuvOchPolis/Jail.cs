using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Jail
    {
        public List<Thief> JailList { get; set; }

        public Jail()
        {
            JailList = new List<Thief>();
        }

        public void DrawJail()
        {
            char[,] board = new char[4, 10];
            for (int i = 0; i < board.GetLength(1) + 2; i++)
            {
                Console.Write('=');
            }
            Console.WriteLine();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write('|');
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] is Thief)
                    {
                        Console.Write('T');
                    }
                    else
                    {
                        Console.Write(' ');
                    }

                }
                Console.Write('|');
                Console.WriteLine();
            }

            for (int i = 0; i < board.GetLength(1) + 2; i++)
            {
                Console.Write('=');
            }
            Console.WriteLine();
        }

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
                DateTime dateTime = DateTime.Now;
                TimeSpan timeSpan = dateTime - JailList[i].JailTime;

                if (timeSpan.TotalSeconds > 10)
                {
                    JailList[i].InJail = false;
                    prisonersReleased.Add(JailList[i]);
                    JailList.RemoveAt(i);
                    i--;
                }
            }
            return prisonersReleased;

        }
    }
}
