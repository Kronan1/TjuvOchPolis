using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Helpers
    {
        public static char[,] UpdateBoard(char[,] board)
        {
            //Här rensar vi spelplanen
            char[,] newBoard = new char[board.GetLength(0), board.GetLength(1)];
            for (var i = 0; i < newBoard.GetLength(0); i++)
            {
                for (var j = 0; j < newBoard.GetLength(1); j++)
                {
                    newBoard[i, j] = ' ';
                }
            }

            //Här sätter vi in nya personer på spelplanen 
            //foreach (var person in persons)
            //{
            //    if (person is Thief thief && thief.InJail)
            //    {
            //        jail.JailList.Add(thief);
            //    }
            //    else
            //    {
            //        newBoard[person.Y, person.X] = person.Type;
            //    }
            //} 

            return newBoard;
        }

        public static void Move(List<Person> persons, char[,] board, DateTime datetime)
        {

            for (int i = 0; i < persons.Count; i++)
            {
                switch (persons[i].Direction)
                {
                    case 0:
                        persons[i].X++;
                        break;
                    case 1:
                        persons[i].X--;
                        break;
                    case 2:
                        persons[i].Y++;
                        break;
                    case 3:
                        persons[i].Y--;
                        break;
                    case 4:
                        persons[i].Y++;
                        persons[i].X++;
                        break;
                    case 5:
                        persons[i].X--;
                        persons[i].Y--;
                        break;
                }

                //Ser till så att koden inte kraschar när en person går utanför spelplanen. Tänk snake
                if (persons[i].Y > board.GetLength(0) - 1)
                {
                    persons[i].Y = 0;
                }
                else if (persons[i].Y < 0)
                {
                    persons[i].Y = board.GetLength(0) - 1;
                }

                if (persons[i].X > board.GetLength(1) - 1)
                {
                    persons[i].X = 0;
                }
                else if (persons[i].X < 0)
                {
                    persons[i].X = board.GetLength(1) - 1;
                }

            }
        }

        public static void DrawBoard(char[,] board, List<Person> persons)

        {
            if (board.GetLength(0) == 4 && persons.Count > 0)
            {

                int test = 0;
            }

            foreach (Person person in persons)
            {
                board[person.Y, person.X] = person.Type;

            }

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
                    Console.Write(board[i, j]);
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

        public static void CheckCollision(List<Person> persons, Interactions interactions)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                persons[i].PersonsMet.Clear();
            }

            for (int i = 0; i < persons.Count; i++)
            {
                for (int j = 0; j < persons.Count; j++)
                {
                    if (persons[i].X == persons[j].X && persons[i].Y == persons[j].Y && i != j && !persons[i].PersonsMet.Contains(persons[j]))
                    {
                        Helpers.CalculateColission(persons[i], persons[j], interactions);
                        
                        if (persons[i].Direction == persons[j].Direction)
                        {
                            Random rnd = new Random();
                            persons[i].Direction = persons[j].Direction == 0 ? rnd.Next(1, 6) : 0;
                            int test = 0;
                        }
                    }

                }


            }

        }

        public static void CalculateColission(Person person1, Person person2, Interactions interactions)
        {
            person1.PersonsMet.Add(person2);
            person2.PersonsMet.Add(person1);
            string conversation = "";

            if (person1 is Police)
            {
                conversation = person1.Interact(person2);
            }
            else if (person1 is Thief)
            {
                conversation = person1.Interact(person2);
            }
            else if (person1 is Citizen)
            {
                conversation = person1.Interact(person2);
            }
            interactions.Conversations.Add(conversation);
            interactions.NewConversation = true;
            interactions.CheckListLength();
        }

        public static List<string> NameList()
        {
            List<string> nameList = new List<string>()
            {
                "Andersson",
                "Pettersson",
                "Forsberg",
                "Sedin",
                "Bästerman",
                "Karlsson",
                "Sjödin",
                "Ekman",
                "Larsson",
                "Lundqvist",
                "Ali",
                "Bengtsson",
                "Hult",
                "Johansson",
                "Nilsson",
                "Viberg",
                "Varberg",
                "Gustafsson",
                "Fröjd",
                "Lilja",
                "Bergström",
                "Ström",
                "Strömberg",
                "Lundberg",
                "Ekdahl",
                "Svensson",
                "Isaksson",
                "Arvidsson",
                "Elm",
                "Mellberg",
                "Thelin",
                "Stenberg",
                "Bagge",
                "Wahlgren",
                "Ingrosso",
                "Brolin",
                "Alm",
                "Berghagen",
                "Book",
                "Ulveus",
                "Ibrahimovic",
                "Eriksdotter",
                "Uggla",
                "Guldkula",
                "Natt och dag",
                "Von Ribbing",
                "Hellström",
                "Gadd",
                "Hallin",
                "Kling",
                "Klang",
                "Eastwood",
                "Wagner"
            };

            return nameList;
        }

        public static DateTime ChangeDirection(List<Person> persons, DateTime datetime)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan timeSpan = currentTime - datetime;

            if (timeSpan.TotalSeconds > 30)
            {
                foreach (Person person in persons)
                {
                    Random rnd = new Random();
                    person.Direction = rnd.Next(0, 6);
                }

                datetime = currentTime;
            }
            return datetime;
        }

        public static void CheckPath(List<Person> persons)
        {

        }
    }
}
