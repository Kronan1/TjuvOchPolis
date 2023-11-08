using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Jail
    {

        public List<Person> JailList { get; set; } = new List<Person>();
        public char[,] Board = new char[4, 20];

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
