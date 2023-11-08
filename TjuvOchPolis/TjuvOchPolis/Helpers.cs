using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Helpers
    {

        public static char[,] UpdateBoard(char[,] board)
        {
            char[,] newBoard = new char[board.GetLength(0), board.GetLength(1)];
            for (var i = 0; i < newBoard.GetLength(0); i++)
            {
                for (var j = 0; j < newBoard.GetLength(1); j++)
                {
                    newBoard[i, j] = ' ';
                }
            }

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
                    case 6:
                        persons[i].Y++;
                        persons[i].X--;
                        break;
                    case 7:
                        persons[i].Y--;
                        persons[i].X++;
                        break;
                }

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

        public static void DrawBoard(char[,] board, List<Person> persons, Interactions interactions, int numberOfThieves)

        {
            foreach (Person person in persons)
            {
                board[person.Y, person.X] = person.Type;
            }

            for (int i = 0; i < board.GetLength(1) + 2; i++)
            {
                Console.Write('=');
            }

            if (board.GetLength(1) < 40)
            {
                Console.Write("  HÄLLBYANSTALTEN");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("  Arresterade: " + interactions.Arrested);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("  Rånade: " + interactions.Robberies);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("  Fängslade: " + persons.Count);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("  Fria tjuvar: " + (numberOfThieves - persons.Count));
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (board.GetLength(1) > 40)
            {
                Console.WriteLine("  ESKILSTUNA");
            }
            else
            {
                Console.Write("  FATTIGHUSET");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("  Fattiga : " + persons.Count);
                Console.ForegroundColor = ConsoleColor.White;
            }

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write('|');
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    switch (board[i, j])
                    {
                        case 'M':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case 'P':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case 'T':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                    }
                    Console.Write(board[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;
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
                            persons[i].Direction = persons[j].Direction == 0 ? rnd.Next(1, 8) : 0;
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
                interactions.Arrested += conversation.Contains("arrestera") ? 1 : 0;
            }
            else if (person1 is Thief)
            {
                conversation = person1.Interact(person2);
                interactions.Robberies += conversation.Contains("råna") ? 1 : 0;
                interactions.Arrested += conversation.Contains("arrestera") ? 1 : 0;
            }
            else if (person1 is Citizen)
            {
                conversation = person1.Interact(person2);
                interactions.Robberies += conversation.Contains("råna") ? 1 : 0;
            }
            interactions.Conversations.Add(conversation);
            interactions.NewConversation = true;
        }

        public static List<string> NameList()
        {
            List<string> nameList = new List<string>()
             {
                "Korhonen",
                "Virtanen",
                "Mäkinen",
                "Nieminen",
                "Hämäläinen",
                "Laine",
                "Koskinen",
                "Järvinen",
                "Lehtonen",
                "Heikkinen",
                "Andersen",
                "Nielsen",
                "Hansen",
                "Jensen",
                "Pedersen",
                "Rasmussen",
                "Christensen",
                "Larsen",
                "Madsen",
                "Olsen",
                "Johansen",
                "Hansen",
                "Andersen",
                "Olsen",
                "Larsen",
                "Pedersen",
                "Nilsen",
                "Kristiansen",
                "Torgersen",
                "Pettersen",
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
                "Wagner",
                "Smith",
                "Johnson",
                "Williams",
                "Brown",
                "Davis",
                "Miller",
                "Jones",
                "Garcia",
                "Rodriguez",
                "Martinez",
                "Hernandez",
                "Lopez",
                "Gonzalez",
                "Wilson",
                "Anderson",
                "Thomas",
                "White",
                "Moore",
                "Taylor",
                "Jackson",
                "Harris",
                "Martin",
                "Thompson",
                "Robinson",
                "Clark",
                "Lewis",
                "Lee",
                "Walker",
                "Hall"
            };

            return nameList;
        }
        public static DateTime ChangeDirection(List<Person> persons, DateTime datetime)
        {
            if ((DateTime.Now - datetime).TotalSeconds > 30)
            {
                foreach (Person person in persons)
                {
                    Random rnd = new Random();
                    person.Direction = rnd.Next(0, 8);
                }
                datetime = DateTime.Now;
            }
            return datetime;
        }

        public static List<Person> AddPerson(ConsoleKeyInfo key, char[,] board, List<Person> persons)
        {

            if (!(key.KeyChar == 'm' || key.KeyChar == 't' || key.KeyChar == 'p'))
            {
                return persons;
            }

            Random rnd = new Random();
            List<String> nameList = NameList();
            int nameNumber = rnd.Next(0, nameList.Count);
            switch (key.KeyChar)
            {
                case 'm':
                    Citizen citizen = new Citizen();
                    citizen.InitializePerson(board);
                    citizen.Lastname = nameList[nameNumber];
                    persons.Add(citizen);
                    break;
                case 't':
                    Thief thief = new Thief();
                    thief.InitializePerson(board);
                    thief.Lastname = nameList[nameNumber];
                    persons.Add(thief);
                    break;
                case 'p':
                    Police police = new Police();
                    police.InitializePerson(board);
                    police.Lastname = nameList[nameNumber];
                    persons.Add(police);
                    break;
            }

            return persons;
        }
        public static int UpdateNumberOfThieves(List<Person> persons)
        {
            int count = 0;

            foreach (Person person in persons)
            {
                if (person is Thief thief)
                {
                    count++;
                }
            }
            return count;
        }
    }
}


