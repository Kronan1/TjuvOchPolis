using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Helpers
    {
        public static char[,] UpdateBoard(char[,] board, List<Person> persons)
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
            foreach (var person in persons)
            {
                newBoard[person.Y, person.X] = person.Type;
            }

            return newBoard;
        }

        public static void Move(List<Person> persons, char[,] board)
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
        public static void DrawBoard(char[,] board)
        {
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
                
                for (int j = 0; j < persons.Count; j++)
                {
                    int test = 0;
                    if (persons[i].X == persons[j].X && persons[i].Y == persons[j].Y && i != j && !persons[i].PersonsMet.Contains(persons[j]))
                    {
                        Helpers.CalculateColission(persons[i], persons[j], interactions);
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
                if (person2 is Police)
                {
                    conversation = "Polis " + person1.Lastname + " säger hej till polis " +  person2.Lastname;
                }
                else if (person2 is Thief)
                {
                    conversation = "Polis " + person1.Lastname + " tittar misstänksamt på tjuven " + person2.Lastname;
                }
                else if (person2 is Citizen)
                {
                    conversation = "Polis " + person1.Lastname + " hälsar på medborgare " + person2.Lastname;
                }
            }
            else if (person1 is Thief)
            {
                if (person2 is Police)
                {
                    conversation = "Tjuv " + person1.Lastname + " säger hej till polis " + person2.Lastname;
                }
                else if (person2 is Thief)
                {
                    conversation = "Tjuv " + person1.Lastname + " fnissar åt tjuv " + person2.Lastname;
                }
                else if (person2 is Citizen)
                {
                    conversation = "Tjuv " + person1.Lastname + " rånar medborgare " + person2.Lastname;
                }
            }
            else if (person1 is Citizen)
            {
                if (person2 is Police)
                {
                    conversation = "Medborgare " + person1.Lastname + " säger hej till polis " + person2.Lastname;
                }
                else if (person2 is Thief)
                {
                    conversation = "Medborgare " + person1.Lastname + " blir rånad av tjuv " + person2.Lastname;
                }
                else if (person2 is Citizen)
                {
                    conversation = "Medborgare " + person1.Lastname + " hälsar på medborgare " + person2.Lastname;
                }
            }
            
            interactions.Conversations.Add(conversation);
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
    }
}
